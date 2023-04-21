using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Data;
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
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    public class CategoryViewModel : BaseViewModel
    {
        #region ATRIBUTES
        private ObservableCollection<CategoryModel> categories;
        private readonly CategoryService categoryService;
        #endregion
        #region PROPERTIES
        public ObservableCollection<CategoryModel> Categories
        {
            get { return categories; }
            set { categories = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR
        public CategoryViewModel()
        {
            Title = "Categorías";
            Categories = new ObservableCollection<CategoryModel>();
            categoryService = new CategoryService();
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
            catch (Exception ex) { throw; }

            // Si todo sale bien
            IsContentViewVisible = true; // Muestra el contenido de la pagina
            IsRefreshing = false;
        }
        #endregion
        #region COMMANDS
        public ICommand OnRefreshPageCommand => new Command(async () => await LoadData());
        public ICommand OnCategoryClickedCommand => new Command<CategoryModel>(async (p) => 
        {
            var model = JsonConvert.SerializeObject(p);
            var modelEncoded = HttpUtility.UrlEncode(model);
            await Shell.Current.GoToAsync($"{nameof(CategoryProductPage)}?{nameof(CategoryProductViewModel.CategoryJson)}={modelEncoded}");
        });
        #endregion
    }
}
