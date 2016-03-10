
namespace PayuNetSdk.PayU.Util.Log4NetProxy
{
    using System.Reflection;

	class LogImpl : ILog
	{
		private readonly object instance;

		internal LogImpl(object instance)
		{
			this.instance = instance;
		}

		public void Info(object message)
		{
			MethodInfo method = instance.GetType().GetMethod("Info", new[] { message.GetType() });
			method.Invoke(instance, new[] { message });
		}
	}
}