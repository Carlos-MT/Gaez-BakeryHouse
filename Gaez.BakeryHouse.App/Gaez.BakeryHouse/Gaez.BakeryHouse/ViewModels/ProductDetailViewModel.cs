using Gaez.BakeryHouse.Models;
using Gaez.BakeryHouse.Services;
using Newtonsoft.Json;
using Plugin.Toasts;
using System;
using System.Collections.ObjectModel;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Xml.Linq;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    [QueryProperty(nameof(ProductJson), nameof(ProductJson))]
    public class ProductDetailViewModel : BaseViewModel
    {
        #region ATRIBUTES
        readonly CommentService _commentService;
        string productJson;
        ObservableCollection<CommentModel> _onlyThreeComments;
        ObservableCollection<CommentModel> _comments;
        ProductModel product;
        double _productRating;
        double _totalValorations;
        int _starCounter = 1;
        #endregion
        #region PROPERTIES
        public int StarCounter
        {
            get { return _starCounter; }
            set { _starCounter = value; OnPropertyChanged(); }
        }
        public string ProductJson
        {
            get { return productJson; }
            set { productJson = value; OnPropertyChanged(); }
        }
        public ProductModel Product
        {
            get { return product; }
            set { product = value; OnPropertyChanged(); }
        }
        public double ProductRating
        {
            get { return _productRating; }
            set { _productRating = value; OnPropertyChanged(); }
        }
        public double TotalValorations
        {
            get { return _totalValorations; }
            set { _totalValorations = value; OnPropertyChanged(); }
        }
        public ObservableCollection<CommentModel> OnlyThreeComments
        {
            get { return _onlyThreeComments; }
            set { _onlyThreeComments = value; OnPropertyChanged(); }
        }
        public ObservableCollection<CommentModel> Comments
        {
            get { return _comments; }
            set { _comments = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR
        public ProductDetailViewModel()
        {
            Title = "Producto";
            OnlyThreeComments = new ObservableCollection<CommentModel>();
            Comments = new ObservableCollection<CommentModel>();
            _commentService = new CommentService();
        }
        #endregion
        #region METHODS
        public async Task LoadData()
        {
            base.OnAppering();
            try
            {
                if (Product == null)
                    GetProductJsonParameter();

                Comments.Clear();
                //Comments = Convert<CommentModel>(await _commentService.GetAllCommentsForProduct(Product.ProductCode));
                //LoadStars();
            }
            catch (Exception ex)
            {
                CurrentState = LayoutState.Error;
            }

            if (CurrentState != LayoutState.Error)
                CurrentState = LayoutState.Success;

            IsRefreshing = false;
        }
        private void LoadStars()
        {
            OnlyThreeComments = new ObservableCollection<CommentModel>(); // Lista para guardar solo 3 comentarios
            TotalValorations = 0;

            // Accedo a cada objeto
            for (int i = 0; i < Comments.Count; i++)
            {
                // Solo se guardan tres comentarios
                if (i < 3)
                    OnlyThreeComments.Add(Comments[i]);

                TotalValorations += Comments[i].Valoration;
            }

            ProductRating = ((double)TotalValorations) / ((double)Comments.Count);

            if (double.IsNaN(ProductRating))
                ProductRating = 0.0;
        }

        private void GetProductJsonParameter()
        {
            var product = JsonConvert.DeserializeObject<ProductModel>(ProductJson);
            Product = product;
        }
        #endregion
        #region COMMANDS
        public ICommand OnRefreshCommand => new Command(async () => await LoadData());
        public ICommand OnCommetClikedCommand => new Command(async () =>
        {
        });

        public ICommand OnSelectStarCommand => new Command<int>((p) => StarCounter = p);
        #endregion
    }
}
