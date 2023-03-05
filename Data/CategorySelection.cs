using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace oscars_games.Data
{
    public class CategorySelection
    {
        [Key]
        public Guid Uid { get; set; } = Guid.NewGuid();
        public string UserId { get; set; } = null!;
        public int CategoryId { get; set; }
        public int Selection { get; set; }
    }
}
