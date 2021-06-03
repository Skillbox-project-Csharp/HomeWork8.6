using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork8._6
{
    class Program
    {
        static void Main(string[] args)
        {

            Organization org = new Organization("Amadeus"); 
            MenuOrganization menuOrganization = new MenuOrganization();
            menuOrganization.StartMenu(org);

        }
    }
}
