using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using inRiver.Remoting;
using inRiver.Remoting.Objects;

namespace Yrki.InRiver.ModelCreator
{
	class Program
	{
		static void Main(string[] args)
		{

			if (ValidateArguments(args))
			{
				var entityTypes = RemoteManager.ModelService.GetAllEntityTypes();
				var fieldTypes = RemoteManager.ModelService.GetAllFieldTypes();
				var linkTypes = RemoteManager.ModelService.GetAllFieldTypes();
				var cvls = RemoteManager.ModelService.GetAllCVLs();
				var categories = RemoteManager.ModelService.GetAllCategories();
				var fieldsets = RemoteManager.ModelService.GetAllFieldSets();
				var languages = RemoteManager.UtilityService.GetAllLanguages();


				CreateEntityClasses(entityTypes, fieldTypes, linkTypes);





			}
		}

		private static void CreateEntityClasses(List<EntityType> entityTypes, List<FieldType> fieldTypes, List<FieldType> linkTypes)
		{

		}

		private static bool ValidateArguments(string[] args)
		{
			if (args.Length != 5)
			{
				Console.WriteLine(@"USAGE: Yrki.InRiver.ModelCreator.exe <server> <user name> <password> <namespace> <output path>");
				Console.WriteLine(@"EXAMPLE: Yrki.InRiver.ModelCreator.exe http://localhost:8080 pimuser1 pimuser1 MyNamespace.Models c:\temp\");
				return false;
			}

			return true;
		}

		public string FileTemplate(string namespaceString, string classString)
		{
			var template = $"using System;" + Environment.NewLine +
						   $"using Yrki.InRiver.Attributes;" + Environment.NewLine +
						   Environment.NewLine +
						   $"namespace {namespaceString}" + Environment.NewLine +
						   "{ " + Environment.NewLine +
						   $"{classString}" + Environment.NewLine +
						   "}" + Environment.NewLine;

			return template;
		}

		public string ClassTemplate(EntityType entityType, string fieldsString)
		{
			var template = $"[InRiverEntityType EntityTypeId = {entityType.Id}, " +
						   $"Name = \"{entityType.Name}\", " +
						   $"IsLinkEntityType =  {entityType.IsLinkEntityType}, " +
						   "]" + Environment.NewLine +
						   $"public class {entityType.Id}" + Environment.NewLine +
						   "{" + Environment.NewLine +
						   fieldsString + Environment.NewLine +
						   "}" + Environment.NewLine;

			return template;
		}

		public string FieldTemplate(FieldType fieldType)
		{
			var template = $"[InRiverFieldType FieldTypeId = {fieldType.Id}," +
						   $"Index = {fieldType.Index}, " +
						   $"DataType = {fieldType.DataType}, " +
						   $"CVL = typeof({fieldType.CVLId}), " +
						   $"Category = typeof({fieldType.CategoryId}), " +
						   $"DefaultValue = \"{fieldType.DefaultValue}\", " +
						   $"Mandatory = {fieldType.Mandatory}, " +
						   $"ReadOnly = {fieldType.ReadOnly}, " +
						   $"IsDisplayName = {fieldType.IsDisplayName}, " +
						   $"IsDisplayDescription = {fieldType.IsDisplayDescription}, " +
						   $"MultiValue = {fieldType.Multivalue}, " +
						   $"Unique = {fieldType.Unique}, " +
						   $"Hidden = {fieldType.Hidden}, " +
						   $"ExcludeFromDefaultView = {fieldType.ExcludeFromDefaultView}, " +
						   $"Name = {fieldType.Name}, " +
						   $"TrackChanges = {fieldType.TrackChanges}, " +
						   $"Description = {fieldType.Description}" +
						   "]" + Environment.NewLine;
			var dataType = GetDataTypeFromInRiverDataType(fieldType.DataType);
			var name = fieldType.Id;

			template += $"public {dataType} {fieldType.Name} {{ get; set; }}" + Environment.NewLine;

			return template;
		}
		 
		private string GetDataTypeFromInRiverDataType(string fieldTypeDataType)
		{
			throw new NotImplementedException();
		}

		public string LinkTemplate(LinkType linkType)
		{

		}





	}
}
}
