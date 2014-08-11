using System;

namespace Shsict.Scheduler
{
    public interface IJob
    {
        void Execute(object sender); 
    }
}
