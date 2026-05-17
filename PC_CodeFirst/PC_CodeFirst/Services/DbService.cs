using PC_CodeFirst.Data;

namespace PC_CodeFirst.Services;

public class DbService : IDbService
{
    private readonly AppDbContext _dbContext;
    
    public DbService(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}