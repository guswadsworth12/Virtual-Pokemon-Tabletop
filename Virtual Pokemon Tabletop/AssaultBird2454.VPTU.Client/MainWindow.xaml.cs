using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AssaultBird2454.VPTU.Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ProjectInfo VersioningInfo { get; }

        public MainWindow()
        {
            InitializeComponent();

            #region Versioning Info
            using (Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("AssaultBird2454.VPTU.Client.ProjectVariables.json"))
            {
                using (StreamReader read = new StreamReader(str))
                {
                    VersioningInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectInfo>(read.ReadToEnd());
                    this.Title = "Virtual Pokemon Tabletop (Version: " + VersioningInfo.Version + ") (Commit: " + VersioningInfo.Compile_Commit.Remove(7) + ")";
                }
            }
            #endregion
        }

        private void Menu_Menu_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
