using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssaultBird2454.VPTU.Pokedex.Pokemon
{
    public class PokemonData
    {
        public PokemonData()
        {
            Species_Capability_Data = new BattleManager.Entity.Capability_Data();
            Species_Skill_Data = new BattleManager.Entity.Skill_Data();
        }

        /// <summary>
        /// The Pokedex Number for the Pokemon
        /// </summary>
        public decimal Species_DexID { get; set; }
        /// <summary>
        /// The Species name for the Pokemon
        /// </summary>
        public string Species_Name { get; set; }

        public BattleManager.Entity.Skill_Data Species_Skill_Data { get; set; }
        public BattleManager.Entity.Capability_Data Species_Capability_Data { get; set; }

        public BattleManager.Data.Type Species_Type1 { get; set; }
        public BattleManager.Data.Type Species_Type2 { get; set; }
        public BattleManager.Entity.SizeClass Species_SizeClass { get; set; }
        public BattleManager.Entity.WeightClass Species_WeightClass { get; set; }

        public PokemonGender Species_Genders { get; set; }
        public decimal Species_Gender_Chance_Male { get; set; }
        public decimal Species_Gender_Chance_Female { get; set; }

        public int Species_BaseStats_HP { get; set; }
        public int Species_BaseStats_Attack { get; set; }
        public int Species_BaseStats_Defence { get; set; }
        public int Species_BaseStats_SpAttack { get; set; }
        public int Species_BaseStats_SpDefence { get; set; }
        public int Species_BaseStats_Speed { get; set; }

        #region Texture and Resource
        public string Sprite_Normal { get; set; }
        public string Sprite_Shiny { get; set; }
        public string Sprite_Egg { get; set; }
        public string Sound_Cry { get; set; }
        #endregion

        public List<Move_Link> Moves { get; set; }
        public List<Ability_Link> Abilitys { get; set; }
        public List<Evolution_Link> Evolutions { get; set; }
    }
}
