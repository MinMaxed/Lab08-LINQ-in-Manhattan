using LinqManhattan.JSON_Classes;
using System;
using System.IO;
using Newtonsoft.Json;

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


            //public static string ReadJSON()
            //{
            //    string read;
            //    using (sr)
            //    {
            //        read = sr.ReadToEnd(path);
            //    }
            //    return read;
            //}
        }
    }
}
