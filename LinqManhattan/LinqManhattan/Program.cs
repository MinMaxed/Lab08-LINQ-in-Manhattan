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

            //Converts the JSON files data and puts it into a RootObject, which chains to the other classes  
            // and allocates the data to the proper sections
            RootObject manhatten = Newtonsoft.Json.JsonConvert.DeserializeObject<RootObject>(json);

            //finds the neighborhoods that aren't null, LINQ
            var areas = from i in manhatten.Features
                        where i.Properties.Neighborhood != null
                        select i;

            foreach (var area in areas)
            {
                Console.WriteLine(area.Properties.Neighborhood);
            }
            Console.WriteLine("^ query 1");
            Console.ReadKey();
            Console.Clear();


            //find areas without blanks from the previous query's results, LINQ
            var noBlanks = from i in areas
                           where i.Properties.Neighborhood != ""
                           select i;

            foreach (var area in noBlanks)
            {
                Console.WriteLine(area.Properties.Neighborhood);
            }
            Console.WriteLine("^ query 2");
            Console.ReadKey();
            Console.Clear();

            //eliminate duplicate areas, lambda
            var noDoubles = noBlanks.GroupBy(g => g.Properties.Neighborhood).Select(s => s.First());

            foreach (var area in noDoubles)
            {
                Console.WriteLine(area.Properties.Neighborhood);
            }
            Console.WriteLine("^ query 3");
            Console.ReadKey();
            Console.Clear();



            // LINQ query to do all searches in one
            var allAreas = from i in manhatten.Features
                           where i.Properties.Neighborhood != null
                           where i.Properties.Neighborhood != ""
                           group i.Properties.Neighborhood by i.Properties.Neighborhood
                           into myNeighborhood
                           select myNeighborhood.Key;

            foreach (var area in allAreas)
            {
                Console.WriteLine(area);
            }
            Console.WriteLine("^ query 4");
            Console.ReadKey();
            Console.Clear();


            //Lambda queries to do all searches at once
            var allAreasLambda = manhatten.Features.Where(i => i.Properties.Neighborhood != null)
                                              .Where(i => i.Properties.Neighborhood != "")
                                              .GroupBy(g => g.Properties.Neighborhood)
                                              .Select(s => s.First());

            foreach (var area in allAreasLambda)
            {
                Console.WriteLine(area.Properties.Neighborhood);
            }
            Console.WriteLine("^ query 5");
            Console.ReadKey();
            Console.Clear();
        }

    }
}
