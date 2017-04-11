using inRiver.Remoting;
using inRiver.Remoting.Objects;
using System;
using Yrki.InRiver.TestModel;

namespace Yrki.InRiver.TestConsole
{
	class Program
	{
		static void Main(string[] args)
		{

			// Get entity from inRiver		
			inRiver.Remoting.RemoteManager.CreateInstance("http://localhost:8080", "demoa1", "demoa1");
			var entityFromInriver = RemoteManager.DataService.GetEntity(1179, LoadLevel.DataAndLinks);

			// Load the assembly with the strongly typed class(es)
			Yrki.InRiver.ModelManager.Load("Yrki.InRiver.TestModel");
			
			// Convert the entity to a strongly typed model
			var product = ModelManager.DataService.ConvertToModel<MyProduct>(entityFromInriver);


			// Convert a strongly typed model to an inRiver entity object
			var entity = ModelManager.DataService.ConvertToInRiverEntity(product);

			Console.WriteLine(ModelManager.IsLoaded);
		}
	}
}
