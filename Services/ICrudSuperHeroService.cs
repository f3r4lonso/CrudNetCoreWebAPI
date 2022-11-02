using CRUDWebAPI.Model;

namespace CRUDWebAPI.Services
{
    public interface ICrudSuperHeroService
    {
        public Task<List<SuperHero>> GetAll();
        public Task<SuperHero> GetHeroById(int id);
        public Task<SuperHero> UpdateHero(SuperHero hero);
        public Task<List<SuperHero>> InsertNewHero(SuperHero newHero);
        public Task<List<SuperHero>> DeleteHero(int deathHeroId);
    }
}