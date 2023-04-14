using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Fonts;
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
    public class ProductViewModel : BaseViewModel
    {
        #region ATTRIBUTES
        private string _productJson;
        private ProductModel _product;
        private ObservableCollection<RatingModel> _ratingCollectionBar;
        private ObservableCollection<CommentModel> _commentsCollection;
        private readonly CommentService _commentService;
        private int totalQualifications;
        private double productQualification;
        private ObservableCollection<RatingModel> _productRatingCollectionBar;
        private ObservableCollection<CommentModel> _onlyThreeCommentsCollection;
        #endregion
        #region PROPERTIES
        public string ProductJson
        {
            get { return _productJson; }
            set { _productJson = value; OnPropertyChanged(); }
        }
        public ProductModel Product
        {
            get { return _product; }
            set { _product = value; OnPropertyChanged();}
        }
        public ObservableCollection<RatingModel> RatingCollectionBar
        {
            get { return _ratingCollectionBar; }
            set { _ratingCollectionBar = value; OnPropertyChanged(); }
        } // Barra con la que interactua el usuario
        public ObservableCollection<CommentModel> CommentsCollection
        {
            get { return _commentsCollection; }
            set { _commentsCollection = value; OnPropertyChanged(); }
        }
        public int TotalQualifications
        {
            get { return totalQualifications; }
            set { totalQualifications = value; OnPropertyChanged(); }
        } // Total de calificaciones que tiene el producto (Comentarios)
        public double ProductQualification
        {
            get { return productQualification; }
            set {  productQualification = value; OnPropertyChanged(); }
        } // Calificacion del producto
        public ObservableCollection<RatingModel> ProductRatingCollectionBar
        {
            get { return _productRatingCollectionBar; }
            set { _productRatingCollectionBar = value; OnPropertyChanged(); }
        } // Barra de rating del producto
        public ObservableCollection<CommentModel> OnlyThreeCommentsCollection
        {
            get { return _onlyThreeCommentsCollection; }
            set { _onlyThreeCommentsCollection = value; OnPropertyChanged(); }
        }
        #endregion
        #region CONSTRUCTOR
        public ProductViewModel()
        {
            _commentService = new CommentService();
            CommentsCollection = new ObservableCollection<CommentModel>();
        }
        #endregion
        #region METHODS
        private void GetProductJsonParameter()
        {
            var product = JsonConvert.DeserializeObject<ProductModel>(ProductJson);
            Product = product;
        }
        public async Task LoadData()
        {
            base.OnAppering();
            InitRatingCollectionBar(); // Creación del RatingCollectionBar
            try
            {
                if (Product == null)
                    GetProductJsonParameter();

                CommentsCollection.Clear();
                CommentsCollection = Convert<CommentModel>(await _commentService.GetAllCommentsForProduct(Product.ProductCode));
                
                // Si la CommentsCollection no tiene elementos
                if (CommentsCollection.Count == 0)
                    IsCommentsViewVisible = false; // Oculta la pagina de comentarios
                else // De lo contario si, si tiene elementos
                {
                    LoadValorationStarsCollection(); // Cargar la valoración de los tres primeros usuarios mas recientes
                    IsCommentsViewVisible = true; // Muestra la pagina de comentarios
                    TotalQualifications = CommentsCollection.Count; // Total de calificaciones
                    CalculateProductValoration(); // Calcular la valoracion del producto
                    InitProductRatingCollectionBar(); // Creación del ProductRatingCollectionBar
                }    
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
        private void LoadValorationStarsCollection()
        {
            OnlyThreeCommentsCollection = new ObservableCollection<CommentModel>(); // Lista para guardar solo 3 comentarios

            // Accedo a cada objeto
            for(int i = 0; i < CommentsCollection.Count; i++) 
            {
                // Inicializa la lista de estrellas de cada objeto comentario
                CommentsCollection[i].ValorationStarsCollection = new ObservableCollection<RatingModel>();
                
                // Por cada lista de estrellas, se agregan 5 estrellas y se inician con lo valores por defecto
                for(int j = 0; j < 5; j++)
                {
                    CommentsCollection[i].ValorationStarsCollection.Add(new RatingModel()
                    {
                        RatingIcon = IconFont.StarOutline,
                        RatingColor = Color.FromHex("#9A9999"),
                        IsRatingPressed = false,
                     });
                }

                // Por cada objeto comentario, se pintan las estrellas correspondientes en base a su valoracion
                for (int k = 0; k < CommentsCollection[i].Valoration; k++)
                {
                    CommentsCollection[i].ValorationStarsCollection[k].RatingIcon = IconFont.StarFullOutline;
                    CommentsCollection[i].ValorationStarsCollection[k].RatingColor = Color.Yellow;
                    CommentsCollection[i].ValorationStarsCollection[k].IsRatingPressed = true;
                }

                // Solo se guardan tres comentarios
                if (i < 3)
                    OnlyThreeCommentsCollection.Add(CommentsCollection[i]);
            }
        }
        private void InitRatingCollectionBar()
        {
            // Creación del control RatingCollectionBar
            RatingCollectionBar = new ObservableCollection<RatingModel>();

            // Estrellas con valores por defecto
            for (int i = 0; i < 5; i++)
            {
                RatingCollectionBar.Add(new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#9A9999"),
                    IsRatingPressed = false,
                    RatingId = i
                });

                // Pintar una estrella por defecto
                if (i == 0)
                {
                    RatingCollectionBar[i].RatingIcon = IconFont.StarFullOutline;
                    RatingCollectionBar[i].RatingColor = Color.Yellow;
                    RatingCollectionBar[i].IsRatingPressed = true;
                    RatingCollectionBar[i].RatingId = i;
                }
            }
        }
        private void InitProductRatingCollectionBar()
        {
            // Creación del control ProductRatingCollectionBar
            ProductRatingCollectionBar = new ObservableCollection<RatingModel>();

            // Estrellas con valores por defecto
            for (int i = 0; i < 5; i++)
            {
                ProductRatingCollectionBar.Add(new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#9A9999"),
                    IsRatingPressed = false,
                    RatingId = i
                });
            }

            // Valores actualizados
            for (int i = 0; i < (int)ProductQualification; i++)
            {
                ProductRatingCollectionBar[i].RatingIcon = IconFont.StarFullOutline;
                ProductRatingCollectionBar[i].RatingColor = Color.Yellow;
                ProductRatingCollectionBar[i].IsRatingPressed = true;
            }
        }
        private void CalculateProductValoration()
        {
           int totalValorations = 0; // Suma total de calificaciones

            for (int i = 0; i < CommentsCollection.Count; i++)
                totalValorations += CommentsCollection[i].Valoration; // Se suman todas las calificaciones

            ProductQualification = ( (double)totalValorations / (double)TotalQualifications );
        }
        #endregion
        #region COMMANDS
        public ICommand OnRatingClickedCommand => new Command<RatingModel>((p) =>
        {
            // Valores por defecto
            for (int i = 0; i < RatingCollectionBar.Count; i++)
            {
                RatingCollectionBar[i].RatingIcon = IconFont.StarOutline;
                RatingCollectionBar[i].RatingColor = Color.FromHex("#9A9999");
                RatingCollectionBar[i].IsRatingPressed = false;
            }

            // Valores actualizados
            for (int i = 0; i < p.RatingId + 1; i++)
            {
                RatingCollectionBar[i].RatingIcon = IconFont.StarFullOutline;
                RatingCollectionBar[i].RatingColor = Color.Yellow;
                RatingCollectionBar[i].IsRatingPressed = true;
            }
        });
        public ICommand OnCommentClickedCommand => new Command(async () =>
        {
            IsButtonEnabled = false; // Se deshabilitan los botones
            int acountStars = 0;
            ReturnInfo info = new ReturnInfo();
            CommentModel comment;
            

            try
            {
                if (string.IsNullOrWhiteSpace(InputText))
                    await Shell.Current.DisplayAlert("Mensaje", "Por favor deja un comentario", "Ok");
                else
                {
                    IsContentViewVisible = false; // Se oculta todo el contenido

                    for (int i = 0; i < RatingCollectionBar.Count; i++)
                        if (RatingCollectionBar[i].IsRatingPressed)
                            acountStars++;

                    comment = new CommentModel()
                    {
                        CommentDate = DateTime.Now,
                        Description = InputText,
                        Valoration = acountStars,
                    };

                    info = await _commentService.PostComment(comment, 1, Product.ProductCode);

                    if(info.Result == ResultCode.Success)
                        await Shell.Current.DisplayAlert("Mensaje", "Comentario realizado con exito", "Ok");
                }
            }
            catch(Exception e)
            {
                // Si ocurre un error
                IsRefreshVisible = false; // Oculta el RefreshView
                IsContentViewVisible = false; // Oculta el contenido de la pagina 
                await Shell.Current.DisplayAlert("ERROR", "No se pudo realizar el comentario", "Ok");
            }

            await LoadData();
        });
        public ICommand OnRefreshCommand => new Command(async () =>  await LoadData());
        #endregion
    }
}
