using Microsoft.EntityFrameworkCore;
using oscars_games.Interfaces;

namespace oscars_games.Data;

public class UserSelectionRepository : IUserSelectionRepository
{
    private readonly CosmosDbContext _dbContext;

    public UserSelectionRepository(CosmosDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task Add(CategorySelection categorySelection)
    {
        _dbContext.UserSelections.Add(categorySelection);
        await _dbContext.SaveChangesAsync();
    }

    public async Task<CategorySelection?> Get(string userId, int categoryId)
    {
        return await _dbContext.UserSelections.FirstOrDefaultAsync(
            x => x.UserId == userId && x.CategoryId == categoryId
        );
    }

    public async Task<List<CategorySelection>> GetAll()
    {
        return await _dbContext.UserSelections.ToListAsync();
    }

    public async Task Update(CategorySelection categorySelection)
    {
        _dbContext.UserSelections.Update(categorySelection);
        await _dbContext.SaveChangesAsync();
    }
}
