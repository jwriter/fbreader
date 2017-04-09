using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Data;

namespace Reader.Convertors
{
    public class ArticleToString: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            Article art = value as Article;
            if (art == null) return null;
            StringBuilder sb = new StringBuilder();
            foreach (var part in art.Parts)
            {
                sb.Append(part);
            }
            return sb.ToString();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
