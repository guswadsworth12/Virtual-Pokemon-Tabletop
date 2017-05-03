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
            Setup();

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
        }

        /// <summary>
        /// Used to setup some fields
        /// </summary>
        private void Setup()
        {
            #region Populating Fields
            Basic_Type1.ItemsSource = Enum.GetValues(typeof(BattleManager.Data.Type));
            Basic_Type2.ItemsSource = Enum.GetValues(typeof(BattleManager.Data.Type));
            Basic_Weight.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.WeightClass));
            Basic_Size.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SizeClass));
            Skill_Acrobatics_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Athletics_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Charm_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Combat_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Command_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Focus_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_GeneralEDU_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Gulie_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Intimidate_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Intuition_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_MedicineEDU_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_OccultEDU_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Perception_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_PokemonEDU_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Stealth_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_Survival_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            Skill_TechnologyEDU_Rank.ItemsSource = Enum.GetValues(typeof(BattleManager.Entity.SkillRank));
            #endregion
            #region Defaulting
            Skill_Acrobatics_Rank.SelectedIndex = 1;
            Skill_Athletics_Rank.SelectedIndex = 1;
            Skill_Charm_Rank.SelectedIndex = 1;
            Skill_Combat_Rank.SelectedIndex = 1;
            Skill_Command_Rank.SelectedIndex = 1;
            Skill_Focus_Rank.SelectedIndex = 1;
            Skill_GeneralEDU_Rank.SelectedIndex = 1;
            Skill_Gulie_Rank.SelectedIndex = 1;
            Skill_Intimidate_Rank.SelectedIndex = 1;
            Skill_Intuition_Rank.SelectedIndex = 1;
            Skill_MedicineEDU_Rank.SelectedIndex = 1;
            Skill_OccultEDU_Rank.SelectedIndex = 1;
            Skill_Perception_Rank.SelectedIndex = 1;
            Skill_PokemonEDU_Rank.SelectedIndex = 1;
            Skill_Stealth_Rank.SelectedIndex = 1;
            Skill_Survival_Rank.SelectedIndex = 1;
            Skill_TechnologyEDU_Rank.SelectedIndex = 1;
            #endregion
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
            #region Skill Data
            //Skill Rank Data
            Skill_Acrobatics_Rank.SelectedItem = PokemonData.Species_Skill_Data.Acrobatics_Rank;
            Skill_Athletics_Rank.SelectedItem = PokemonData.Species_Skill_Data.Athletics_Rank;
            Skill_Charm_Rank.SelectedItem = PokemonData.Species_Skill_Data.Charm_Rank;
            Skill_Combat_Rank.SelectedItem = PokemonData.Species_Skill_Data.Combat_Rank;
            Skill_Command_Rank.SelectedItem = PokemonData.Species_Skill_Data.Command_Rank;
            Skill_Focus_Rank.SelectedItem = PokemonData.Species_Skill_Data.Focus_Rank;
            Skill_GeneralEDU_Rank.SelectedItem = PokemonData.Species_Skill_Data.General_Rank;
            Skill_Gulie_Rank.SelectedItem = PokemonData.Species_Skill_Data.Guile_Rank;
            Skill_Intimidate_Rank.SelectedItem = PokemonData.Species_Skill_Data.Intimidate_Rank;
            Skill_Intuition_Rank.SelectedItem = PokemonData.Species_Skill_Data.Intuition_Rank;
            Skill_MedicineEDU_Rank.SelectedItem = PokemonData.Species_Skill_Data.Medicine_Rank;
            Skill_OccultEDU_Rank.SelectedItem = PokemonData.Species_Skill_Data.Occult_Rank;
            Skill_Perception_Rank.SelectedItem = PokemonData.Species_Skill_Data.Perception_Rank;
            Skill_PokemonEDU_Rank.SelectedItem = PokemonData.Species_Skill_Data.Pokemon_Rank;
            Skill_Stealth_Rank.SelectedItem = PokemonData.Species_Skill_Data.Stealth_Rank;
            Skill_Survival_Rank.SelectedItem = PokemonData.Species_Skill_Data.Survival_Rank;
            Skill_TechnologyEDU_Rank.SelectedItem = PokemonData.Species_Skill_Data.Technology_Rank;

            //Skill Mod Data
            Skill_Acrobatics_Mod.Value = PokemonData.Species_Skill_Data.Acrobatics_Mod;
            Skill_Athletics_Mod.Value = PokemonData.Species_Skill_Data.Athletics_Mod;
            Skill_Charm_Mod.Value = PokemonData.Species_Skill_Data.Charm_Mod;
            Skill_Combat_Mod.Value = PokemonData.Species_Skill_Data.Combat_Mod;
            Skill_Command_Mod.Value = PokemonData.Species_Skill_Data.Command_Mod;
            Skill_Focus_Mod.Value = PokemonData.Species_Skill_Data.Focus_Mod;
            Skill_GeneralEDU_Mod.Value = PokemonData.Species_Skill_Data.General_Mod;
            Skill_Gulie_Mod.Value = PokemonData.Species_Skill_Data.Guile_Mod;
            Skill_Intimidate_Mod.Value = PokemonData.Species_Skill_Data.Intimidate_Mod;
            Skill_Intuition_Mod.Value = PokemonData.Species_Skill_Data.Intuition_Mod;
            Skill_MedicineEDU_Mod.Value = PokemonData.Species_Skill_Data.Medicine_Mod;
            Skill_OccultEDU_Mod.Value = PokemonData.Species_Skill_Data.Occult_Mod;
            Skill_Perception_Mod.Value = PokemonData.Species_Skill_Data.Perception_Mod;
            Skill_PokemonEDU_Mod.Value = PokemonData.Species_Skill_Data.Pokemon_Mod;
            Skill_Stealth_Mod.Value = PokemonData.Species_Skill_Data.Stealth_Mod;
            Skill_Survival_Mod.Value = PokemonData.Species_Skill_Data.Survival_Mod;
            Skill_TechnologyEDU_Mod.Value = PokemonData.Species_Skill_Data.Technology_Mod;
            #endregion
            #region Links
            #region Moves
            if (PokemonData.Moves == null) { PokemonData.Moves = new List<VPTU.Pokedex.Pokemon.Move_Link>(); }
            foreach (AssaultBird2454.VPTU.Pokedex.Pokemon.Move_Link ML in PokemonData.Moves)
            {
                Moves_List.Items.Add(ML);
            }
            #endregion

            #endregion
        }
        /// <summary>
        /// Saves Modifications or Adds a new entry to the Pokedex
        /// </summary>
        private void Save()
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
            #region Skill Data
            //Skill Rank Data
            PokemonData.Species_Skill_Data.Acrobatics_Rank = (BattleManager.Entity.SkillRank)Skill_Acrobatics_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Athletics_Rank = (BattleManager.Entity.SkillRank)Skill_Athletics_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Charm_Rank = (BattleManager.Entity.SkillRank)Skill_Charm_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Combat_Rank = (BattleManager.Entity.SkillRank)Skill_Combat_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Command_Rank = (BattleManager.Entity.SkillRank)Skill_Command_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Focus_Rank = (BattleManager.Entity.SkillRank)Skill_Focus_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.General_Rank = (BattleManager.Entity.SkillRank)Skill_GeneralEDU_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Guile_Rank = (BattleManager.Entity.SkillRank)Skill_Gulie_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Intimidate_Rank = (BattleManager.Entity.SkillRank)Skill_Intimidate_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Intuition_Rank = (BattleManager.Entity.SkillRank)Skill_Intuition_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Medicine_Rank = (BattleManager.Entity.SkillRank)Skill_MedicineEDU_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Occult_Rank = (BattleManager.Entity.SkillRank)Skill_OccultEDU_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Perception_Rank = (BattleManager.Entity.SkillRank)Skill_Perception_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Pokemon_Rank = (BattleManager.Entity.SkillRank)Skill_PokemonEDU_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Stealth_Rank = (BattleManager.Entity.SkillRank)Skill_Stealth_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Survival_Rank = (BattleManager.Entity.SkillRank)Skill_Survival_Rank.SelectedItem;
            PokemonData.Species_Skill_Data.Technology_Rank = (BattleManager.Entity.SkillRank)Skill_TechnologyEDU_Rank.SelectedItem;

            //Skill Mod Data
            PokemonData.Species_Skill_Data.Acrobatics_Mod = (int)Skill_Acrobatics_Mod.Value;
            PokemonData.Species_Skill_Data.Athletics_Mod = (int)Skill_Athletics_Mod.Value;
            PokemonData.Species_Skill_Data.Charm_Mod = (int)Skill_Charm_Mod.Value;
            PokemonData.Species_Skill_Data.Combat_Mod = (int)Skill_Combat_Mod.Value;
            PokemonData.Species_Skill_Data.Command_Mod = (int)Skill_Command_Mod.Value;
            PokemonData.Species_Skill_Data.Focus_Mod = (int)Skill_Focus_Mod.Value;
            PokemonData.Species_Skill_Data.General_Mod = (int)Skill_GeneralEDU_Mod.Value;
            PokemonData.Species_Skill_Data.Guile_Mod = (int)Skill_Gulie_Mod.Value;
            PokemonData.Species_Skill_Data.Intimidate_Mod = (int)Skill_Intimidate_Mod.Value;
            PokemonData.Species_Skill_Data.Intuition_Mod = (int)Skill_Intuition_Mod.Value;
            PokemonData.Species_Skill_Data.Medicine_Mod = (int)Skill_MedicineEDU_Mod.Value;
            PokemonData.Species_Skill_Data.Occult_Mod = (int)Skill_OccultEDU_Mod.Value;
            PokemonData.Species_Skill_Data.Perception_Mod = (int)Skill_Perception_Mod.Value;
            PokemonData.Species_Skill_Data.Pokemon_Mod = (int)Skill_PokemonEDU_Mod.Value;
            PokemonData.Species_Skill_Data.Stealth_Mod = (int)Skill_Stealth_Mod.Value;
            PokemonData.Species_Skill_Data.Survival_Mod = (int)Skill_Survival_Mod.Value;
            PokemonData.Species_Skill_Data.Technology_Mod = (int)Skill_TechnologyEDU_Mod.Value;
            #endregion

            #region Links
            #region Moves
            PokemonData.Moves.Clear();
            foreach (VPTU.Pokedex.Pokemon.Move_Link link in Moves_List.Items)
            {
                PokemonData.Moves.Add(link);
            }
            #endregion
            #endregion
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

            DialogResult = true;
            Close();
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
                DialogResult = null;
                return;
            }
            else if (mbr == MessageBoxResult.Cancel)
            {
                DialogResult = null;
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

        #region Link Moves
        /// <summary>
        /// Add Link Button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LinkMove_Button_Click(object sender, RoutedEventArgs e)
        {
            Move_Link link = new Move_Link();// Create a new MoveLink Window to create a link with
            bool? add = link.ShowDialog();// Shows the Link Window, Creates a Dialog to return true if it added successfully

            if (add == true)
            {
                Moves_List.Items.Add(link.LinkData);// Add MoveLink to list if not canceled
            }
        }
        /// <summary>
        /// Edit Link Button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditLinkMove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Moves_List.SelectedItem == null) { return; }// Returns if selection is null

            Move_Link link = new Move_Link((VPTU.Pokedex.Pokemon.Move_Link)Moves_List.SelectedItem);// Creates a new MoveLink Window to modify link with
            link.ShowDialog();// Shows the Link Window
        }
        /// <summary>
        /// Remove Link Button is pressed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveLinkMove_Button_Click(object sender, RoutedEventArgs e)
        {
            if (Moves_List.SelectedItem == null) { return; }// Returns if selection is null
            Moves_List.Items.Remove(Moves_List.SelectedItem);// Removes Link from list
        }
        #endregion
    }
}