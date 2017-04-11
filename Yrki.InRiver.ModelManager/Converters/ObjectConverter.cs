using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using inRiver.Remoting;
using inRiver.Remoting.Objects;
using Yrki.InRiver.Attributes;

namespace Yrki.InRiver.Converters
{
	internal class ObjectConverter : IObjectConverter
	{

		public ObjectConverter()
		{
		}

		public Entity ConvertToEntity(object objectToConvert)
		{
			var properties = objectToConvert.GetType().GetProperties();

			var entityTypeName = GetEntityTypeName(objectToConvert);
			var entityType = RemoteManager.ModelService.GetEntityType(entityTypeName);

			var entity = Entity.CreateEntity(entityType);

			foreach (var property in properties)
			{
				var inriverFieldTypeAttributes = property.GetCustomAttributes(typeof(InRiverFieldTypeAttribute));

				if (inriverFieldTypeAttributes.Any())
				{
					foreach (var attribute in inriverFieldTypeAttributes)
					{
						var fieldTypeAttribute = (InRiverFieldTypeAttribute) attribute;

						var fieldValue = property.GetValue(objectToConvert);

						var entityField = entity.GetField(fieldTypeAttribute.FieldTypeId);

						// Todo: Fix localestring
						entityField.Data = fieldValue;
					}


				}
			}

			return entity;
		}
		
		public void ConvertLinksAndEntities(object objectWithLinks, ref List<Link> links, ref List<Entity> entities)
		{
			var properties = objectWithLinks.GetType().GetProperties();

			var parent = ConvertToEntity(objectWithLinks);
			entities.Add(parent);

			foreach (var property in properties)
			{
				var linkTypeAttributes = property.GetCustomAttributes(typeof(InRiverLinkTypeAttribute));

				foreach (InRiverLinkTypeAttribute attribute in linkTypeAttributes)
				{
					var linkedObjects = (IList) property.GetValue(objectWithLinks);
					
					foreach (var linkedObject in linkedObjects)
					{
						
						var child = ConvertToEntity(linkedObject);
						entities.Add(child);

						// Todo: LinkEntity

						var linkType = RemoteManager.ModelService.GetLinkType(attribute.LinkType);
						Link link = new Link()
						{
							LinkType = linkType,
							Source = parent,
							Target = child
						};
						links.Add(link);


						ConvertLinksAndEntities(child, ref links, ref entities);
					}
				}
			}
		}

		private string GetEntityTypeName(object objectToConvert)
		{
			var customAttributes = objectToConvert.GetType().GetCustomAttributes(typeof(InRiverEntityTypeAttribute));

			if (customAttributes.Any())
			{
				var entityTypeAttribute = (InRiverEntityTypeAttribute) customAttributes.FirstOrDefault();

				return entityTypeAttribute.EntityTypeId;
			}

			return null;
		}
	}
}