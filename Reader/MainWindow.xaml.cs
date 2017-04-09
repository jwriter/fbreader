using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Reader
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MouseMove(object sender, MouseEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Point mousePoint = Mouse.GetPosition(textBox);
            int charPosition = textBox.GetCharacterIndexFromPoint(mousePoint, true);
            if (charPosition > 0)
            {
                textBox.Focus();
                int index = 0;
                int i = 0;
                string[] strings = textBox.Text.Split(' ');
                while (index + strings[i].Length < charPosition && i < strings.Length)
                {
                    index += strings[i++].Length + 1;
                }
                textBox.Select(index, strings[i].Length);
            }
        }
    }
}
