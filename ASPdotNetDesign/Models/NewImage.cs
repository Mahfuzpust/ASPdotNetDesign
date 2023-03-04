using System.ComponentModel.DataAnnotations;

namespace ASPdotNetDesign.Models
{
    public class NewImage
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
    }
}
