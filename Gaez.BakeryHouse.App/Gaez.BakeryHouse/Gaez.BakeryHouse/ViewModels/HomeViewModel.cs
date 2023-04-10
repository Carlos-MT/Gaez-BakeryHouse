using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Classes;
using Gaez.BakeryHouse.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        #region ATTRIBUTES
        private readonly ProductService _productService;
        private ObservableCollection<ProductModel> _productCollection;
        private ObservableCollection<ProductModel> _auxProductCollection;
        #endregion
        #region PROPERTIES
        public ObservableCollection<ProductModel> ProductCollection
        {
            get { return _productCollection; }
            set { _productCollection = value; OnPropertyChanged(); }
        }
        private ObservableCollection<ProductModel> AuxProductCollection
        {
            get { return _auxProductCollection; }
            set { _auxProductCollection = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR
        public HomeViewModel()
        {
            _productService = new ProductService();
            ProductCollection = new ObservableCollection<ProductModel>();
            AuxProductCollection = new ObservableCollection<ProductModel>();
        }
        #endregion
        #region METHODS
        public async void LoadData()
        {
            base.OnAppering();

            try
            {
                ProductCollection.Clear();
                AuxProductCollection.Clear();
                ProductCollection = Convert<ProductModel>(await _productService.GetAllProducts());
                AuxProductCollection = Convert<ProductModel>(ProductCollection);
            }
            catch(Exception ex) 
            {
                // Si ocurre un error
                IsRefreshVisible = false; // Oculta el RefreshView
                IsContentViewVisible = false; // Oculta el contenido de la pagina 
                throw;
            }

            // Si todo sale bien
            IsRefreshVisible = false; // Oculta el RefreshView
            IsContentViewVisible = true; // Muestra el contenido de la pagina
        }
        #endregion
        #region COMMANDS
        public ICommand OnRefreshCommand => new Command(() => LoadData());
        public ICommand OnSearchCommand => new Command<TextChangedEventArgs>((e) =>
        {
            var inputText = e.NewTextValue; // texto a buscar

            if(string.IsNullOrWhiteSpace(inputText))
            {
               // Si la cadena de texto es nula o contiene espacios en blanco
                IsScrollEnable = true; // Habilita el Scroll
                IsContentViewVisible = true; // Muestra la pagina de contenido
                IsSearchViewVisible = false; // Oculta la pagina de busqueda
                ProductCollection.Clear(); // Limpia la lista
                ProductCollection = Convert<ProductModel>(AuxProductCollection); // Poblala con la lista auxiliar
            }
            else
            {
                // De lo contrario
                IsScrollEnable = false; // Deshabilita el scroll
                IsContentViewVisible = false; // Oculta la pagina de contenido
                IsSearchViewVisible = true; // Muestra la pagina de busqueda
                ProductCollection = Convert<ProductModel>(AuxProductCollection.Where(p => p.ProductName.ToLower().Contains(inputText.ToLower())).ToList()); // Filtra la lista
            }
        });
        #endregion
    }
}
