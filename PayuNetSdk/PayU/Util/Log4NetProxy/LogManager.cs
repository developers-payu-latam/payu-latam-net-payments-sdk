
namespace PayuNetSdk.PayU.Util.Log4NetProxy
{
    using System;
    using System.Reflection;

	static class LogManager
	{
		public static ILog GetLogger(string name)
		{
			ILog logger = null;

			Type logManager = Loader.GetType("log4net.LogManager");
			if (logManager != null)
			{
				MethodInfo method = logManager.GetMethod("GetLogger", new[] { name.GetType() });
				logger = new LogImpl(method.Invoke(null, new[] { name }));
			}

			return logger;
		}

	}
}