using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8._6
{
    class JSONManager : FileManager
    {
        public bool Load(string path, out Organization objLoad)
        {
            try
            {
                string json = File.ReadAllText(path);
                objLoad = JsonConvert.DeserializeObject<Organization>(json);
            }
            catch (FileNotFoundException)
            {
                objLoad = null;
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                objLoad = null;
                return false;
            }
            catch (IOException)
            {
                objLoad = null;
                return false;
            }
            return true;
        }

        public bool Save(string path, object objSave)
        {
            try
            {
                string json = JsonConvert.SerializeObject(objSave);
                File.WriteAllText(path, json);
            }
            catch (FileNotFoundException)
            {
                return false;
            }
            catch (DirectoryNotFoundException)
            {
                return false;
            }
            catch (IOException)
            {
                return false;
            }

            return true;
        }
    }
}
