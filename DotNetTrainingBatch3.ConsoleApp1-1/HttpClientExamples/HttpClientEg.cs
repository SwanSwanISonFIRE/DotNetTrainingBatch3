using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using JsonConverter = Newtonsoft.Json.JsonConverter;

namespace DotNetTrainingBatch3.ConsoleApp1_1.HttpClientExamples
{
    public class HttpClientEg 
    {
        public async Task Run()
        {
            await Read();
        }

        private async Task Read()
        {
            HttpClient c = new HttpClient();
            HttpResponseMessage rm = await c.GetAsync("https://localhost:7131/api/Blod");
            if (rm.IsSuccessStatusCode)
            {
                string jsonStr = await rm.Content.ReadAsStringAsync();
                Console.WriteLine(jsonStr);

                //JsonConvert.SerializeObject();//c# object to json
                //JsonConvert.DeserializeObject();//Json to c# ob


                List<BlodModel> lst = JsonConvert.DeserializeObject<List<BlodModel>>(jsonStr);
                foreach (BlodModel item in lst)
                {
                    Console.WriteLine(item.BoldId);
                    Console.WriteLine(item.BoldTitle);
                    Console.WriteLine(item.BlodAuthor);
                    Console.WriteLine(item.BlodContent);
                }
            }
        }
    }
}
