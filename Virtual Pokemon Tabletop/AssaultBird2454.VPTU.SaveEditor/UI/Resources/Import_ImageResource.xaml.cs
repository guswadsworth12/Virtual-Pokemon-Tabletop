using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Threading;

namespace AssaultBird2454.VPTU.SaveEditor.UI.Resources
{
    /// <summary>
    /// Interaction logic for Import_ImageResource.xaml
    /// </summary>
    public partial class Import_ImageResource : Window
    {
        public Import_ImageResource()
        {
            InitializeComponent();
        }

        private void Selected_FileDir_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        /// <summary>
        /// Submit button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            Import();
        }

        #region Resource Code
        private Thread ImportThread;

        private void Import()
        {
            foreach (string file in Directory.GetFiles(Selected_FileDir.Text))
            {
                ImportThread = new Thread(new ThreadStart(new Action(() => ImportFile(file))));
                //Import

                System.Windows.MessageBox.Show("File Name: " + file);
            }
        }

        private void ImportFile(string FileDir)
        {

        }
        #endregion

        #region Import Buttons
        /// <summary>
        /// When Bulk Import button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BulkImport_Button_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dirs = new FolderBrowserDialog();
            DialogResult dr = dirs.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Selected_FileDir.Text = dirs.SelectedPath;
            }
        }

        /// <summary>
        /// When Single File Import button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void File_Import_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dir = new OpenFileDialog();
            DialogResult dr = dir.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                Selected_FileDir.Text = dir.FileName;
            }
        }
        #endregion
    }
}
