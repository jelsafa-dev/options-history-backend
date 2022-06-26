using System.ComponentModel.DataAnnotations.Schema;

namespace OptionsHistory.API.Models
{
    public class Option
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int? StockId { get; set; }
        [ForeignKey("StockId")]
        public Stock? Stock { get; set; }
        public Option() { }
        public Option(int id, string name, Stock stock)
        {
            Id = id;
            Name = name;
            Stock = stock;
        }
    }
}
