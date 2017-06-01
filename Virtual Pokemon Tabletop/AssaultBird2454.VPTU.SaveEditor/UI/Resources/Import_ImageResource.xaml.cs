﻿using System;
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

            if (Close_On_Complete.IsChecked == true)
            {
                DialogResult = true;
                Close();
            }
        }

        #region Resource Code
        private Thread ImportThread;

        private void Import()
        {
            Import_Progress.Value = 0;

            if (File.Exists(Selected_FileDir.Text))
            {
                Import_Progress.Maximum = 1;// Sets the Progress Bar to 1 File

                ImportFile(Selected_FileDir.Text, Import_Save.IsChecked);
                Import_Progress.Dispatcher.Invoke(new Action(() => Import_Progress.Value = 1));
            }
            else if (Directory.Exists(Selected_FileDir.Text))
            {
                string[] Files = Directory.GetFiles(Selected_FileDir.Text);
                Import_Progress.Maximum = Files.Count();// Sets the Progress Bar to the amount of file in folder

                foreach (string file in Files)
                {
                    bool? imp = Import_Save.IsChecked;
                    ImportThread = new Thread(new ThreadStart(new Action(() =>
                    {
                        ImportFile(file, imp);
                    })));
                    ImportThread.IsBackground = true;
                    ImportThread.Start();
                    Import_Progress.Value++;
                }
            }
            else { }
        }

        private void ImportFile(string FileDir, bool? Import = false)
        {
            SaveManager.Resource_Data.Resources res = new SaveManager.Resource_Data.Resources();
            res.Name = System.IO.Path.GetFileName(FileDir);
            res.Type = SaveManager.Resource_Data.Resource_Type.Image;

            if (Import == true)
            {
                res.Path = "save:" + FileDir;
                MainWindow.SaveManager.ImportFile(FileDir, res.Name);
            }
            else
            {
                res.Path = "path:" + FileDir;
            }
            
            MainWindow.SaveManager.SaveData.ImageResources.Add(res);
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
