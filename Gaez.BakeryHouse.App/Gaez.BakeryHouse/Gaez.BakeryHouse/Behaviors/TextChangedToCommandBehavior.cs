using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Gaez.BakeryHouse.Behaviors
{
    public class TextChangedToCommandBehavior : Behavior<SearchBar>
    {
        public static readonly BindableProperty CommandProperty =
            BindableProperty.Create(nameof(Command), typeof(ICommand), typeof(TextChangedToCommandBehavior));

        public ICommand Command
        {
            get {  return (ICommand)GetValue(CommandProperty);}
            set { SetValue(CommandProperty, value); }
        }

        protected override void OnAttachedTo(SearchBar bindable)
        {
            base.OnAttachedTo(bindable);
            bindable.TextChanged += Bindable_TextChanged;
            bindable.BindingContextChanged += Bindable_BindingContextChanged;
        }

        private void Bindable_BindingContextChanged(object sender, EventArgs e)
        {
            var view = (SearchBar)sender;
            BindingContext = view?.BindingContext;
        }

        protected override void OnDetachingFrom(SearchBar bindable)
        {
            base.OnDetachingFrom(bindable);
            bindable.TextChanged -= Bindable_TextChanged;
            bindable.BindingContextChanged += Bindable_BindingContextChanged1;
        }

        private void Bindable_BindingContextChanged1(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Bindable_TextChanged(object sender, TextChangedEventArgs e)
        {
            Command.Execute(e);
        }
    }
}
