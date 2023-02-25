namespace oscars_games.Data;

public class Category
{
    public Category() { }

    public Category(Categories categories, string slug)
    {
        var category = categories.Find(x => x.Slug == slug);
        Id = category.Id;
        Nominees = category.Nominees;
        Name = category.Name;
        Slug = slug;
    }

    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public List<Nominee> Nominees { get; set; }
}
