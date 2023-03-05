namespace oscars_games.Data;

public class Settings
{
    public string CutOffDate { get; set; }
    public DateTime CutoffDate
    {
        get { return DateTime.Parse(CutOffDate); }
    }
}
