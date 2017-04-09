using System.Reflection;
using inRiver.Remoting.Objects;
using Yrki.InRiver.Converters;
using Yrki.InRiver.Helpers;

namespace Yrki.InRiver
{
	public class DataService : IDataService
	{
		private Assembly _assembly;
		private readonly IEntityConverter _entityConverter;
		private readonly IObjectConverter _objectConverter;
		
		public DataService(Assembly assembly)
		{
			_assembly = assembly;
			_entityConverter = new EntityConverter(assembly, new PropertyHelper());
			_objectConverter = new ObjectConverter();
		}
		
		public T ConvertToModel<T>(Entity entity)
		{
			return _entityConverter.ConvertTo<T>(entity);
		}

		public Entity ConvertToInRiverEntity(object value)
		{
			return _objectConverter.ConvertToEntity(value);
		}

		

		
	}
}