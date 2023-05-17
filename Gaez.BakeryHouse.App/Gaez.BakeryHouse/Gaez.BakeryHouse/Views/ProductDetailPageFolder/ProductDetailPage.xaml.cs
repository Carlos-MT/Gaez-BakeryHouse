using Gaez.BakeryHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Gaez.BakeryHouse.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ProductDetailPage : ContentPage
	{
		ProductDetailViewModel viewModel;
		public ProductDetailPage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new ProductDetailViewModel();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
			await viewModel.LoadData();
        }

		protected override async void OnDisappearing()
		{
			base.OnDisappearing();

			if (viewModel.Product.ColorHeart == Color.Red)
				await viewModel.PostToFavorites();
			else
				await viewModel.DeleteToFavorites();
		}
	}
}