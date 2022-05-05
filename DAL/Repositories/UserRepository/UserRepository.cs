using DAL.Data;
using DAL.Models;
using DAL.Repositories.UserRepository;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repository.Repositories
{
    //TODO: Create exeptions or answer codes to comfirm Task operations
    public class UserRepository : IUserRepository
    {
        private Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task Create(User item)
        {
            if (!_context.User.Any(u => u.Login == item.Login))
            {
                await _context.User.AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Delete(int id)
        {
            var user =  await _context.User.FirstOrDefaultAsync(u => u.Id == id);

            if (user is not null)
            {
                _context.User.Remove(user);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<User> Get(int id)
        {
            return await _context.User.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<User>> GetAll(int skip, int take)
        {
            return await _context.User.Skip(skip).Take(take).ToListAsync();
        }

        public async Task<User> GetUserByName(string login)
        {
            return await _context.User.FirstOrDefaultAsync(user => user.Login == login);
        }

        public async Task Update(User user)
        {
            _context.User.Update(user);
            await _context.SaveChangesAsync();
        }
    }
}
