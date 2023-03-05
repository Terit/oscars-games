using oscars_games.Interfaces;

namespace oscars_games.Data;

public class CategoryService : ICategoryService
{
    private readonly IUserSelectionRepository _userSelectionRepository;

    public CategoryService(IUserSelectionRepository userSelectionRepository)
    {
        _userSelectionRepository = userSelectionRepository;
    }

    public Task<List<CategorySelection>> GetAllUserSelections() =>
        _userSelectionRepository.GetAll();

    public async Task<CategorySelection?> GetUserSelection(string userId, int categoryId)
    {
        return await _userSelectionRepository.Get(userId, categoryId);
    }

    public async Task SaveUserSelection(string userId, int categoryId, int nomineeId)
    {
        var selection = new CategorySelection()
        {
            UserId = userId,
            CategoryId = categoryId,
            Selection = nomineeId
        };

        await _userSelectionRepository.Add(selection);
    }

    public async Task SaveUserSelection(CategorySelection selection)
    {
        await _userSelectionRepository.Update(selection);
    }
}
