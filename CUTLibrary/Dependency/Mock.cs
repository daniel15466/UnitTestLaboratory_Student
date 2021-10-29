using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CUT
{
    public interface ILogger
    {
        void Log(string message);
    }

    public class FileLogger : ILogger
    {
        public void Log(string message)
        {
            // log message to file
        }
    }

    public class AgeValidator
    {
        private ILogger _logger;

        public AgeValidator(ILogger logger)
        {
            this._logger = logger;
        }

        public bool Validate(int age)
        {
            if (age < 0)
            {
                this._logger.Log("Age is less than zero");
                return false;
            }

            return true;
        }
    }
}
