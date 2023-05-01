using Gaez.BakeryHouse.Data;
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
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        readonly CategoryService categoryService;
        IList<CategoryModel> categories;
        public IList<CategoryModel> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(); }
        }

        #region CONSTRUCTOR
        public CategoryViewModel()
        {
            Title = "Categorías";
            categoryService = new CategoryService();
            categories = new ObservableCollection<CategoryModel>();
        }
        #endregion
        #region METHODS
        public async Task LoadData()
        {
            base.OnAppering();
            try
            {
                Categories.Clear();
                Categories = Convert<CategoryModel>(await categoryService.GetAllCategories());
            }
            catch (Exception ex)
            {
                CurrentState = LayoutState.Error;
            }

            if (CurrentState != LayoutState.Error)
                CurrentState = LayoutState.Success;

            IsRefreshing = false;
        }
        #endregion
        #region COMMANDS
        public ICommand OnRefreshCommand => new Command(async () => await LoadData());
        public ICommand OnCategoryClickedCommand => new Command<CategoryModel>(async (p) => 
        {
            var model = JsonConvert.SerializeObject(p);
            var modelEncoded = HttpUtility.UrlEncode(model);
            await Shell.Current.GoToAsync($"{nameof(CategoryProductPage)}?{nameof(CategoryProductViewModel.CategoryJson)}={modelEncoded}");
        });
        #endregion
    }
}
