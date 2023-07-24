using GymDB.Models;
using Microsoft.EntityFrameworkCore;

namespace GymDB.Repositories
{
    public class PeopleRepository
    {
        private GymContext _context;

        public PeopleRepository(GymContext context)
        {
            _context = context;
        }

        public async Task<People> GetPeopleById(long id)
        {
            return await _context.Peoples.FirstOrDefaultAsync(e => e.Id.Equals(id));
        }
        public async Task<object> AddPeople(People people)
        {
            var exists = await _context.Peoples.AnyAsync(e => e.Name.Equals(people.Name));
            if (exists)
                return null;
            await _context.Peoples.AddAsync(people);
            await _context.SaveChangesAsync();
            return new();
        }
        public async Task<People> UpdatePeople(People people)
        {
            var result = await _context.Peoples.FirstOrDefaultAsync(e => e.Id.Equals(people.Id));
            if (result == null)
            {
                result.Id = people.Id;
                result.Subscription = people.Subscription;
                result.Customer = people.Customer;
                result.Worker = people.Worker;

                await _context.SaveChangesAsync();
            }
            return result;
            


        }
        public async Task<People> DeletePeople(int id)
        {
            var result = await _context.Peoples.FirstOrDefaultAsync(e => e.Id.Equals(id));
            if (result == null)
                return null;

            _context.Peoples.Remove(result);
            await _context.SaveChangesAsync();
            return result;
        }
        
    }
}
