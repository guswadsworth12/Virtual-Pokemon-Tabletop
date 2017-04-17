using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssaultBird2454.VPTU.SaveManager.Data.SaveFile
{
    /// <summary>
    /// A Save Data Class designed for backup purposes. It supports checking if a part of the save has been modified outside the Client/Server
    /// </summary>
    public class PTUSaveData_ECC
    {
        public PTUSaveData_ECC() { }
        public PTUSaveData_ECC(string _Hash, PTUSaveData _Data)
        {
            Hash = _Hash;
            Data = _Data;
        }

        public string Hash { get; set; }
        public PTUSaveData Data { get; set; }
    }

    /// <summary>
    /// A Save Data Class designed to handle the save data
    /// </summary>
    public class PTUSaveData
    {
        public PTUSaveData()
        {

        }
        public PTUSaveData(bool InitNewSave)
        {
            if (InitNewSave)
            {
                Trainers = new List<Data.Entity.Trainer>();
                NPCs = new List<Data.Entity.NPC>();
                Pokemon = new List<Data.Entity.Pokemon>();

                EntityGroups = new List<Data.Entity.Group>();

                MapFiles = new List<Resources.MapFileData>();
                Maps = new List<Resources.MapData>();

                AudioResources = new List<Data.Audio.Audio_Data>();
                ImageResources = new List<Data.Image.Image_Data>();

                PokedexData = new Pokedex(true);
            }
        }

        #region Data
        public Pokedex PokedexData;
        #endregion

        #region Entity Data
        public List<Data.Entity.Trainer> Trainers;
        public List<Data.Entity.NPC> NPCs;
        public List<Data.Entity.Pokemon> Pokemon;

        public List<Data.Entity.Group> EntityGroups;
        #endregion

        #region Tabletop
        public List<Resources.MapFileData> MapFiles;
        public List<Resources.MapData> Maps;
        #endregion
        #region Resources
        public List<Data.Audio.Audio_Data> AudioResources;
        public List<Data.Image.Image_Data> ImageResources;
        #endregion
    }
}
