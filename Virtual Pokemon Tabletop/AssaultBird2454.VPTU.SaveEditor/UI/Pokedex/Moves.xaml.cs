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
        VPTU.Pokedex.Moves.MoveData MoveData;

        public Moves(VPTU.Pokedex.Moves.MoveData _MoveData = null)
        {
            InitializeComponent();

            if(MoveData == null)
            {
                MoveData = new VPTU.Pokedex.Moves.MoveData();
            }else
            {
                MoveData = _MoveData;
                //Load Here
            }
        }
    }
}
