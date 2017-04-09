using System.Collections.Generic;
using inRiver.Remoting.Objects;

namespace Yrki.InRiver
{
	public interface IModelService
	{
		
		IEnumerable<FieldType> GetAllFieldTypes();
		IEnumerable<EntityType> GetAllEntityTypes();
		IEnumerable<LinkType> GetAllLinkTypes();
	}

}
