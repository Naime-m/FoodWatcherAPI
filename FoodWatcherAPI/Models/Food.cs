using System.ComponentModel.DataAnnotations;

namespace FoodWatcherAPI.Models
{
    public class Food
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime Added { get; set; } = DateTime.Now;

        [DataType(DataType.Date)]
        public DateTime ExpirationDate { get; set; }

        public Category Category { get; set; }
    }

    public enum Category
    {
        Grain,
        Vegetable,
        Protein,
        Dairy,
        Fruit,
        Other
    }

}
