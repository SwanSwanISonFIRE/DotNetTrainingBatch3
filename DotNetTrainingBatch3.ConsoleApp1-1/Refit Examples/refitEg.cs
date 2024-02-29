using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using Refit;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp1_1.Refit_Examples
{
    public class refitEg
    {
        private readonly IBlodApi refitApi = RestService.For<IBlodApi>("https://localhost:7131");
        public async Task Run()
        {
            await Read();
            await Edit(1);
        }

        private async Task Read()
        {
            var lst = await refitApi.GetBlod();
            
            foreach(BlodModel item in lst)
            {
                Console.WriteLine(item.BoldId);
                Console.WriteLine(item.BoldTitle);
                Console.WriteLine(item.BlodContent);
                Console.WriteLine(item.BlodAuthor);
            }
        }
        private async Task Edit(int id)
        {
            try
            {
                var item = await refitApi.GetBlod(id);
                Console.WriteLine(item.BoldId);
                Console.WriteLine(item.BoldTitle);
                Console.WriteLine(item.BlodContent);
                Console.WriteLine(item.BlodAuthor);
            }
            catch(Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
        public async Task Create(string title, string author, string content)
        {

            try
            {
                BlodModel bm = new BlodModel
                {
                    BlodAuthor = author,
                    BlodContent = content,
                    BoldTitle = title
                };

                string message = await refitApi.CreateBlod(bm);
                Console.WriteLine(message);
               
            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public async Task Update(int id,string title, string author, string content)
        {
           

            try
            {
                BlodModel bm = new BlodModel
                {
                    BlodAuthor = author,
                    BlodContent = content,
                    BoldTitle = title
                };

                string message = await refitApi.UpdateBlod(id,bm);
                Console.WriteLine(message);

            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }

        public async Task Delete(int id)
        {
                
            try
            {
                string message = await refitApi.DeleteBlod(id);
                Console.WriteLine(message);

            }
            catch (Refit.ApiException ex)
            {
                Console.WriteLine(ex.Content);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

        }
    }
  

}
