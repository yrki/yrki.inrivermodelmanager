using System;
using inRiver.Remoting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yrki.InRiver.Attributes;

namespace Yrki.InRiver.Tests
{
	[TestClass]
	public class DataService_ConvertToEntity
	{

		[TestMethod]
		public void Single_Property_String()
		{
			throw new Exception("To be able to make unit tests for this, we need the IRemoteManager-interfaces (And IModelService-interfaces");
			// Arrange
			//const string valueToTest = "Test field";

			//var classUnderTest = new MyConvertToEntityClass()
			//{
			//	MyString = valueToTest
			//};

			//var modelService = RemoteManager.ModelService;


			//ModelManager.Load("Yrki.InRiver.Tests", modelService);
			
			//// Act
			//var entity = ModelManager.DataService.ConvertToInRiverEntity(classUnderTest);


			//// Assert
			//Assert.AreEqual(valueToTest, entity.GetField("MyFieldString").Data);

		}
	}


	[InRiverEntityType(EntityTypeId = "MyEntityTypeId")]
	public class MyConvertToEntityClass
	{

		[InRiverFieldType(FieldTypeId = "MyFieldString")]
		public string MyString { get; set; }
		
	}
}
