using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssaultBird2454.VPTU.Pokedex.Save_Data
{
    /// <summary>
    /// A Save Data Class designed for pokedex related data
    /// </summary>
    public class Pokedex
    {
        /// <summary>
        /// Creates a new Pokedex Save Data Manager
        /// </summary>
        /// <param name="InitNewSave">Initialize new data</param>
        public Pokedex(bool InitNewSave = false)
        {
            if (InitNewSave)
            {
                Moves = new List<Data.Pokedex.Moves.Move_Data>();
                Pokemon = new List<Data.Pokedex.Pokemon.Pokemon_Data>();
                Abilitys = new List<Data.Pokedex.Abilitys.Ability_Data>();
                Items = new List<Data.Pokedex.Items.Item_Data>();
            }
        }

        public List<Data.Pokedex.Moves.Move_Data> Moves;
        public List<Data.Pokedex.Pokemon.Pokemon_Data> Pokemon;
        public List<Data.Pokedex.Abilitys.Ability_Data> Abilitys;
        public List<Data.Pokedex.Items.Item_Data> Items;
    }
}
