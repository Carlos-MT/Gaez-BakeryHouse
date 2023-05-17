using Gaez.BakeryHouse.Data;
using Gaez.BakeryHouse.Models;
using Gaez.BakeryHouse.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;

namespace Gaez.BakeryHouse.ViewModels
{
    public class FavoriteViewModel : BaseViewModel
    {
        #region ATTRIBUTES
        ObservableCollection<ProductModel> favoriteProducts;
        readonly ProductService productService;
        #endregion
        #region PROPERTIES
        public ObservableCollection<ProductModel> FavoriteProducts
        {
            get { return favoriteProducts; }
            set { favoriteProducts = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR
        public FavoriteViewModel()
        {
            productService = new ProductService();
            FavoriteProducts = new ObservableCollection<ProductModel>();
            Title = "Favoritos";
        }
        #endregion
        #region METHODS
        public async Task LoadData()
        {
            //base.OnAppering();
            CurrentState = LayoutState.Loading;

            try
            {
                FavoriteProducts.Clear();
                FavoriteProducts = Convert<ProductModel>(await productService.GetAllFavoriteProducts(3));
            }
            catch (Exception ex)
            {
                CurrentState = LayoutState.Error;
            }

            if (CurrentState != LayoutState.Error)
                CurrentState = LayoutState.Success;

            //IsRefreshing = false;
        }
        #endregion
    }
}
