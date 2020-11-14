using System.ComponentModel.DataAnnotations;

namespace StockIt.Web.ViewModels
{
    public class StockItActionType
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public StockItActionType(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}