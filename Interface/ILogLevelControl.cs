using System;
using Microsoft.Extensions.Logging;

namespace Task_Logging.Interface
{

    public interface ILogLevelControl
    {
        //This method help for changing or setting the log level
        void SetLogLevel(LogLevel logLevel);
        
    }
}

