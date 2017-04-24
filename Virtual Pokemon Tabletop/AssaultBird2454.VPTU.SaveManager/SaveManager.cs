using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssaultBird2454.VPTU.SaveManager
{
    public class SaveManager
    {
        public ProjectInfo VersioningInfo { get; }
        public string SaveFileDir { get; set; }

        /// <summary>
        /// Creates a new instance of a Save File Manager
        /// </summary>
        public SaveManager()
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
        }

        /// <summary>
        /// Load save data to save data class ready for use
        /// </summary>
        /// <returns>Save Data</returns>
        public Data.SaveFile.PTUSaveData LoadSaveData()
        {
            return null;
        }

        private object LoadData_FromSave()
        {
            return null;
        }
        private void SaveData_ToSave()
        {

        }
    }
}
