using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using Microsoft.EntityFrameworkCore.ValueGeneration.Internal;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp1_1.HttpClientExamples
{
    public class HttpEg2
    {
        public async Task Run()
        {
            await Read();
            await Edit(1);
            await Create("titles", "authors", "contents");
            await Update(5002, "titles", "authors", "contents");
            await Delete(5002);
        }

        private async Task Read()
        {
            HttpClient h = new HttpClient();
            HttpResponseMessage rm = await h.GetAsync("https://local:7131/api/Blog");
            if (rm.IsSuccessStatusCode)
            {
                string json = await rm.Content.ReadAsStringAsync();
                List<BlodModel> lst = JsonConvert.DeserializeObject<List<BlodModel>>(json);
                foreach(BlodModel item in lst)
                {
                    Console.WriteLine(item.BlodAuthor);
                    Console.WriteLine(item.BoldTitle);
                    Console.WriteLine(item.BlodContent);
                }
            }
            else
            {
                Console.WriteLine(await rm.Content.ReadAsStringAsync());
            }
        }

        public async Task  Edit(int id)
        {
            string url = $"https://localhost:7131/api/Blod/{id}";
            HttpClient h = new HttpClient();
            HttpResponseMessage rm = await h.GetAsync(url);
            if (rm.IsSuccessStatusCode)
            {
                string json = await rm.Content.ReadAsStringAsync();
                BlodModel item = JsonConvert.DeserializeObject<BlodModel>(json)!;
                Console.WriteLine(item.BoldId);
                Console.WriteLine(item.BlodAuthor);
                Console.WriteLine(item.BoldTitle);
                Console.WriteLine(item.BlodContent);

            }
            else
            {
                Console.WriteLine(await rm.Content.ReadAsStringAsync());

            }
        }

        public async Task Create(string title,string author,string content)
        {
            BlodModel bm = new BlodModel
            {
                BlodAuthor = author,
                BlodContent = content,
                BoldTitle = title
            };
            string jsonBlog = JsonConvert.SerializeObject(bm);
            HttpContent hc = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7131/api/Blod/";
            HttpClient h = new HttpClient();
            HttpResponseMessage rm = await h.PostAsync(url, hc);
            if (rm.IsSuccessStatusCode)
            {
                string json = await rm.Content.ReadAsStringAsync();
                BlodModel item = JsonConvert.DeserializeObject<BlodModel>(json)!;
                  
                Console.WriteLine(item.BlodAuthor);
                Console.WriteLine(item.BoldTitle);
                Console.WriteLine(item.BlodContent);
            }
            else
            {
                Console.WriteLine(await rm.Content.ReadAsStringAsync());
            }
        }


        public async Task Update(int id, string title,string author,string content)
        {
            BlodModel bm = new BlodModel
            {
                
                BlodAuthor = author,
                BlodContent = content,
                BoldTitle = title
            };
            string jsonBlog = JsonConvert.SerializeObject(bm);
            HttpContent hc = new StringContent(jsonBlog, Encoding.UTF8, MediaTypeNames.Application.Json);
            string url = $"https://localhost:7131/api/Blod/{id}";
            HttpClient h = new HttpClient();
            HttpResponseMessage rm = await h.PostAsync(url, hc);
            if (rm.IsSuccessStatusCode)
            {
                string json = await rm.Content.ReadAsStringAsync();
                Console.WriteLine(await rm.Content.ReadAsStringAsync());
            }
            else
            {
                Console.WriteLine(await rm.Content.ReadAsStringAsync());
            }
        }
        private async Task Delete(int id)
        {
            string url = $"https://localhost:7131/api/Blod/{id}";
            HttpClient h = new HttpClient();
            HttpResponseMessage rm = await h.DeleteAsync(url);
            if (rm.IsSuccessStatusCode)
            {
                string json = await rm.Content.ReadAsStringAsync();
                Console.WriteLine(json);
            }
            else
            {
                Console.WriteLine(await rm.Content.ReadAsStringAsync());
            }

        }

    }
}
