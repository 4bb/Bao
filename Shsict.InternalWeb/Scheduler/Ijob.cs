using System;

namespace Shsict.InternalWeb.Scheduler
{
    public interface IJob
    {
        void Execute(object sender); 
    }
}

