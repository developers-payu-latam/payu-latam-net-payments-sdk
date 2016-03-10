namespace PayuNetSdk.PayU.Util.Log4NetProxy
{
    using System;
    using System.IO;
    using System.Reflection;

	static class Loader
	{
		private static readonly Assembly log4NetAssembly = LoadAssembly();

		private static Assembly LoadAssembly()
		{
			Assembly assembly = Assembly.GetExecutingAssembly();
			string assemblyName = assembly.FullName.Split(',')[0];
			string resourceName = assemblyName + ".Resources.log4net.dll";

			Stream imageStream = assembly.GetManifestResourceStream(resourceName);
			long bytestreamMaxLength = imageStream.Length;
			byte[] buffer = new byte[bytestreamMaxLength];
			imageStream.Read(buffer, 0, (int)bytestreamMaxLength);

			Assembly loadedAssembly = Assembly.Load(buffer);

			AppDomain.CurrentDomain.AssemblyResolve +=
				delegate(object o, ResolveEventArgs args)
				{
					if (args.Name == "log4net" ||
						args.Name == "log4net, Version=1.2.10.0, Culture=neutral, PublicKeyToken=1b44e1d426115821")
						return log4NetAssembly;
					else
						return null;
				};

			return loadedAssembly;
		}

		internal static Type GetType(string typeName)
		{
			Type type = null;
			if (log4NetAssembly != null)
			{
				type = log4NetAssembly.GetType(typeName);
				if (null == type)
					throw new ArgumentException("Unable to locate type");
			}
			return type;
		}
	}
}