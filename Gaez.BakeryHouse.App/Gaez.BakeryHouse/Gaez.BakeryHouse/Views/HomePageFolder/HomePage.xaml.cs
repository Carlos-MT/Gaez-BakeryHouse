﻿using Gaez.BakeryHouse.ViewModels;
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
	public partial class HomePage : ContentPage
	{
		private HomeViewModel viewModel;
		public HomePage ()
		{
			InitializeComponent ();
			BindingContext = viewModel = new HomeViewModel();
		}

        protected override async void OnAppearing()
        {
            base.OnAppearing();
			await viewModel.LoadData();
        }
    }
}