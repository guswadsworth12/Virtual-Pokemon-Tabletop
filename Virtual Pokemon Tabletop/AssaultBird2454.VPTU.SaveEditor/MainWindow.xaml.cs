using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace AssaultBird2454.VPTU.SaveEditor
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static SaveManager.SaveManager SaveManager;
        public ProjectInfo VersioningInfo;
        /// <summary>
        /// Assembly Directory
        /// </summary>
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

        #region Form Code
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
        private void Menu_About_Licence_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(AssemblyDirectory + "/LICENSE", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        UI.About.License lic = new UI.About.License(sr.ReadToEnd(), "License");
                        lic.ShowDialog();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The \"LICENSE\" File was not found when trying to read it! The \"LICENSE\" file is avalable on GitHub.", "License File Missing");
            }
        }
        private void Menu_About_LegalNotices_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(AssemblyDirectory + "/LEGAL NOTICE", FileMode.Open))
                {
                    using (StreamReader sr = new StreamReader(fs))
                    {
                        UI.About.License lic = new UI.About.License(sr.ReadToEnd(), "Legal Notices");
                        lic.ShowDialog();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("The \"LEGAL NOTICE\" File was not found when trying to read it! The \"LEGAL NOTICE\" file is avalable on GitHub.", "License File Missing");
            }
        }
        #endregion

        #region Setup Code
        private void Setup()
        {

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
            Save();
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
        Thread PokedexSearchThread;
        #endregion

        #region Right SideBar Events
        //When The "Add Pokemon" Button is clicked
        private void PokedexManager_AddDex_Pokemon_Click(object sender, RoutedEventArgs e)
        {
            UI.Pokedex.Pokemon pokemon = new UI.Pokedex.Pokemon();
            bool? OK = pokemon.ShowDialog();

            if (OK == true)
            {
                PokedexManager_ReloadList();
            }
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
            if (((PokedexList_DataBind)PokedexManager_List.SelectedValue).DataType == PokedexList_DataType.Pokemon)
            {
                Pokedex.Pokemon.PokemonData Data = (Pokedex.Pokemon.PokemonData)((PokedexList_DataBind)PokedexManager_List.SelectedValue).DataTag;
                UI.Pokedex.Pokemon pokemon = new UI.Pokedex.Pokemon(Data);
                bool? OK = pokemon.ShowDialog();

                if (OK == true)
                {
                    PokedexManager_ReloadList();
                }
            }
            else if (((PokedexList_DataBind)PokedexManager_List.SelectedValue).DataType == PokedexList_DataType.Move)
            {
                MessageBox.Show("Feature not Avaliable for that Data Type.");
            }
        }
        //When The "Delete" Button is clicked
        private void PokedexManager_ManageDex_Delete_Click(object sender, RoutedEventArgs e)
        {

        }
        //When The Search Box has been changed
        private void PokedexManager_SearchDex_Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                PokedexSearchThread.Abort();
                PokedexSearchThread = null;
            }
            catch { }

            PokedexSearchThread = new Thread(new ThreadStart(() =>
            {
                this.Dispatcher.Invoke(new Action(() => PokedexManager_ReloadList()));
            }));
            PokedexSearchThread.Start();
        }
        #endregion

        #region List Events
        private void PokedexManager_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
        private void PokedexManager_SearchDex_Pokemon_Checked(object sender, RoutedEventArgs e)
        {
            PokedexManager_ReloadList();
        }
        private void PokedexManager_SearchDex_Pokemon_Unchecked(object sender, RoutedEventArgs e)
        {
            PokedexManager_ReloadList();
        }
        private void PokedexManager_SearchDex_Moves_Checked(object sender, RoutedEventArgs e)
        {
            PokedexManager_ReloadList();
        }
        private void PokedexManager_SearchDex_Moves_Unchecked(object sender, RoutedEventArgs e)
        {
            PokedexManager_ReloadList();
        }
        private void PokedexManager_SearchDex_Abilitys_Checked(object sender, RoutedEventArgs e)
        {
            PokedexManager_ReloadList();
        }
        private void PokedexManager_SearchDex_Abilitys_Unchecked(object sender, RoutedEventArgs e)
        {
            PokedexManager_ReloadList();
        }
        private void PokedexManager_SearchDex_Items_Checked(object sender, RoutedEventArgs e)
        {
            PokedexManager_ReloadList();
        }
        private void PokedexManager_SearchDex_Items_Unchecked(object sender, RoutedEventArgs e)
        {
            PokedexManager_ReloadList();
        }
        #endregion

        /// <summary>
        /// Reloads the Pokedex list
        /// </summary>
        /// <param name="Search">Limits only Pokemon and Moves where the name contains the Search value (Not Case Sensitive)</param>
        public void PokedexManager_ReloadList()
        {
            PokedexManager_List.Items.Clear();

            if (SaveManager == null) { return; }

            if (PokedexManager_SearchDex_Pokemon.IsChecked == true)
            {
                foreach (Pokedex.Pokemon.PokemonData Pokemon in SaveManager.SaveData.PokedexData.Pokemon)
                {
                    if (Pokemon.Species_Name.ToLower().Contains(PokedexManager_SearchDex_Search.Text.ToLower()))
                    {
                        PokedexList_DataBind PokemonDB = new PokedexList_DataBind();
                        PokemonDB.Name = Pokemon.Species_Name;
                        PokemonDB.ID = Pokemon.Species_DexID;
                        PokemonDB.Type1 = Pokemon.Species_Type1.ToString();
                        PokemonDB.Type2 = Pokemon.Species_Type2.ToString();
                        PokemonDB.Class = "";
                        PokemonDB.EntryType = "Pokemon";

                        PokemonDB.DataType = PokedexList_DataType.Pokemon;
                        PokemonDB.DataTag = Pokemon;

                        PokedexManager_List.Items.Add(PokemonDB);
                    }
                }
            }

            if (PokedexManager_SearchDex_Moves.IsChecked == true)
            {
                foreach (Pokedex.Moves.MoveData Move in SaveManager.SaveData.PokedexData.Moves)
                {
                    if (Move.Name.ToLower().Contains(PokedexManager_SearchDex_Search.Text.ToLower()))
                    {
                        PokedexList_DataBind MoveDB = new PokedexList_DataBind();
                        MoveDB.Name = Move.Name;
                        MoveDB.ID = (SaveManager.SaveData.PokedexData.Moves.IndexOf(Move) + 1);
                        MoveDB.Type1 = Move.Move_Type.ToString();
                        MoveDB.Type2 = "";
                        MoveDB.Class = Move.Move_Class.ToString();
                        MoveDB.EntryType = "Move";

                        MoveDB.DataType = PokedexList_DataType.Move;
                        MoveDB.DataTag = Move;

                        PokedexManager_List.Items.Add(MoveDB);
                    }
                }
            }
        }
        #endregion
    }

    /// <summary>
    /// All the types that the pokedex list will display (Used for Pharsing Selections)
    /// </summary>
    public enum PokedexList_DataType { Pokemon, Move, Ability, Item }
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

        public string EntryType { get; set; }

        public PokedexList_DataType DataType { get; set; }
        public object DataTag { get; set; }
    }
}
