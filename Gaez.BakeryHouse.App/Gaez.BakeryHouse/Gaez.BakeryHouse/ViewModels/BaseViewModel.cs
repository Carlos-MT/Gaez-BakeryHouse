using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.CommunityToolkit.UI.Views;

namespace Gaez.BakeryHouse.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        #region ATTRIBUTES
        LayoutState _currentState;
        bool _isBusy;
        bool _isEnabled;
        bool _isRefreshing;
        string _title;
        string _text;
        #endregion
        #region PROPERTIES
        public LayoutState CurrentState
        {
            get { return _currentState; }
            set { _currentState = value; OnPropertyChanged(); }
        }
        public bool IsBusy
        {
            get { return _isBusy; }
            set { _isBusy = value; OnPropertyChanged(); }
        }
        public bool IsEnabled
        {
            get { return _isEnabled; }
            set { _isEnabled = value; OnPropertyChanged(); }
        }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { _isRefreshing = value; OnPropertyChanged(); }
        }
        public string Title
        {
            get { return _title; }
            set { _title = value; OnPropertyChanged(); }
        }
        public string Text
        {
            get { return _text; }
            set { _text = value; OnPropertyChanged(); }
        }
        #endregion
        #region METHODS
        protected void OnAppering()
        {
            IsRefreshing = true;
            IsEnabled = true;
            IsBusy = true;
            CurrentState = LayoutState.Loading;
            Text = string.Empty;
        }
        public ObservableCollection<T> Convert<T>(IEnumerable<T> original)
        {
            return new ObservableCollection<T>(original);
        }
        #endregion
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
