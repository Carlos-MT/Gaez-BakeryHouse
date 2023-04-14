using Gaez.BakeryHouse.Models;
using Gaez.BakeryHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Gaez.BakeryHouse.API.Models
{
    public class CommentModel : BaseViewModel
    {
        public int CommentId { get; set; }
        public DateTime CommentDate { get; set; }
        public int Valoration { get; set; }
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string FatherLastName { get; set; }
        public string MotherLastName { get; set; }
        private ObservableCollection<RatingModel> valorationStarsCollection;
        public ObservableCollection<RatingModel> ValorationStarsCollection
        {
            get { return valorationStarsCollection; }
            set {  valorationStarsCollection = value; OnPropertyChanged();}
        }
    }
}
