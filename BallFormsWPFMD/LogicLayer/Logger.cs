using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLayer
{
    public class Logger
    {
        public async Task LogMessage(string message)
        {
            string logfilepath = "log.txt";

            using (StreamWriter logWriter = new StreamWriter(logfilepath))
            {
                await logWriter.WriteLineAsync(message);
            }
        }
    }
}
