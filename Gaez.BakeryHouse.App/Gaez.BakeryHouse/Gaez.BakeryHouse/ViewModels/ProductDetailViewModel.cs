using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Fonts;
using Gaez.BakeryHouse.Interfaces;
using Gaez.BakeryHouse.Models;
using Gaez.BakeryHouse.Services;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    [QueryProperty(nameof(ProductJson), nameof(ProductJson))]
    public class ProductDetailViewModel : BaseViewModel
    {
        #region ATRIBUTES
        private string productJson;
        private ProductModel product;
        private ObservableCollection<RatingModel> ratingBar;
        private ObservableCollection<CommentModel> comments;
        private readonly CommentService commentService;
        private int ratingCounter;
        private double productRating;
        private ObservableCollection<RatingModel> productRatingBar;
        private ObservableCollection<CommentModel> onlyThreeComments;
        #endregion
        #region PROPERTIES
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
        public ObservableCollection<RatingModel> RatingBar
        {
            get { return ratingBar; }
            set { ratingBar = value; OnPropertyChanged(); }
        }
        public ObservableCollection<CommentModel> Comments
        {
            get { return comments; }
            set {  comments = value; OnPropertyChanged(); }
        }
        public int RatingCounter
        {
            get { return ratingCounter; }
            set { ratingCounter = value; OnPropertyChanged(); }
        }
        public double ProductRating
        {
            get { return productRating; }
            set { productRating = value; OnPropertyChanged(); }
        }
        public ObservableCollection<RatingModel> ProductRatingBar
        {
            get { return productRatingBar; }
            set { productRatingBar = value; OnPropertyChanged(); }
        } 
        public ObservableCollection<CommentModel> OnlyThreeComments
        {
            get { return onlyThreeComments; }
            set { onlyThreeComments = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR
        public ProductDetailViewModel()
        {
            Title = "Producto";
            commentService = new CommentService();
            Comments = new ObservableCollection<CommentModel>();
        }
        #endregion
        #region METHODS
        public async Task LoadData()
        {
            base.OnAppering();
            CreateRatingBar();

            try
            {
                if (Product == null)
                    GetProductJsonParameter();

                Comments.Clear();
                Comments = Convert<CommentModel>(await commentService.GetAllCommentsForProduct(Product.ProductCode));

                LoadValorationStarsCollection();
                RatingCounter = Comments.Count;
                CalculateProductRating();
                CreateProductRatingBar();
            }
            catch(Exception ex)
            {
                IsContentViewVisible = false;
                IsRefreshing = false; 
            }

            // Si todo sale bien
            IsContentViewVisible = true; // Muestra el contenido de la pagina
            IsRefreshing = false; // Oculta el RefreshView
        }
        private void LoadValorationStarsCollection()
        {
            OnlyThreeComments = new ObservableCollection<CommentModel>(); // Lista para guardar solo 3 comentarios

            // Accedo a cada objeto
            for (int i = 0; i < Comments.Count; i++)
            {
                // Inicializa la lista de estrellas de cada objeto comentario
                Comments[i].ValorationStarsCollection = new ObservableCollection<RatingModel>();

                // Por cada lista de estrellas, se agregan 5 estrellas y se inician con lo valores por defecto
                for (int j = 0; j < 5; j++)
                {
                    Comments[i].ValorationStarsCollection.Add(new RatingModel()
                    {
                        RatingIcon = IconFont.StarOutline,
                        RatingColor = Color.FromHex("#FF6A0E"),
                        IsRatingPressed = false,
                    });
                }

                // Por cada objeto comentario, se pintan las estrellas correspondientes en base a su valoracion
                for (int k = 0; k < Comments[i].Valoration; k++)
                {
                    Comments[i].ValorationStarsCollection[k].RatingIcon = IconFont.StarFullOutline;
                    Comments[i].ValorationStarsCollection[k].RatingColor = Color.FromHex("#FF6A0E");
                    Comments[i].ValorationStarsCollection[k].IsRatingPressed = true;
                }

                // Solo se guardan tres comentarios
                if (i < 3)
                    OnlyThreeComments.Add(Comments[i]);
            }
        }
        private void CalculateProductRating()
        {
            int totalRating = 0; // Suma total de calificaciones

            for (int i = 0; i < Comments.Count; i++)
                totalRating += Comments[i].Valoration; // Se suman todas las calificaciones

            ProductRating = ((double)totalRating / (double)RatingCounter);

            if (Double.IsNaN(ProductRating))
                ProductRating = 0;
        }
        private void CreateProductRatingBar()
        {
            // Creación del control ProductRatingCollectionBar
            ProductRatingBar = new ObservableCollection<RatingModel>();

            // Estrellas con valores por defecto
            for (int i = 0; i < 5; i++)
            {
                ProductRatingBar.Add(new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#FF6A0E"),
                    IsRatingPressed = false,
                    RatingId = i
                });
            }

            // Valores actualizados
            for (int i = 0; i < (int)ProductRating; i++)
            {
                ProductRatingBar[i].RatingIcon = IconFont.StarFullOutline;
                ProductRatingBar[i].RatingColor = Color.FromHex("#FF6A0E");
                ProductRatingBar[i].IsRatingPressed = true;
            }
        }
        private void CreateRatingBar()
        {
            RatingBar = new ObservableCollection<RatingModel>();
            // Estrellas con valores por defecto
            for (int i = 0; i < 5; i++)
            {
                RatingBar.Add(new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#FF6A0E"),
                    IsRatingPressed = false,
                    RatingId = i
                });
            }
        }
        private void GetProductJsonParameter()
        {
            var product = JsonConvert.DeserializeObject<ProductModel>(ProductJson);
            Product = product;
        }
        #endregion
        #region COMMANDS
        public ICommand OnRefreshCommand => new Command(async () => await LoadData());
        #endregion
    }
}
