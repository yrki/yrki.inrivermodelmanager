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

			inRiver.Remoting.RemoteManager.CreateInstance("http://localhost:8080", "demoa1", "demoa1");

			Yrki.InRiver.ModelManager.Load("Yrki.InRiver.TestModel");
			
			var entityFromInriverEntity = RemoteManager.DataService.GetEntity(1179, LoadLevel.DataAndLinks);
			var product = ModelManager.DataService.ConvertToModel<MyProduct>(entityFromInriverEntity);
			var backEntity = ModelManager.DataService.ConvertToInRiverEntity(product);

			Console.WriteLine(ModelManager.IsLoaded);
		}
	}
}
