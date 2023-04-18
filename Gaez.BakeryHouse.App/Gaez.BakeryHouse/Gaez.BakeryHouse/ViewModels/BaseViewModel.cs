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
        private bool isContentViewVisible; // Indica si mostrar o no el contenido de una pagina
        private bool isRefreshingVisible; // Indica si mostrar o no el RefreshView
        private string queryText; // Propiedad de Texto a buscar
        private string title; // Indica el itulo de la pagina
        #endregion
        #region PROPERTIES
        public bool IsContentViewVisible
        {
            get { return isContentViewVisible; }
            set { isContentViewVisible = value; OnPropertyChanged(); }
        }
        public bool IsRefreshingVisible
        {
            get { return isRefreshingVisible; }
            set { isRefreshingVisible = value; OnPropertyChanged(); }
        }
        public string QueryText
        {
            get { return queryText; }
            set { queryText = value; OnPropertyChanged(); }
        }
        public string Title
        {
            get { return title; }
            set {  title = value; OnPropertyChanged(); }  
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
            IsRefreshingVisible = false; // Al cargar cualquier pagina, no muestres el RefrehView
            IsContentViewVisible = false; // Al cargar cualquier pagina, no muestres su contenido
            QueryText = string.Empty; // Texto vacio al cargar cualquier pagina
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;     
    }
}
