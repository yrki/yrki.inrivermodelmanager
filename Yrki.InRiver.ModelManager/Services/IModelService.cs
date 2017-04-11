using System.Collections.Generic;
using inRiver.Remoting.Objects;

namespace Yrki.InRiver
{
	internal interface IModelService
	{
		void SyncronizeModelWithInRiverServer();
		IEnumerable<FieldType> GetAllFieldTypes();
		IEnumerable<EntityType> GetAllEntityTypes();
		IEnumerable<LinkType> GetAllLinkTypes();
	}

}
