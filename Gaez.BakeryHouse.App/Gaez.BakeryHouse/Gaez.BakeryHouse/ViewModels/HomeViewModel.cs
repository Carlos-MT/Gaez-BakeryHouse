using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Data;
using Gaez.BakeryHouse.Services;
using Gaez.BakeryHouse.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region ATRIBUTES
        #endregion
        #region PROPERTIES
        #endregion
        #region CONSTRUCTOR
        public HomeViewModel()
        { 
        }
        #endregion
        #region METHODS
        public async Task LoadData()
        {
            base.OnAppering();

            try
            {
                await ProductData.LoadData();
            }
            catch(Exception ex)
            {
                IsContentViewVisible = false;
                IsRefreshing = false;
            }

            // Si todo sale bien
            IsContentViewVisible = true; // Muestra el contenido de la pagina
            IsRefreshing = false;
        }
        #endregion
        #region COMMANDS
        public ICommand OnRefreshPageCommand => new Command(async () => await LoadData());
        #endregion
    }
}
