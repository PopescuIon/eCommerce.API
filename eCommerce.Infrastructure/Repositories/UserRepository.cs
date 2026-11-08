using Dapper;
using eCommerce.Core.DTO;
using eCommerce.Core.Entities;
using eCommerce.Core.RepositoriesContracts;
using eCommerce.Infrastructure.DbContext;

namespace eCommerce.Infrastructure.Repositories
{
    internal class UserRepository : IUsersRepository
    {
        private readonly DapperDbContext _dbContext;

        public UserRepository(DapperDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<ApplicationUser?> AddUser(ApplicationUser user)
        {
            user.UserId = Guid.NewGuid();

            var query = @"INSERT INTO public.""Users"" (""Userid"", ""Email"", ""Password"", ""PersonName"", ""Gender"") 
                        VALUES (@UserId, @Email, @Password, @PersonName, @Gender)";
            var rowCountAffected = await _dbContext.DbConnection.ExecuteAsync(query, user);
            if (rowCountAffected > 0)
            {
                return user;
            }
            else
            {
                return null;
            }


        }

        public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
{
    var query = @"SELECT ""Userid"" AS UserId, ""Email"", ""Password"", ""PersonName"", ""Gender""
        FROM public.""Users""
        WHERE ""Email"" = @Email AND ""Password"" = @Password";

   
    var user = await _dbContext.DbConnection.QueryFirstOrDefaultAsync<ApplicationUser>(
        query, 
        new { Email = email, Password = password }
    );

    return user;
}
    }
}