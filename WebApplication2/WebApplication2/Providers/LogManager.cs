using log4net;
using System.Xml;

namespace ApiModAmin.Providers
{
    public interface ILoggerManager
    {
        void Info(string message);
        void Error(string message, Exception e);
    }

    public class LoggerManager : ILoggerManager
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(LoggerManager));

        public LoggerManager()
        {

            try
            {
                XmlDocument log4netConfig = new XmlDocument();
                log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo("log4net.config"));
            }
            catch (Exception ex)
            {
                logger.Error("Error LoggerManager", ex);
            }
        }
        public void Info(string message)
        {
            logger.InfoFormat(message);
        }

        public void Error(string message, Exception e)
        {
            logger.Error(message, e);
        }
    }

}
