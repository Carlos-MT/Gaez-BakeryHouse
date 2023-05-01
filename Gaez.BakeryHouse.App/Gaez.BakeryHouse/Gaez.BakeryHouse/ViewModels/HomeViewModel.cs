using Gaez.BakeryHouse.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel()
        {
        }

        public async Task LoadData()
        {
            base.OnAppering();
            try
            {
                await ProductData.LoadData();
            }
            catch (Exception ex) 
            {
                CurrentState = LayoutState.Error;
            }

            if(CurrentState != LayoutState.Error)
                CurrentState = LayoutState.Success;

            IsRefreshing = false;
        }

        public ICommand OnRefreshCommand => new Command(async() => await LoadData());
    }
}
