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
	public partial class FavoritePage : ContentPage
	{
		FavoriteViewModel viewModel;
		public FavoritePage ()
		{
			InitializeComponent();
			BindingContext = viewModel = new FavoriteViewModel();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
			await viewModel.LoadData();
        }
    }
}