using DotNetTrainingBatch3.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotNetTrainingBatch3.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BirdsController : ControllerBase
    {
        private readonly string _url="https://burma-project-ideas.vercel.app/birds";
        [HttpGet]
        public async Task <IActionResult> Get()
        {
            HttpClient h = new HttpClient();
            var respone= await h.GetAsync(_url);
            if (respone.IsSuccessStatusCode)
            {
                string json = await respone.Content.ReadAsStringAsync();
                List<BirdDataModel> birds = JsonConvert.DeserializeObject<List<BirdDataModel>>(json)!;

                List<BirdViewModel> lst = birds.Select(bird => change(bird)).ToList();

                return Ok(lst);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpGet("{id}")]

        public async Task <IActionResult>  Get(int id)
        {
            HttpClient h = new HttpClient();
            var respone = await h.GetAsync($"{_url}/{id}");
            if (respone.IsSuccessStatusCode)
            {
                string json = await respone.Content.ReadAsStringAsync();
                BirdDataModel bird = JsonConvert.DeserializeObject<BirdDataModel>(json)!;

                var item = change(bird);
                return Ok();

            }
            else
            {
                return BadRequest();
            }
        }

        private BirdViewModel change(BirdDataModel bird)
        {
            var item = new BirdViewModel
            {
                BirdName = bird.BirdMyanmarName,
                Id = bird.Id,
                Desp = bird.Description,
                Photourl = $"https://burma-project-ideas.vercle.app/{bird.ImagePath}"

            };
            return item;
        }
    }
}
