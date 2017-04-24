using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssaultBird2454.VPTU.SaveManager
{
    public enum SaveData_Dir { Pokedex_Pokemon, Pokedex_Moves, Pokedex_Abilities, Pokedex_Items }

    public class SaveManager
    {
        #region Variables
        public ProjectInfo VersioningInfo { get; }
        public string SaveFileDir { get; }

        /// <summary>
        /// A Save Data Object for use inside the software, This is Saved to the file when Save_SaveData() is called
        /// </summary>
        public Data.SaveFile.PTUSaveData SaveData { get; set; }
        #endregion

        /// <summary>
        /// Creates a new instance of a Save File Manager
        /// </summary>
        /// <param name="SelectedSaveFile">The Directory of the save file that will be used</param>
        public SaveManager(string SelectedSaveFile)
        {
            //Load Versioning information
            #region Versioning Info
            using (Stream str = Assembly.GetExecutingAssembly().GetManifestResourceStream("AssaultBird2454.VPTU.SaveManager.ProjectVariables.json"))
            {
                using (StreamReader read = new StreamReader(str))
                {
                    VersioningInfo = Newtonsoft.Json.JsonConvert.DeserializeObject<ProjectInfo>(read.ReadToEnd());
                }
            }
            #endregion

            SaveFileDir = SelectedSaveFile;// Sets the property containing the Save File Directory
        }

        /// <summary>
        /// Load save data to save data class ready for use
        /// </summary>
        /// <returns>Save Data</returns>
        public void Load_SaveData()
        {
            SaveData = new Data.SaveFile.PTUSaveData(true);
            SaveData.PokedexData.Pokemon = LoadData_FromSave<List<Pokedex.Pokemon.PokemonData>>(GetSaveFile_DataDir(SaveData_Dir.Pokedex_Pokemon));
            SaveData.PokedexData.Moves = LoadData_FromSave<List<Pokedex.Moves.MoveData>>(GetSaveFile_DataDir(SaveData_Dir.Pokedex_Moves));
            SaveData.PokedexData.Abilitys = LoadData_FromSave<List<Pokedex.Abilities.AbilitieData>>(GetSaveFile_DataDir(SaveData_Dir.Pokedex_Abilities));
            SaveData.PokedexData.Items = LoadData_FromSave<List<Pokedex.Items.ItemData>>(GetSaveFile_DataDir(SaveData_Dir.Pokedex_Items));
        }
        /// <summary>
        /// Saves save data to save file
        /// </summary>
        public void Save_SaveData()
        {
            SaveData_ToSave(GetSaveFile_DataDir(SaveData_Dir.Pokedex_Pokemon), SaveData.PokedexData.Pokemon);
            SaveData_ToSave(GetSaveFile_DataDir(SaveData_Dir.Pokedex_Moves), SaveData.PokedexData.Moves);
            SaveData_ToSave(GetSaveFile_DataDir(SaveData_Dir.Pokedex_Abilities), SaveData.PokedexData.Abilitys);
            SaveData_ToSave(GetSaveFile_DataDir(SaveData_Dir.Pokedex_Items), SaveData.PokedexData.Items);
        }

        #region Load and Save
        /// <summary>
        /// Loads Data from the save file
        /// </summary>
        /// <typeparam name="T">Type of data being loaded</typeparam>
        /// <param name="SaveFile_DataDir">The Directory where the data should be loaded from in the save file</param>
        /// <returns>Loaded Object</returns>
        public T LoadData_FromSave<T>(string SaveFile_DataDir)
        {
            //Creates a stream to read the save file from
            using (StreamReader Reader = new StreamReader(SaveFileDir))
            {
                //Creates an object to read the archive data from
                using (ZipArchive archive = new ZipArchive(Reader.BaseStream, ZipArchiveMode.Read))
                {
                    ZipArchiveEntry entry = archive.GetEntry(SaveFile_DataDir);// Gets the entry to be read from

                    //Creates a stream to read the data from
                    using (StreamReader DataReader = new StreamReader(entry.Open()))
                    {
                        return Newtonsoft.Json.JsonConvert.DeserializeObject<T>(DataReader.ReadToEnd());// Returns the save file data
                    }
                }
            }
        }
        /// <summary>
        /// Saves Data to the save file
        /// </summary>
        /// <param name="SaveFile_DataDir">The Directory where the data should be saved in the file</param>
        /// <param name="Object">Object to save</param>
        public void SaveData_ToSave(string SaveFile_DataDir, object Object)
        {
            //Creates a stream to write any save data to a file
            using (StreamWriter Writer = new StreamWriter(SaveFileDir))
            {
                //Creates an object to write archive data to
                using (ZipArchive archive = new ZipArchive(Writer.BaseStream, ZipArchiveMode.Update))
                {
                    ZipArchiveEntry entry = archive.GetEntry(SaveFile_DataDir);// Gets the specified entry if it exists ready to write to
                    if(entry == null)
                    {
                        archive.CreateEntry(SaveFile_DataDir);// If the entry does not exist, it will create a new one
                    }

                    //Creates a stream to Write data to the entry
                    using (StreamWriter DataWriter = new StreamWriter(entry.Open()))
                    {
                        DataWriter.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(Object));// Serialises and Writes to file
                    }
                }
            }
        }
        /// <summary>
        /// Gets the Path to a specific file in the Save Data Structure (Excluding Resources or Save Files from Plugins)
        /// </summary>
        /// <param name="DirType">File requested</param>
        /// <returns>Path to file</returns>
        internal string GetSaveFile_DataDir(SaveData_Dir DirType)
        {
            switch (DirType)
            {
                case SaveData_Dir.Pokedex_Pokemon:
                    return "Pokedex/Pokemon.json";
                case SaveData_Dir.Pokedex_Moves:
                    return "Pokedex/Moves.json";
                case SaveData_Dir.Pokedex_Abilities:
                    return "Pokedex/Abilities.json";
                case SaveData_Dir.Pokedex_Items:
                    return "Pokedex/Items.json";

                default:
                    return null;
            }
        }
        #endregion
    }
}
