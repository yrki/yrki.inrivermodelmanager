using inRiver.Remoting.Objects;

namespace Yrki.InRiver.Converters
{
	internal interface IObjectConverter
	{
		Entity ConvertToEntity(object objectToConvert);
	}
}