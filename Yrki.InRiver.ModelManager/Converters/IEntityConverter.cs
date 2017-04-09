using inRiver.Remoting.Objects;

namespace Yrki.InRiver.Converters
{
	public interface IEntityConverter
	{
		T ConvertTo<T>(Entity entity);
	}
}