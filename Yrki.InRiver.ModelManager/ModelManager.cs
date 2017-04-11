using System;
using System.Reflection;

namespace Yrki.InRiver
{
    public static class ModelManager
    {
	    private static bool _isAssemblyLoaded;
	    private static Assembly _assembly;
	    private static IDataService _dataService;

		public static void Load(string assemblyName)
		{
			_assembly = Assembly.Load(assemblyName);
			_isAssemblyLoaded = true;
		}

		public static void LoadFile(string path)
		{
			throw new NotImplementedException();
		}

	    public static void LoadPath(string folder)
	    {
			throw new NotImplementedException();
	    }


	    public static bool IsLoaded
	    {
		    get { return _isAssemblyLoaded; }
	    }

	    public static IDataService DataService
	    {
		    get
		    {
			    if (_isAssemblyLoaded)
			    {
				    if (_dataService != null)
				    {
					    return _dataService;
				    }

					_dataService = new DataService(_assembly);
				    return _dataService;
			    }

			    return null;
		    }
	    }



    }
}
