using System.ComponentModel.DataAnnotations;

namespace RepositoryPatternExample.Models.Entities
{
    public class BlogDataModel
    {
        [Key]
        public long BlogId { get; set; }
        public string BlogTitle { get; set; }
        public string BlogAuthor { get; set; }
        public string BlogContent { get; set; }
    }
}
