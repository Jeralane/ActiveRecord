using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActiveRecord.Core
{
    public class ColumnAttribute : Attribute
    {
        public string FieldName { get; set; }
        public Type FieldType { get; set; }
    }
}