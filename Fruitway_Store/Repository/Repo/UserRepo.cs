using Fruitway_Store.Data;
using Fruitway_Store.Repository.IRepo;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Fruitway_Store.Repository.Repo
{
    public class UserRepo:Iuser
    {
        private readonly ApplicationDbcontext dbcontext;

        public UserRepo(ApplicationDbcontext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task<IEnumerable<IdentityUser>> GetALLUsers()
        {
            return await dbcontext.Users.ToListAsync();
        }
    }
}
