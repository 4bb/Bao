using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OracleClient;

namespace Microsoft.ApplicationBlocks.Data
{
    public class OracleDataHelper
    {
        //保持最多活动数
        private static int maxOpen = 5;
       
        /// <summary>
        /// 数据库连接管理器
        /// </summary>
        private static Dictionary<string, Queue<OracleConnection>> queueManager = new Dictionary<string, Queue<OracleConnection>>();

        /// <summary>
        /// 检查数据库连接是否可用
        /// </summary>
        /// <param name="conn">oracle连接</param>
        /// <returns></returns>
        public static bool isValid(OracleConnection conn)
        {
            if (conn == null)
                return false;
            if (conn.State == ConnectionState.Open)
                return true;
            else
            {
                try
                {
                    conn.Close();
                    conn = null;
                }
                catch (OracleException e)
                {
                    Console.WriteLine(e);
                }
                return false;
            }
        }

        /// <summary>
        /// 创建oracle连接
        /// </summary>
        /// <param name="connStr">oracle连接</param>
        /// <returns></returns>
        public static OracleConnection createConnection(string connStr)
        {
            OracleConnection conn = null;
            try
            {
                conn = new OracleConnection(connStr);
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            if (queueManager.ContainsKey(connStr) == false)
                queueManager.Add(connStr, new Queue<OracleConnection>());

            return conn;
        }


        /// <summary>
        /// 获取可用的oracle连接
        /// </summary>
        /// <param name="connStr">oracle连接字符串</param>
        /// <returns></returns>
        public static OracleConnection getConnectionByPool(string connStr)
        {
            OracleConnection conn;
            if (queueManager.ContainsKey(connStr))
            {
                lock (queueManager[connStr])
                {
                    //循环当前的可用数据库连接，返回第一个可用的连接，去除第一个可用连接前所有无效连接
                    while (queueManager[connStr].Count > 0)
                    {
                        conn = queueManager[connStr].Dequeue();
                        if (isValid(conn))
                            return conn;
                    }
                    return createConnection(connStr);
                }
            }
            else
            {
                return createConnection(connStr);
            }
        }

        /// <summary>
        /// 释放当前连接
        /// </summary>
        /// <param name="conn">oracle连接通道</param>
        /// <param name="connStr">oracle连接字符串</param>
        public static void freeConnectionToPool(OracleConnection conn,string connStr)
        {
            //如果当前连接字符串不在连接管理器内，首先在管理器中创建
            if (queueManager.ContainsKey(connStr) == false)
                queueManager.Add(connStr, new Queue<OracleConnection>());

            lock (queueManager[connStr])
            {
                if (queueManager[connStr].Count < maxOpen)
                {
                    queueManager[connStr].Enqueue(conn);
                }
                else
                {
                    try
                    {
                        conn.Close();
                        conn = null;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e);
                    }
                }

            }

        }

    }
}
