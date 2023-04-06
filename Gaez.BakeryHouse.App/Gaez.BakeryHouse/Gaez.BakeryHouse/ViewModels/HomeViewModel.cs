using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Handlers;
using Gaez.BakeryHouse.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region ATTRIBUTES
        private bool viewIsVisible;
        private bool refreshIsVisible;
        #endregion
        #region PROPERTIES
        public bool ViewIsVisible
        {
            get { return viewIsVisible; }
            set { viewIsVisible = value; OnPropertyChanged(); }
        }
        public bool RefreshIsVisible
        {
            get { return refreshIsVisible; }
            set { refreshIsVisible = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR

        #endregion
        #region METHODS

        #endregion
        #region COMMANDS
        public ICommand OnRefreshCommand => new Command(async () =>
        {
        });
        #endregion
    }
}
