using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using GalaSoft.MvvmLight;

namespace Reader
{
    public class ReaderViewModel: ViewModelBase
    {
        private Article _selectedArticle;
        public ObservableCollection<Article> NamesArticles { get; set; }

        public Article SelectedArticle
        {
            get { return _selectedArticle; }
            set
            {
                _selectedArticle = value;
                RaisePropertyChanged(() => SelectedArticle);
            }
        }

        public ReaderViewModel()
        {
            var tmp = new ObservableCollection<Article>();
            for (int i = 0; i < 4; i++)
            {
                var a = new Article();  
                a.Name = "Глава " + i;
                a.Parts = new List<string>() {"" + i, "" + i}; 
                tmp.Add(a);
            }
            NamesArticles = tmp;
            RaisePropertyChanged(()=>NamesArticles);
        }

    }

    public class Article
    {
        public string Name { get; set; }
        public List<string> Parts { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
