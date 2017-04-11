using inRiver.Remoting.Objects;

namespace Yrki.InRiver.Converters
{
	internal interface IEntityConverter
	{
		T ConvertTo<T>(Entity entity);
	}
}