using oscars_games.Data;

namespace oscars_games.Interfaces;

public interface ICategoryService
{
    Task<CategorySelection?> GetUserSelection(string userId, int categoryId);
    Task<List<CategorySelection>> GetAllUserSelections();

    Task SaveUserSelection(string userId, int categoryId, int nomineeId);
}
