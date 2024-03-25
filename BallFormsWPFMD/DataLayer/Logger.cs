using System.Diagnostics;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer
{
    public class Logger
    {
        private readonly Stopwatch _stopwatch;

        private static Logger? _instance;

        private static readonly SemaphoreSlim _semaphoreSlim = new SemaphoreSlim(1, 1);

        string logfilepath = "log.txt";

        private Logger()
        {
            File.Delete(logfilepath);
            _stopwatch = Stopwatch.StartNew();
        }

        public static async Task<Logger> GetInstance()
        {
            if( _instance == null)
            {
                await _semaphoreSlim.WaitAsync();
                _instance = new Logger();
                _semaphoreSlim?.Release();
            }
            return _instance;
        }

        public void LogBallStatus()
        {
            _ = LogMessage("new");
        }

        public async Task LogMessage(string message)
        {

            using (StreamWriter logWriter = new StreamWriter(logfilepath, append: true))
            {
                await logWriter.WriteLineAsync($"[{_stopwatch.Elapsed.Duration()}]" + message);
            }
        }
    }
}
