namespace OptionsHistory.API.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public Stock() { }
        public Stock(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
