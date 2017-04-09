using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using inRiver.Remoting;
using inRiver.Remoting.Objects;
using Yrki.InRiver.Attributes;
using Yrki.InRiver.Helpers;

namespace Yrki.InRiver.Converters
{
	public class EntityConverter : IEntityConverter
	{
		private readonly Assembly _assembly;
		private readonly IPropertyHelper _propertyHelper;

		public EntityConverter(Assembly assembly, IPropertyHelper propertyHelper)
		{
			TypeDescriptor.AddAttributes(typeof(inRiver.Remoting.Objects.LocaleString), new TypeConverterAttribute(typeof(LocaleStringConverter)));

			_assembly = assembly;
			_propertyHelper = propertyHelper;
		}

		public T ConvertTo<T>(Entity entity)
		{
			var result = CreateInstanceOfEntityTypeObject(entity.EntityType.Id);

			if (result != null)
			{
				PopulateFields(result, entity);

				if (entity.OutboundLinks != null && entity.OutboundLinks.Count > 0)
				{
					PopulateLinks(result, entity.OutboundLinks);
				}

			}

			return (T)result; ;

		}

		private void PopulateFields(object o, Entity entity)
		{
			foreach (var field in entity.Fields)
			{
				if (field.Data != null)
				{
					PopulateField(o, field);
				}
			}
		}

		private void PopulateField(object o, Field field)
		{
			var property = _propertyHelper.GetPropertyForFieldType(o.GetType(), field.FieldType.Id);

			_propertyHelper.SetPropertyValue(property, o, field.Data);
		}

		private void PopulateLinks(object parentObject, List<Link> links)
		{
			foreach (Link link in links)
			{
				//if (link.ToString() == "ItemItem") continue;

				var childEntity = RemoteManager.DataService.GetEntity(link.Target.Id, LoadLevel.DataAndLinks); // TODO: Refactor this?
				var childObject = ConvertTo<object>(childEntity);

				if (childObject != null)
				{
					childObject = PopulateLinkType(link, childObject);

					var property = _propertyHelper.GetFieldForLink(parentObject.GetType(), childObject.GetType());

					AddValueToList(property, parentObject, childObject);
				}
			}
		}

		private void AddValueToList(PropertyInfo property, object parentObject, object childObject)
		{
			object list;

			if (property.GetValue(parentObject) == null)
			{
				list = CreateInsanceOfList(childObject.GetType());
				property.SetValue(parentObject, list);
			}
			else
			{
				list = property.GetValue(parentObject);
			}

			list.GetType().GetMethod("Add").Invoke(list, new[] { childObject });
		}

		private object PopulateLinkType(Link link, object childObject)
		{
			if (link.LinkEntity != null)
			{
				var linkModel = ConvertTo<object>(link.LinkEntity);

				var property = _propertyHelper.GetPropertyForLinkType(childObject.GetType());

				if (property != null)
				{
					property.SetValue(childObject, linkModel);
				}
			}

			return childObject;
		}

		private object CreateInsanceOfList(Type t)
		{
			var listType = typeof(List<>);
			var constructedListType = listType.MakeGenericType(t);

			var instance = Activator.CreateInstance(constructedListType);

			return instance;
		}

		private object CreateInstanceOfEntityTypeObject(string entityTypeId)
		{
			var allTypes = _assembly.GetTypes();

			foreach (var type in allTypes)
			{
				var customAttributes = type.GetCustomAttributes(typeof(InRiverEntityTypeAttribute));

				if (customAttributes.Any())
				{
					var attribute = (InRiverEntityTypeAttribute)customAttributes.FirstOrDefault();

					if (string.Equals(attribute.EntityTypeId, entityTypeId, StringComparison.InvariantCultureIgnoreCase))
					{
						return Activator.CreateInstance(type);
					}

				}
			}

			return null;
		}
	}
}
