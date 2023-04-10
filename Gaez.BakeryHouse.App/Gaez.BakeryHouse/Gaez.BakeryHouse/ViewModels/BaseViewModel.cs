using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Gaez.BakeryHouse.ViewModels
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        #region ATTRIBUTES
        private bool isContentViewVisible;
        private bool isRefreshVisible;
        private bool isScrollEnable;
        private bool isSearchViewVisible;
        #endregion
        #region PROPERTIES
        public bool IsContentViewVisible
        {
            get { return isContentViewVisible; }
            set { isContentViewVisible = value; OnPropertyChanged(); }
        }
        public bool IsRefreshVisible
        {
            get { return isRefreshVisible; }
            set { isRefreshVisible = value; OnPropertyChanged(); }
        }
        public bool IsScrollEnable
        {
            get { return isScrollEnable; }
            set { isScrollEnable = value; OnPropertyChanged(); }
        }
        public bool IsSearchViewVisible
        {
            get { return isSearchViewVisible; }
            set { isSearchViewVisible = value; OnPropertyChanged(); }
        }
        #endregion
        #region METHODS
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public ObservableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }
        protected void OnAppering()
        {
            // Al aparecer la pagina
            IsRefreshVisible = true; // Muetra el RefreshView
            IsScrollEnable = true; // Habilita el Scroll
            IsContentViewVisible = false; // Oculta el contenido de la pagina
            IsSearchViewVisible = false; // Oculta la pagina de busqueda
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;
        
    }
}
