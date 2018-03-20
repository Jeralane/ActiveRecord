using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveRecord.Models;

namespace ActiveRecord
{
    class Program
    {
        static void Main(string[] args)
        {
            var x = User.Find(1);
            var filter = new Dictionary<string, object>() { { "name", "Jess Alejo" }, { "password", "password" }};
            var y = User.FindBy(filter, "safebox_2017_production");
           Console.WriteLine(x);

            x.Save();
            x.Delete();
        }
    }
}
