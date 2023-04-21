using Gaez.BakeryHouse.Fonts;
using Gaez.BakeryHouse.Models;
using Gaez.BakeryHouse.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Gaez.BakeryHouse
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ProductDetailPage), typeof(ProductDetailPage));
            Routing.RegisterRoute(nameof(CategoryProductPage), typeof(CategoryProductPage));
        }
    }
}
