using System.ComponentModel.DataAnnotations;

namespace StockIt.Core.Repositories.Stock
{
    public enum StockAction
    {
        [Display(Name = "Add to stock")]
        AddToStock,
        [Display(Name = "Remove from stock")]
        RemoveFromStock
    }
}
