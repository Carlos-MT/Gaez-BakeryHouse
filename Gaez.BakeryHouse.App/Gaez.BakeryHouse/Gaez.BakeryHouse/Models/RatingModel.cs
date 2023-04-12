using Gaez.BakeryHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace Gaez.BakeryHouse.Models
{
    public class RatingModel : BaseViewModel
    {
        private int ratingId;
        private string _ratingIcon;
        private Color _ratingColor;
        private bool _isRatingPressed;
        public string RatingIcon
        {
            get { return _ratingIcon; }
            set { _ratingIcon = value; OnPropertyChanged(); }
        }
        public Color RatingColor
        {
            get { return _ratingColor; }
            set { _ratingColor = value; OnPropertyChanged(); }
        }
        public bool IsRatingPressed
        {
            get { return _isRatingPressed; }
            set { _isRatingPressed = value; OnPropertyChanged(); }
        }
        public int RatingId
        {
            get { return ratingId; }
            set { ratingId = value; OnPropertyChanged(); }
        }
    }
}
