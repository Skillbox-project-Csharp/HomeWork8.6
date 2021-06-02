using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace HomeWork8._6
{
    class XMLManager : FileManager
    {

        public bool Load(string path,out Organization objLoad)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Organization));
            try
            {
                using (Stream fStream = new FileStream(path, FileMode.Open, FileAccess.Read))
                {
                    objLoad = xmlSerializer.Deserialize(fStream) as Organization;
                }
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

        public  bool Save(string path, object objSave)
        {
            try
            {
                XmlSerializer xmlSerializer = new XmlSerializer(objSave.GetType());
                using (Stream fStream = new FileStream(path, FileMode.Create, FileAccess.Write))
                {
                    xmlSerializer.Serialize(fStream, objSave);
                }
            }
            catch(FileNotFoundException)
            {
                return false;
            }
            catch(DirectoryNotFoundException)
            {
                return false;
            }
            catch(IOException)
            {
                return false;
            }
            return true;
            
        }

    }
}
