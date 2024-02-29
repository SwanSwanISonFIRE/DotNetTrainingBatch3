using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp1_1.RestClientExamples
{
    public class RestClientEg
    {
        private readonly string _apiUrl = "https://local:7131/api/Blog";
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
            RestRequest req = new RestRequest(_apiUrl, Method.Get);
            RestClient c = new RestClient();
            RestResponse resp = await c.ExecuteAsync(req);

            if (resp.IsSuccessStatusCode)
            {
                string json = resp.Content!;
                List<BlodModel> lst = JsonConvert.DeserializeObject<List<BlodModel>>(json);
                foreach (BlodModel item in lst)
                {
                    Console.WriteLine(item.BlodAuthor);
                    Console.WriteLine(item.BoldTitle);
                    Console.WriteLine(item.BlodContent);
                }
            }
            else
            {
                Console.WriteLine(resp.Content!);
            }
        }

        public async Task Edit(int id)
        {
            string url = $"{_apiUrl}{id}";
            RestRequest req = new RestRequest(url, Method.Get);
            RestClient c = new RestClient();
            RestResponse resp = await c.ExecuteAsync(req);
            if (resp.IsSuccessStatusCode)
            {
                string json = resp.Content!;
                BlodModel item = JsonConvert.DeserializeObject<BlodModel>(json)!;
                Console.WriteLine(item.BoldId);
                Console.WriteLine(item.BlodAuthor);
                Console.WriteLine(item.BoldTitle);
                Console.WriteLine(item.BlodContent);

            }
            else
            {
                Console.WriteLine(resp.Content!);

            }
        }

        public async Task Create(string title, string author, string content)
        {
            BlodModel bm = new BlodModel
            {
                BlodAuthor = author,
                BlodContent = content,
                BoldTitle = title
            };

            RestRequest req = new RestRequest(_apiUrl, Method.Post);
            req.AddJsonBody(bm);
            RestClient c = new RestClient();
            RestResponse resp = await c.ExecuteAsync(req);

            if (resp.IsSuccessStatusCode)
            {
                
                Console.WriteLine(resp.Content!);
            }
            else
            {
                Console.WriteLine(resp.Content!);
            }

        }
            public async Task Update(int id, string title, string author, string content)
            {
                BlodModel bm = new BlodModel
                {

                    BlodAuthor = author,
                    BlodContent = content,
                    BoldTitle = title
                };
                string url = $"{_apiUrl}{id}";
                RestRequest req = new RestRequest(_apiUrl, Method.Put);
                req.AddJsonBody(bm);
                RestClient c = new RestClient();
                RestResponse resp = await c.ExecuteAsync(req);


                if (resp.IsSuccessStatusCode)
                {
                   
                    Console.WriteLine(resp.Content!);
                }
                else
                {
                    Console.WriteLine(resp.Content!);
                }
            }
            private async Task Delete(int id)
            {
                string url = $"{_apiUrl}{id}";
                RestRequest req = new RestRequest(_apiUrl, Method.Put);
                
                RestClient c = new RestClient();
                RestResponse resp = await c.ExecuteAsync(req);
                if (resp.IsSuccessStatusCode)
                {

                     Console.WriteLine(resp.Content!);
            }
                else
                {
                    Console.WriteLine(resp.Content!);
                }

            }

        
    }
}


