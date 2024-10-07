using Microsoft.AspNetCore.Identity;

namespace Fruitway_Store.Repository.IRepo
{
    public interface Iuser
    {
        Task<IEnumerable<IdentityUser>> GetALLUsers();
    }
}
