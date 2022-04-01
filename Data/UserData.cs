using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace synthy.Data;

public class UserData : IdentityDbContext
{
    public UserData(DbContextOptions options) : base(options)
    {
        
    }
}