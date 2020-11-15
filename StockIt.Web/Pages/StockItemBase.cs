using Microsoft.AspNetCore.Components;
using StockIt.Core.Repositories.Location;
using StockIt.Core.Repositories.Product;
using StockIt.Web.Data;
using StockIt.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StockIt.Web.Pages
{
    public class StockItemBase : ComponentBase
    {
        [Inject]
        public IProductDataService ProductDataService { get; set; }

        [Inject]
        public ILocationDataService LocationDataService { get; set; }

        protected List<ProductStockItem> productStockItems = new List<ProductStockItem>();

        protected string barcode;

        public string locationItem1;
        public string locationItem2;
        protected bool saved = false;
        protected string message;
        protected bool isDisabled = true;
        protected string statusClass;
        protected StockModel stockModel = new StockModel();

        protected List<StockItActionType> stockItActionTypes = StockItConstants.ActionTypes;
        public List<Location> Locations { get; set; } = new List<Location>();

        protected override async Task OnInitializedAsync()
        {
            Locations = new List<Location>
            {
                new Location
                {
                    Name = "hh"
                },
                new Location
                {
                    Name = "gg"
                }
            };
            ///Locations = await LocationDataService.GetAllAsync("rrhome");
        }

        protected async Task HandleValidSubmit()
        {
            stockModel.Location1 = Locations.FirstOrDefault(x => x.Id.Equals(locationItem1, StringComparison.OrdinalIgnoreCase));
            stockModel.Location2 = Locations.FirstOrDefault(x => x.Id.Equals(locationItem2, StringComparison.OrdinalIgnoreCase));
            List<ProductStock> storeProducts = new List<ProductStock>();

            stockModel
                .Barcodes
                .Distinct()
                .ToList()
                .ForEach(x =>
                {
                    var total = stockModel.Barcodes.FindAll(y => y.Equals(x, StringComparison.OrdinalIgnoreCase)).Count;
                    var product = new ProductStock();
                    product.Barcode = x;

                    if (stockModel.ActionType.Name.Equals("Move Stock"))
                    {
                        product.RemoveItems.Add(new ProductLocation
                        {
                            LocationId = locationItem1,
                            Quantity = total
                        });
                    }

                    product.AddItems.Add(new ProductLocation
                    {
                        LocationId = stockModel.Location1.Id,
                        Quantity = total
                    });

                    storeProducts.Add(product);
                });

            await ProductDataService.UpdateStockAsync(storeProducts, "rrhome");
        }

        protected async Task SetActionType(int actionId)
        {
            var result = stockItActionTypes.FirstOrDefault(x => x.Id == actionId);

            if (result != null)
            {
                if (result.Name.Equals("Move Stock", StringComparison.OrdinalIgnoreCase))
                {
                    isDisabled = false;
                }
                else
                {
                    isDisabled = true;
                }

                stockModel.ActionType = result;
            }
        }

        protected async Task DeleteBarcodeItem(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var productStockItem = productStockItems.FirstOrDefault(x => x.Id.Equals(id, StringComparison.OrdinalIgnoreCase));

                if(productStockItem != null)
                { 
                    productStockItems.Remove(productStockItem);
                }
            }
        }

        protected async Task AddBarcodeItem()
        {
            if (!string.IsNullOrEmpty(barcode))
            {
                productStockItems.Add(new ProductStockItem(barcode));
            }

            barcode = string.Empty;
        }
    }
}
