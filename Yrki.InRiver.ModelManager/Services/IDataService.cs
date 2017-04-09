using inRiver.Remoting.Objects;

namespace Yrki.InRiver
{
	public interface IDataService
	{
		T ConvertToModel<T>(Entity entity);
		Entity ConvertToInRiverEntity(object value);
	}
}
