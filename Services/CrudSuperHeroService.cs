using CRUDWebAPI.DataBase;
using CRUDWebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace CRUDWebAPI.Services
{
    public class CrudSuperHeroService : ICrudSuperHeroService
    {
        private readonly DataContext context;

        public CrudSuperHeroService(DataContext dbContext)
        {
            this.context = dbContext;
        }
        public async Task<List<SuperHero>> GetAll()
        {
            try
            {
                var heroes = await context.SuperHeroes.ToListAsync();

                return heroes;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SuperHero> GetHeroById(int id)
        {
            try
            {
                var hero = await context.SuperHeroes.Where(x => x.Id == id).FirstOrDefaultAsync();

                return hero;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<SuperHero> UpdateHero(SuperHero hero)
        {
            try
            {
                var heroForUpdate = await GetHeroById(hero.Id);

                if (heroForUpdate == null)
                {
                    throw new Exception("hero not found");
                }
                else
                {
                    heroForUpdate.FirstName = hero.FirstName;
                    heroForUpdate.LastName = hero.LastName;
                    heroForUpdate.Name = hero.Name;
                    heroForUpdate.Place = hero.Place;

                    await context.SaveChangesAsync();
                }

                var updatedHero = await GetHeroById(hero.Id);

                return updatedHero;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SuperHero>> InsertNewHero(SuperHero newHero)
        {
            try
            {
                await context.SuperHeroes.AddAsync(newHero);
                await context.SaveChangesAsync();
                return await GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<SuperHero>> DeleteHero(int deathHeroId)
        {
            try
            {
                var deatHero = await GetHeroById(deathHeroId);

                if (deatHero == null)
                {
                    throw new Exception("Hero Not Found");
                }

                context.Remove(deatHero);

                await context.SaveChangesAsync();

                return await GetAll();
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}

