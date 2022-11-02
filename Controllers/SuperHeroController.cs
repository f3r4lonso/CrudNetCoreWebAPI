using CRUDWebAPI.Model;
using CRUDWebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUDWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        // testing
        //public static List<SuperHero> heroes = new()
        //    {
        //       new SuperHero
        //       {
        //           Id = 1,
        //           FirstName = "Fernando",
        //           LastName = "Alonso",
        //           Name="Morry",
        //           Place = "Mendoza"
        //       },
        //       new SuperHero
        //       {
        //           Id=2,
        //           FirstName = "Mariana",
        //           LastName = "Sanchez",
        //           Name= "Mappy",
        //           Place = "Mappy Land"
        //       }
        //};

        private readonly ICrudSuperHeroService heroService;
        // private readonly DataContext context;
        public SuperHeroController(ICrudSuperHeroService service)
        {
            //this.context = dataContext;
            this.heroService = service;
        }

        [Route("GetAllHeroes()")]
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeroes()
        {
            var heros = heroService.GetAll();

            return Ok(await heros);
        }

        [Route("GetHeroById(int heroId)")]
        [HttpGet]
        public async Task<ActionResult<SuperHero>> GetHeroById(int heroId)
        {
            //var hero = heroes.Where(x => x.Id.Equals(heroId)).FirstOrDefault();
            //var hero = heroes.Find(x => x.Id == heroId);
            var dbHero = await heroService.GetHeroById(heroId);
            return Ok(dbHero);
        }

        [Route("UpdateHero(SuperHero updatedHero)")]
        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero updatedHero)
        {
            var newHero = await heroService.UpdateHero(updatedHero);
            return Ok(newHero);
        }

        [Route("AddHero(SuperHero hero)")]
        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await heroService.InsertNewHero(hero);
            return Ok(await heroService.GetAll());
        }

        [Route("DeleteHeroById(int id)")]
        [HttpDelete]
        public async Task<ActionResult<SuperHero>> DeleteHeroById(int id)
        {
            await heroService.DeleteHero(id);

            return Ok(await heroService.GetAll());
        }
    }
}
