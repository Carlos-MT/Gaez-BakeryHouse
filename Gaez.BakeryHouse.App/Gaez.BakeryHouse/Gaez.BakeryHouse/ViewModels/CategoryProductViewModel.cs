using Gaez.BakeryHouse.Models;
using Gaez.BakeryHouse.Services;
using Gaez.BakeryHouse.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    [QueryProperty(nameof(CategoryJson), nameof(CategoryJson))]
    public class CategoryProductViewModel : BaseViewModel
    {
        #region ATTRIBUTES
        string categoryJson;
        CategoryModel category;
        ObservableCollection<ProductModel> products;
        readonly ProductService productService;
        #endregion
        #region PROPERTIES
        public string CategoryJson
        {
            get { return categoryJson; }
            set { categoryJson = value; OnPropertyChanged(); }
        }
        public CategoryModel Category
        {
            get { return category; }
            set { category = value; OnPropertyChanged(); }
        }
        public ObservableCollection<ProductModel> Products
        {
            get { return products; }
            set { products = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR
        public CategoryProductViewModel()
        {
            productService = new ProductService();
            Products = new ObservableCollection<ProductModel>();
        }
        #endregion
        #region METHODS
        public async Task LoadData()
        {
            base.OnAppering();
            try
            {
                if (Category == null)
                    GetCategoryJsonParameter();

                Products.Clear();
                Products = Convert<ProductModel>(await productService.GetProductsByCategory(Category.CategoryId));
                Title = Category.CategoryName;
            }
            catch (Exception ex)
            {
                CurrentState = LayoutState.Error;
            }

            if (CurrentState != LayoutState.Error)
                CurrentState = LayoutState.Success;


            IsRefreshing = false;
        }
        private void GetCategoryJsonParameter()
        {
            var category = JsonConvert.DeserializeObject<CategoryModel>(CategoryJson);
            Category = category;
        }
        #endregion
        #region COMMANDS
        public ICommand OnRefreshCommand => new Command(async () => await LoadData());
        public ICommand OnProductClickedCommand => new Command<ProductModel>(async (p) =>
        {
            var model = JsonConvert.SerializeObject((ProductModel)p);
            var modelEncoded = HttpUtility.UrlEncode(model);
            await Shell.Current.GoToAsync($"{nameof(ProductDetailPage)}?{nameof(ProductDetailViewModel.ProductJson)}={modelEncoded}");
        });
        #endregion
    }
}
