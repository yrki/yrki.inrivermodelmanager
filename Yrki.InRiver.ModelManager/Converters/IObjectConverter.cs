using inRiver.Remoting.Objects;

namespace Yrki.InRiver.Converters
{
	public interface IObjectConverter
	{
		Entity ConvertToEntity(object objectToConvert);
	}
}