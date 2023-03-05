using oscars_games.Data;

namespace oscars_games.Interfaces;

public interface IUserSelectionRepository
{
    Task Add(CategorySelection categorySelection);
    Task<CategorySelection?> Get(string userId, int categoryId);
    Task<List<CategorySelection>> GetAll();
    Task Update(CategorySelection categorySelection);
}
