using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8._6
{
    interface FileManager
    {
        bool Save(string path, object objSave);
        bool Load(string path,out Organization objLoad);
    }
}
