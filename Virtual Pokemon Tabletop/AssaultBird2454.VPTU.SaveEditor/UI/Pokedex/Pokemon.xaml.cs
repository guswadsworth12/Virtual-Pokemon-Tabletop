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

namespace AssaultBird2454.VPTU.SaveEditor.UI.Pokedex
{
    /// <summary>
    /// Interaction logic for Pokemon.xaml
    /// </summary>
    public partial class Pokemon : Window
    {
        VPTU.Pokedex.Pokemon.PokemonData PokemonData;
        bool Update = false;

        public Pokemon(VPTU.Pokedex.Pokemon.PokemonData _PokemonData = null)
        {
            InitializeComponent();

            if (_PokemonData == null)
            {
                PokemonData = new VPTU.Pokedex.Pokemon.PokemonData();
            }
            else
            {
                PokemonData = _PokemonData;
                Update = true;
                Load();
            }


            Basic_Type1.ItemsSource = Enum.GetValues(typeof(BattleManager.Data.Type));
            Basic_Type2.ItemsSource = Enum.GetValues(typeof(BattleManager.Data.Type));
            Basic_Weight.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.WeightClass));
            Basic_Size.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SizeClass));
        }

        /// <summary>
        /// Loads the data from a Dex Entry, Can be used to reset the page
        /// </summary>
        private void Load()
        {
            #region Basic Info
            Basic_Name.Text = PokemonData.Species_Name;
            Basic_ID.Text = PokemonData.Species_DexID.ToString();
            Basic_Type1.SelectedItem = PokemonData.Species_Type1;
            Basic_Type2.SelectedItem = PokemonData.Species_Type2;
            Basic_Weight.SelectedItem = PokemonData.Species_WeightClass;
            Basic_Size.SelectedItem = PokemonData.Species_SizeClass;
            #endregion

        }
        /// <summary>
        /// Saves Modifications or Adds a new entry to the Pokedex
        /// </summary>
        private void Save()
        {
            bool Close = false;
            try
            {
                if (ValidateSettings())// Settings get Validated here and if it passes, it will Save the Data Below
                {
                    //Save Form to Object Here
                    #region Basic Info
                    PokemonData.Species_Name = Basic_Name.Text;
                    PokemonData.Species_DexID = Convert.ToDecimal(Basic_ID.Text);
                    PokemonData.Species_Type1 = (BattleManager.Data.Type)Basic_Type1.SelectedItem;
                    PokemonData.Species_Type2 = (BattleManager.Data.Type)Basic_Type2.SelectedItem;
                    PokemonData.Species_WeightClass = (BattleManager.Entity.WeightClass)Basic_Weight.SelectedItem;
                    PokemonData.Species_SizeClass = (BattleManager.Entity.SizeClass)Basic_Size.SelectedItem;
                    #endregion
                }
                Close = true;// All Save & Validation Complete, Allow Close
            }
            catch
            {
                return;// Cancel
            }

            if (Close)// Close and DialogResalt = true
            {
                DialogResult = true;
                this.Close();
            }
        }
        /// <summary>
        /// Validates settings and fixes some automaticly fixable errors. This is always run before Saving Data.
        /// </summary>
        /// <returns>Validation Pass</returns>
        private bool ValidateSettings()
        {
            bool Pass = true;// The variable that defines if the settings pass validation

            try
            {
                #region Basic Info
                #region Name
                if (String.IsNullOrWhiteSpace(Basic_Name.Text))
                {
                    MessageBox.Show("Name is not valid!", "Name Error", MessageBoxButton.OK, MessageBoxImage.Error);// Name is Not Valid
                    Pass = false;
                }
                else if (MainWindow.SaveManager.SaveData.PokedexData.Pokemon.FindAll(x => x.Species_Name.ToLower() == Basic_Name.Text.ToLower()).Count >= 1 && !Update)
                {
                    MessageBox.Show("Name taken by another Pokemon!", "Name Error", MessageBoxButton.OK, MessageBoxImage.Error);// Name is Taken
                    Pass = false;
                }
                #endregion
                #region Typeing
                if (Basic_Type1.SelectedIndex == -1)// Check if the Primary Type is set, if not set it will fail the validation check
                {
                    MessageBox.Show("You have not selected the pokemons primary type!", "Basic Information Error -> Typeing Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Pass = false;
                }
                else if (Basic_Type2.SelectedIndex == -1)// Check if the Secondary Type is set, if not set it to Primary Type
                {
                    MessageBox.Show("You have not selected the pokemons secondary type, making pokemon Solo Type", "Basic Information Notice -> Typeing Noteice", MessageBoxButton.OK, MessageBoxImage.Information);
                    Basic_Type2.SelectedItem = Basic_Type1.SelectedItem;
                }
                #endregion
                #region ID
                try
                {
                    Decimal ID = Convert.ToDecimal(Basic_ID.Text);

                    if (MainWindow.SaveManager.SaveData.PokedexData.Pokemon.FindAll(x => x.Species_DexID == ID).Count >= 1)
                    {
                        if (!Update || (ID != PokemonData.Species_DexID && Update))
                        {
                            MessageBox.Show("Dex ID taken by another Pokemon!", "Dex Error", MessageBoxButton.OK, MessageBoxImage.Error);// Dex ID is Taken
                            Pass = false;
                        }
                    }
                }
                catch (FormatException)
                {
                    MessageBox.Show("Dex Number not a valid Decimal!", "Dex Error", MessageBoxButton.OK, MessageBoxImage.Error);// Dex ID is not Valid
                    Pass = false;
                }
                #endregion
                #region Size
                if (Basic_Size.SelectedIndex == -1)// Check if the Primary Type is set, if not set it will fail the validation check
                {
                    MessageBox.Show("You have not selected the pokemons size class!", "Basic Information Error -> Size Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Pass = false;
                }
                #endregion
                #region Weight
                if (Basic_Weight.SelectedIndex == -1)// Check if the Primary Type is set, if not set it will fail the validation check
                {
                    MessageBox.Show("You have not selected the pokemons weight class!", "Basic Information Error -> Weight Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Pass = false;
                }
                #endregion
                #endregion

                #region Breeding Info
                #region Gender Chances
                try
                {
                    decimal MC = Convert.ToDecimal(Breeding_MaleChance.Text);
                }
                catch (FormatException)
                {
                    MessageBox.Show("You have not specified a valid Decimal for the Male Gender Chance!", "Breeding Information Error -> Gender Chance Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    Pass = false;
                }
                #endregion

                #endregion
            }
            #region Other Errors
            catch (NullReferenceException)
            {
                MessageBox.Show("No Save File Selected! Unable to Add, Edit or Validate Pokemon Save Data", "Name Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Pass = false;
            }
            catch
            {
                MessageBox.Show("Unknown Validation Error", "Unknown Error", MessageBoxButton.OK, MessageBoxImage.Error);
                Pass = false;
            }
            #endregion

            return Pass;// returns the validation pass state
        }

        private void Add_Button_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }
        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult mbr = MessageBox.Show("All unsaved work will be lost!\nDo you want to close?\n\nYes = Close\nNo = Clear all changes and continue to edit\nCancel = Keep Changes and Keep editing", "", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);

            if (mbr == MessageBoxResult.Yes)
            {
                DialogResult = false;
                Close();
                return;
            }
            else if (mbr == MessageBoxResult.No)
            {
                Load();
                return;
            }
            else if (mbr == MessageBoxResult.Cancel)
            {
                return;
            }
        }

        #region Form Componants Change
        private void Breeding_MaleChance_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                Breeding_FemaleChance.Text = (100 - Convert.ToDecimal(Breeding_MaleChance.Text)).ToString();
            }
            catch { }
        }
        #endregion
    }
}
