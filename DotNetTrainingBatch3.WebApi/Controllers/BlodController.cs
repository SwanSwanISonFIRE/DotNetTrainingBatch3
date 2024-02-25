using DotNetTrainingBatch3.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotNetTrainingBatch3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlodController : ControllerBase
    {
       private readonly AppdbContext _db;

        public BlodController()
        {
            _db = new AppdbContext();
                
        }


        [HttpGet]
        public IActionResult GetBlod()
        {
           List<BlodModel> lst= _db.blods.OrderByDescending(x=>x.BoldId).ToList();
           return Ok(lst);
        }

        [HttpPost]
        public IActionResult CreateBlod(BlodModel blod)
        {
            _db.blods.Add(blod);
            int result = _db.SaveChanges();
            string message = result > 0 ? "save success" : "save fail";
            return Ok(message);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBlod(int id,BlodModel blod)
        {
            BlodModel? item = _db.blods.FirstOrDefault(item => item.BoldId == id);
            if (item is null)
            {
              
                return NotFound("No data found");

            }
            item.BoldTitle = blod.BoldTitle;
            item.BlodAuthor = blod.BlodAuthor;
            item.BlodContent = blod.BlodContent;
            int result = _db.SaveChanges();
            string message = result > 0 ? "Update success" : "Update fail";
            return Ok(message);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBlod(int id)
        {
            BlodModel? item = _db.blods.FirstOrDefault(item => item.BoldId == id);
            if (item is null)
            {

                return NotFound("No data found");

            }
            _db.blods.Remove(item);
            int result = _db.SaveChanges();
            string message = result > 0 ? "delete success" : "delete fail";
            return Ok(message);

           
        }

    }
}
