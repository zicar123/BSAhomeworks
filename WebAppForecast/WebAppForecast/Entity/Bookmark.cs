using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace WebAppForecast.Entity
{
    public class Bookmark
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BookmarkId { get; set; }

        public string Title { get; set; }
    }
}