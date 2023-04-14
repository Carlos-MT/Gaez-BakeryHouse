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
        private bool isSearchEnable;
        private bool isButtonEnabled;
        private bool isRefreshEnable;
        private bool isCommentsViewVisible;
        private string inputText;
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
        public bool IsButtonEnabled
        {
            get { return isButtonEnabled; }
            set { isButtonEnabled = value; OnPropertyChanged(); }
        }
        public string InputText
        {
            get { return inputText; }
            set { inputText = value; OnPropertyChanged(); }
        }
        public bool IsRefreshEnable
        {
            get { return isRefreshEnable; }
            set { isRefreshEnable = value; OnPropertyChanged(); }
        }
        public bool IsSearchEnable
        {
            get { return isSearchEnable; }
            set { isSearchEnable = value; OnPropertyChanged(); }
        }
        public bool IsCommentsViewVisible
        {
            get { return isCommentsViewVisible; }
            set { isCommentsViewVisible = value; OnPropertyChanged(); }
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
            InputText = ""; // Texto de busqueda vacio
            IsRefreshEnable = true; // Refresh habilitado
            IsSearchEnable = false; // Deshabilitar el SearchBar
            IsCommentsViewVisible = false; // Oculta la pagina de comentarios
            IsButtonEnabled = true; // Habilitar los botones
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;     
    }
}
