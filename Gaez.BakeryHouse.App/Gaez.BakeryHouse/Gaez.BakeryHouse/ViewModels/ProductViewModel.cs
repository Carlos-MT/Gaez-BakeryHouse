using Gaez.BakeryHouse.API.Models;
using Gaez.BakeryHouse.Fonts;
using Gaez.BakeryHouse.Models;
using Newtonsoft.Json;
using Refit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
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
        }
        #endregion
        #region CONSTRUCTOR
        public ProductViewModel()
        {
            RatingCollectionBar = new ObservableCollection<RatingModel>
            {
                new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#9A9999"),
                    IsRatingPressed = false,
                    RatingId = 0
                },
                new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#9A9999"),
                    IsRatingPressed = false,
                     RatingId = 1
                },
                new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#9A9999"),
                    IsRatingPressed = false,
                     RatingId = 2
                },
                new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#9A9999"),
                    IsRatingPressed = false,
                    RatingId = 3
                },
                new RatingModel()
                {
                    RatingIcon = IconFont.StarOutline,
                    RatingColor = Color.FromHex("#9A9999"),
                    IsRatingPressed = false,
                    RatingId = 4
                }
            };  
        }
        #endregion
        #region METHODS
        private void GetProductJsonParameter()
        {
            var product = JsonConvert.DeserializeObject<ProductModel>(ProductJson);
            Product = product;
        }
        public void LoadData()
        {
            if (Product == null)
                GetProductJsonParameter();
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
            for (int i = 0; i < p.RatingId + 1;i++)
            {
                RatingCollectionBar[i].RatingIcon = IconFont.StarFullOutline;
                RatingCollectionBar[i].RatingColor = Color.Yellow;
                RatingCollectionBar[i].IsRatingPressed = true;
            }
        });   
        #endregion
    }
}
