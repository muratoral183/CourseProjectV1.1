using System.ComponentModel.DataAnnotations.Schema;

namespace CourseProject.DAL.Entity
{
    public class Product
    {
        public int ProductId { get; set; }
        public string? ProductUrl { get; set; }
        public string? Name { get; set; }
        public double? Price { get; set; }
        public string? Qunit { get; set; }
        public bool IsStandOut { get; set; }
        public int IsProductType { get; set; }
        [NotMapped]

        public int? AmbSayisi { get; set; }

        [NotMapped]
        public IFormFile? File { get; set; }
    }
}
