using DotNetTrainingBatch3.ConsoleApp1_1.Models;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetTrainingBatch3.ConsoleApp1_1.Refit_Examples
{
    public interface IBlodApi
    {
        [Get("/api/blod")]
        Task<List<BlodModel>> GetBlod();

        [Get("/api/blod/{id}")]
        Task<BlodModel> GetBlod(int id);

        [Post("/api/blod")]
        Task<string> CreateBlod(BlodModel b);

        [Put("/api/blod/{id}")]
        Task<string> UpdateBlod(int id,BlodModel b);


        [Delete("/api/blod/{id}")]
        Task<string> DeleteBlod(int id);

    }
}
