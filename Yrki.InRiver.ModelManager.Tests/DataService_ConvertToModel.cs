using System;
using System.Collections.Generic;
using inRiver.Remoting.Objects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Yrki.InRiver.Attributes;

namespace Yrki.InRiver.Tests
{
	[TestClass]
	public class DataService_ConvertToModel
	{
		[TestMethod]
		public void Single_Field_String()
		{
			// Arrange
			const string valueToTest = "Test field";

			var entity = new Entity();
			entity.EntityType = new EntityType("Product");
			entity.Fields = new List<Field>()
			{
				new Field()
				{
					FieldType = new FieldType("MyStringField", "Product", "String", "CategoryId"),
					Data = valueToTest
				}
			};

			ModelManager.Load("Yrki.InRiver.Tests");

			// Act
			var stronglyTypedModel = ModelManager.DataService.ConvertToModel<MyDummyProduct>(entity);


			// Assert
			Assert.AreEqual(valueToTest, stronglyTypedModel.MyString);
		}

		[TestMethod]
		public void Single_Field_Int()
		{
			// Arrange
			const int valueToTest = 12;

			var entity = new Entity();
			entity.EntityType = new EntityType("Product");
			entity.Fields = new List<Field>()
			{
				new Field()
				{
					FieldType = new FieldType("MyIntField", "Product", "Int", "CategoryId"),
					Data = valueToTest
				}
			};

			ModelManager.Load("Yrki.InRiver.Tests");

			// Act
			var stronglyTypedModel = ModelManager.DataService.ConvertToModel<MyDummyProduct>(entity);


			// Assert
			Assert.AreEqual(valueToTest, stronglyTypedModel.MyInt);
		}

		[TestMethod]
		public void Single_Field_Bool()
		{
			// Arrange
			const bool valueToTest = true;

			var entity = new Entity();
			entity.EntityType = new EntityType("Product");
			entity.Fields = new List<Field>()
			{
				new Field()
				{
					FieldType = new FieldType("MyBoolField", "Product", "Bool", "CategoryId"),
					Data = valueToTest
				}
			};

			ModelManager.Load("Yrki.InRiver.Tests");

			// Act
			var stronglyTypedModel = ModelManager.DataService.ConvertToModel<MyDummyProduct>(entity);


			// Assert
			Assert.AreEqual(valueToTest, stronglyTypedModel.MyBool);
		}

		[TestMethod]
		public void Single_Field_DateTime()
		{
			// Arrange
			DateTime valueToTest = new DateTime(1975, 04, 03, 18, 30, 00);

			var entity = new Entity();
			entity.EntityType = new EntityType("Product");
			entity.Fields = new List<Field>()
			{
				new Field()
				{
					FieldType = new FieldType("MyDateTimeField", "Product", "DateTime", "CategoryId"),
					Data = valueToTest
				}
			};

			ModelManager.Load("Yrki.InRiver.Tests");

			// Act
			var stronglyTypedModel = ModelManager.DataService.ConvertToModel<MyDummyProduct>(entity);


			// Assert
			Assert.AreEqual(valueToTest, stronglyTypedModel.MyDateTime);
		}


		[TestMethod]
		public void Single_Field_Double()
		{
			// Arrange
			Double valueToTest = 3.14159265358979323846264338327950288419716939937510582;

			var entity = new Entity();
			entity.EntityType = new EntityType("Product");
			entity.Fields = new List<Field>()
			{
				new Field()
				{
					FieldType = new FieldType("MyDoubleField", "Product", "Double", "CategoryId"),
					Data = valueToTest
				}
			};

			ModelManager.Load("Yrki.InRiver.Tests");

			// Act
			var stronglyTypedModel = ModelManager.DataService.ConvertToModel<MyDummyProduct>(entity);


			// Assert
			Assert.AreEqual(valueToTest, stronglyTypedModel.MyDouble);
		}
	}


	[InRiverEntityType(EntityTypeId = "Product")]
	public class MyDummyProduct
	{

		[InRiverFieldType(FieldTypeId = "MyStringField")]
		public string MyString { get; set; }


		[InRiverFieldType(FieldTypeId = "MyIntField")]
		public int MyInt { get; set; }

		[InRiverFieldType(FieldTypeId = "MyBoolField")]
		public bool MyBool { get; set; }

		[InRiverFieldType(FieldTypeId = "MyDateTimeField")]
		public DateTime MyDateTime { get; set; }


		[InRiverFieldType(FieldTypeId = "MyDoubleField")]
		public double MyDouble { get; set; }

	}

}