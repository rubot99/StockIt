using System.ComponentModel.DataAnnotations;

namespace StockIt.Web.ViewModels
{
    public class StockItActionType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StockItActionItem ActionTypeItem { get; set; }

        public StockItActionType(int id, StockItActionItem item, string name)
        {
            Id = id;
            Name = name;
            ActionTypeItem = item;
        }

        public StockItActionType(int id, StockItActionItem item)
        {
            Id = id;
            Name = item.ToString();
            ActionTypeItem = item;
        }

        public StockItActionType()
        {
        }
    }
}