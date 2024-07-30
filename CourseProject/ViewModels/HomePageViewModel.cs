using CourseProject.DAL.Entity;

namespace CourseProject.ViewModels


{
    public class HomePageViewModel
    {
        public IEnumerable<Carousel> Carousel { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Category> CategoryList { get; set; }
        public IEnumerable<CustomBanner> CustomBanner { get; set; }
        public IEnumerable<Feedback> Feedback { get; set; }
        public IEnumerable<Product> Product { get; set; }

        public double? MinPrice { get; set; }  // Min fiyat
        public double? MaxPrice { get; set; }  // Max fiyat
        public int? ProductCount { get; set; }
        public int CategoryType { get; set; }
        public int? CategoryStatus { get; set; }

    }
}
