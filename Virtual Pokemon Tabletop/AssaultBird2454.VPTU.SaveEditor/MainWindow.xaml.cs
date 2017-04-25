using Microsoft.Win32;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;

namespace AssaultBird2454.VPTU.SaveEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public SaveManager.SaveManager SaveManager;
        public ProjectInfo VersioningInfo;

        public MainWindow()
        {
            InitializeComponent();

            #region Versioning Info
            using (Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("AssaultBird2454.VPTU.SaveEditor.ProjectVariables.json"))
            {
                using (StreamReader read = new StreamReader(str))
                {
                    VersioningInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectInfo>(read.ReadToEnd());
                    this.Title = "Virtual Pokemon Tabletop - SaveEditor (Version: " + VersioningInfo.Version + ") (Commit: " + VersioningInfo.Compile_Commit.Remove(7) + ")";
                }
            }
            #endregion

            Setup();
        }

        #region Setup Code
        private void Setup()
        {
            //PokedexManager_List.ItemsSource = PokedexItems;
        }
        #endregion

        #region Save Manager Related Code
        #region Triggering Events
        //When The "Open File" Button is clicked
        private void Menu_Menu_Open_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.CheckFileExists = true;
            openFile.CheckPathExists = true;
            openFile.Multiselect = false;
            openFile.Title = "Open Virtual PTU Save File";
            openFile.DefaultExt = ".ptu";

            openFile.FileOk += new System.ComponentModel.CancelEventHandler((object obj, System.ComponentModel.CancelEventArgs args) =>
            {
                Load(openFile.FileName);
            });

            openFile.ShowDialog();
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
            if (SaveManager == null)
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

            PokedexManager_ReloadList();//Reload List
        }
        #endregion

        #region Pokedex Manager Code
        #region Pokedex Manager Variables
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
        private void PokedexManager_AddDex_Ability_Click(object sender, RoutedEventArgs e)
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

        #region List Events
        private void PokedexManager_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        #endregion

        public void PokedexManager_ReloadList()
        {
            foreach (Pokedex.Pokemon.PokemonData Pokemon in SaveManager.SaveData.PokedexData.Pokemon)
            {
                PokedexList_DataBind PokemonDB = new PokedexList_DataBind();
                PokemonDB.Name = Pokemon.Species_Name;
                PokemonDB.ID = Pokemon.Species_DexID;
                PokemonDB.Type1 = Pokemon.Species_Type1.ToString();
                PokemonDB.Type2 = Pokemon.Species_Type2.ToString();
                PokemonDB.Class = "";

                PokemonDB.DataType = PokedexList_DataType.Pokemon;
                PokemonDB.DataTag = Pokemon;

                PokedexManager_List.Items.Add(PokemonDB);
            }
        }
        #endregion
    }

    /// <summary>
    /// All the types that the pokedex list will display (Used for Pharsing Selections)
    /// </summary>
    public enum PokedexList_DataType { Pokemon, Moves, Abilitys, Items }
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
        /// <param name="_Type1"></param>
        /// <param name="_Type2"></param>
        /// <param name="_Class"></param>
        public PokedexList_DataBind(int _ID, string _Name, string _EntryType, string _Type1, string _Type2, string _Class)
        {
            ID = _ID;
            Name = _Name;
            Type1 = _Type1;
            Type2 = _Type2;
            Class = _Class;
        }
        /// <summary>
        /// Creates a new instance of the PokedexList DataBind Object
        /// </summary>
        /// <param name="_ID"></param>
        /// <param name="_Name"></param>
        /// <param name="_EntryType"></param>
        public PokedexList_DataBind()
        {

        }

        /// <summary>
        /// The ID of the Object
        /// </summary>
        public decimal ID { get; set; }
        /// <summary>
        /// The Name of the Object
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// The Type of the Pokemon or Move
        /// </summary>
        public string Type1 { get; set; }
        /// <summary>
        /// The Secondary Type of the Pokemon
        /// </summary>
        public string Type2 { get; set; }
        /// <summary>
        /// The Class of move
        /// </summary>
        public string Class { get; set; }

        public PokedexList_DataType DataType { get; set; }
        public object DataTag { get; set; }
    }
}
