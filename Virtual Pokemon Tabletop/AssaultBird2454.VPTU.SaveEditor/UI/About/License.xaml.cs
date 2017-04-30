using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AssaultBird2454.VPTU.SaveEditor.UI.About
{
    /// <summary>
    /// Interaction logic for Licence.xaml
    /// </summary>
    public partial class License : Window
    {
        public License(string Data, string TitleText)
        {
            InitializeComponent();

            Title = TitleText;
            License_Text.Text = Data;
        }
    }
}
