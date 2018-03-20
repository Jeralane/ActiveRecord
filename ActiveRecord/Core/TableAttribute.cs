using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecord.Core
{
    public class TableAttribute : Attribute
    {
        public string TableName { get; set; }
    }
}
