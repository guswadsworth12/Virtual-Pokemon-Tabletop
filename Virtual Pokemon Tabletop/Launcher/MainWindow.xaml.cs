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

namespace Launcher
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Variables
        Settings VPTU_Settings;
        public static string AssemblyDirectory
        {
            get
            {
                string codeBase = Assembly.GetExecutingAssembly().CodeBase;
                UriBuilder uri = new UriBuilder(codeBase);
                string path = Uri.UnescapeDataString(uri.Path);
                return System.IO.Path.GetDirectoryName(path);
            }
        }
        public static string ConfigFile_Directory
        {
            get
            {
                return AssemblyDirectory + "/Settings.json";
            }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();

            if (File.Exists(ConfigFile_Directory))
            {

            }
            else
            {

            }

            VPTU_Settings = new Settings();
        }

        /// <summary>
        /// Loads a config file from the root of the executing directory
        /// </summary>
        private void Load_Settings()
        {
            using(FileStream stream = new FileStream(ConfigFile_Directory, FileMode.Open)){
                string configjson =
            }
        }
        /// <summary>
        /// Loads a config file from the root of the executing directory
        /// </summary>
        private void Save_Settings()
        {

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        /// <summary>
        /// Used to open the settings
        /// </summary>
        /// <param name="sender">Object that sent the request to open the settings</param>
        /// <param name="e">args</param>
        private void Settings_Button_Click(object sender, RoutedEventArgs e)
        {
            SettingsWindow Settings = new SettingsWindow();
            Settings.ShowDialog();
        }
    }
}
