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
    /// Interaction logic for Moves.xaml
    /// </summary>
    public partial class Moves : Window
    {
        public VPTU.Pokedex.Moves.MoveData MoveData;
        private SaveManager.Data.SaveFile.PTUSaveData SaveData;

        public Moves(SaveManager.Data.SaveFile.PTUSaveData _SaveData, VPTU.Pokedex.Moves.MoveData _MoveData = null)
        {
            InitializeComponent();// Creates the Window

            SaveData = _SaveData;

            Setup();// Executes the setup script

            if(_MoveData == null)
            {
                MoveData = new VPTU.Pokedex.Moves.MoveData();// If no specified data, then create a new data class
            }else
            {
                MoveData = _MoveData;// Save the specified data class to a variable for latter
                Load();// Load the data
            }
        }

        /// <summary>
        /// Set's up the form
        /// </summary>
        public void Setup()
        {
            #region Data Binding
            Battle_ActionType.ItemsSource = Enum.GetValues(typeof(BattleManager.Data.Action_Type));
            Battle_Class.ItemsSource = Enum.GetValues(typeof(BattleManager.Data.MoveClass));
            Battle_Frequency.ItemsSource = Enum.GetValues(typeof(BattleManager.Data.Move_Frequency));
            Battle_Type.ItemsSource = Enum.GetValues(typeof(BattleManager.Data.Type));

            Contest_Effect.ItemsSource = Enum.GetValues(typeof(ContestManager.Data.Contest_Effects));
            Contest_Type.ItemsSource = Enum.GetValues(typeof(ContestManager.Data.Contest_Type));
            #endregion
            #region Data Defaulting
            Battle_ActionType.SelectedIndex = 0;
            Battle_Class.SelectedIndex = 0;
            Battle_Frequency.SelectedIndex = 0;
            Battle_Type.SelectedIndex = 0;

            Contest_Effect.SelectedIndex = 0;
            Contest_Type.SelectedIndex = 0;
            #endregion
        }

        /// <summary>
        /// Loads the data from the MoveData Object
        /// </summary>
        public void Load()
        {
            #region Basic Info
            Basic_Name.Text = MoveData.Name;
            Basic_Desc.Text = MoveData.Description;
            #endregion

            #region Battle Details
            Battle_ActionType.SelectedItem = MoveData.Move_ActionType;
            Battle_Class.SelectedItem = MoveData.Move_Class;
            Battle_Frequency.SelectedItem = MoveData.Move_Frequency;
            Battle_Type.SelectedItem = MoveData.Move_Type;

            Battle_AC.Value = MoveData.Move_Accuracy;
            Battle_DB.Value = (int)MoveData.Move_DamageBase;
            Battle_UseLimit.Value = MoveData.Move_Frequency_Limit;
            #endregion

            #region Contest Details
            Contest_Effect.SelectedItem = MoveData.Contest_Effect;
            Contest_Type.SelectedItem = MoveData.Contest_Type;
            #endregion
        }

        /// <summary>
        /// Saves the data to the MoveData Object
        /// </summary>
        public void Save()
        {
            #region Basic Info
            MoveData.Name = Basic_Name.Text;
            MoveData.Description = Basic_Desc.Text;
            #endregion

            #region Battle Details
            MoveData.Move_ActionType = (BattleManager.Data.Action_Type)Battle_ActionType.SelectedItem;
            MoveData.Move_Class = (BattleManager.Data.MoveClass)Battle_Class.SelectedItem;
            MoveData.Move_Frequency = (BattleManager.Data.Move_Frequency)Battle_Frequency.SelectedItem;
            MoveData.Move_Type = (BattleManager.Data.Type)Battle_Type.SelectedItem;

            MoveData.Move_Accuracy = (int)Battle_AC.Value;
            MoveData.Move_DamageBase = (BattleManager.Data.DamageBase)Battle_DB.Value;
            MoveData.Move_Frequency_Limit = (int)Battle_UseLimit.Value;
            #endregion

            #region Contest Details
            MoveData.Contest_Effect = (ContestManager.Data.Contest_Effects)Contest_Effect.SelectedItem;
            MoveData.Contest_Type = (ContestManager.Data.Contest_Type)Contest_Type.SelectedItem;
            #endregion
        }

        private void Submit_Button_Click(object sender, RoutedEventArgs e)
        {
            Save();// Saves Data
        }
    }
}
