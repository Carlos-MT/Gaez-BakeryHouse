using Gaez.BakeryHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.Models
{
    public class ProductModel : BaseViewModel
    {
        public int ProductCode { get; set; }
        public string ProductName { get; set; }
        public DateTime ExpirityDate { get; set; }
        public decimal RegularPrice { get; set; }
        public int Valuation { get; set; }
        public string Description { get; set; }
        public string Application { get; set; }
        public int Stock { get; set; }
        public byte[] ProductImage { get; set; }
        public Color ColorHeart
        {
            get { return colorHeart; }
            set { colorHeart = value; OnPropertyChanged(); }
        }
        private Color colorHeart;
        public string Icon
        {
            get { return  icon; }
            set {  icon = value; OnPropertyChanged(); }
        }

        private string icon;

    }
}
