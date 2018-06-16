using LinqManhattan.JSON_Classes;
using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;

namespace LinqManhattan
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            string path = "../../../data.json";
            string json;

            using (StreamReader r = new StreamReader(path))
            {
                json = r.ReadToEnd();
            };


            //StreamReader sr = new StreamReader(path);
            //StreamWriter sw = new StreamWriter(path);

            RootObject manhatten = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);



            //var allAreas1 = manhatten.Features.Where(n => n.Properties.Neighborhood != "")
            //                                    .GroupBy(g => g.Properties.Neighborhood)
            //                                    .Select(m => m.First());



            // THIS THING FREAKING WORKS!!!!!!!!
            var allAreas = from i in manhatten.Features
                           where i.Properties.Neighborhood != ""
                           group i.Properties.Neighborhood by i.Properties.Neighborhood
                           into myNeighborhood
                           select myNeighborhood.Key;


            foreach(var area in allAreas)
            {
                Console.WriteLine(area);
            }
            Console.ReadKey();
        }
    }
}
