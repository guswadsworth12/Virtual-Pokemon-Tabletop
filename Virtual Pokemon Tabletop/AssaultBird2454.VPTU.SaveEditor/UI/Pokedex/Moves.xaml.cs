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

        public Moves(VPTU.Pokedex.Moves.MoveData _MoveData = null)
        {
            InitializeComponent();
            Setup();// Executes the setup script

            if(MoveData == null)
            {
                MoveData = new VPTU.Pokedex.Moves.MoveData();
            }else
            {
                MoveData = _MoveData;
                Load();
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

        }

        /// <summary>
        /// Saves the data to the MoveData Object
        /// </summary>
        public void Save()
        {

        }
    }
}
