using Gaez.BakeryHouse.Data;
using Gaez.BakeryHouse.Models;
using Gaez.BakeryHouse.ViewModels;
using Gaez.BakeryHouse.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.Handlers
{
    public class ProductSearchHandler : SearchHandler
    {
        IList<ProductModel> searchResults;

        protected override void OnQueryChanged(string oldValue, string newValue)
        {
            base.OnQueryChanged(oldValue, newValue);

            if (string.IsNullOrWhiteSpace(newValue))
            {
                ItemsSource = null;
            }
            else
            {
                searchResults = ProductData.Products
                    .Where(p => p.ProductName
                    .ToLower()
                    .Contains(newValue.ToLower()))
                    .ToList();

                ItemsSource = searchResults;
            }
        }

        protected override async void OnItemSelected(object item)
        {
            base.OnItemSelected(item);

            var model = JsonConvert.SerializeObject((ProductModel)item);
            var modelEncoded = HttpUtility.UrlEncode(model);
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailViewModel.ProductJson)}={modelEncoded}");
        }
    }
}
