using LibraryCode.Src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicLibrary.DBContexts
{
    public class Database
    {
        private static EntityFramework instance;

        private Database() { }

        public static EntityFramework Instance
        {
            get
            {
                if (instance == null)
                    instance = new EntityFramework();
                return instance;
            }
        }
    }
}
