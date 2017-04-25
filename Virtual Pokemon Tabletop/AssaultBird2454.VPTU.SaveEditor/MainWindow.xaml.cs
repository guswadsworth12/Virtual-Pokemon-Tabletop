using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AssaultBird2454.VPTU.SaveEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SaveManager.SaveManager SaveManager;

        public MainWindow()
        {
            InitializeComponent();
            Setup();
        }

        #region Setup Code
        private void Setup()
        {
            PokedexManager_List.ItemsSource = PokedexItems;
        }
        #endregion

        #region Save Manager Related Code
        #region Triggering Events
        //When The "Open File" Button is clicked
        private void Menu_Menu_Open_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The "Save File" Button is clicked
        private void Menu_Menu_Save_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The "Save File As" Button is clicked
        private void Menu_Menu_SaveAs_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("This feature is not currently working...");
        }
        #endregion

        /// <summary>
        /// Saves the Save Data to Save File
        /// </summary>
        public void Save()
        {
            if(SaveManager == null)
            {
                MessageBox.Show("No File is open... Please open a file before saving");
                return;
            }

            SaveManager.Save_SaveData();
        }
        /// <summary>
        /// Loads a Save File
        /// </summary>
        /// <param name="Path">Path to Save file to be opened</param>
        public void Load(string Path)
        {
            SaveManager = new VPTU.SaveManager.SaveManager(Path);
            SaveManager.Load_SaveData();
        }
        #endregion

        #region Pokedex Manager Code
        #region Pokedex Manager Variables
        /// <summary>
        /// List of all items in the Pokedex Manager List
        /// </summary>
        private List<PokedexList_DataBind> PokedexItems = new List<PokedexList_DataBind>();
        #endregion

        #region Right SideBar Events
        //When The "Add Pokemon" Button is clicked
        private void PokedexManager_AddDex_Pokemon_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The "Add Move" Button is clicked
        private void PokedexManager_AddDex_Move_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The "Add Ability" Button is clicked
        private void PokedexManager_AddDex_Abilitie_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The "Add Item" Button is clicked
        private void PokedexManager_AddDex_Items_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The "Edit" Button is clicked
        private void PokedexManager_ManageDex_Edit_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The "Delete" Button is clicked
        private void PokedexManager_ManageDex_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The Search Box has been changed
        private void PokedexManager_SearchDex_Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        #endregion

        #endregion
    }

    /// <summary>
    /// A Class designed for Data Binding Pokedex Data to the Pokedex List
    /// </summary>
    public class PokedexList_DataBind
    {
        /// <summary>
        /// Creates a new instance of the PokedexList DataBind Object
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_Name"></param>
        /// <param name="_EntryType"></param>
        public PokedexList_DataBind(int _ID, string _Name, string _EntryType)
        {
            ID = _ID;
            Name = _Name;
            EntryType = _EntryType;
        }

        /// <summary>
        /// The ID of the Object
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// The Name of the Object
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// The Entity Type of the Object
        /// </summary>
        public string EntryType { get; set; }
    }
}
