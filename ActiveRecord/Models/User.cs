using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ActiveRecord.Core;

namespace ActiveRecord.Models
{
    [Table(TableName = "users")]
    public class User : ActiveRecord<User>
    {
        [Column(FieldName = "name", FieldType = typeof(string))]
        public string Name { get; set; }

        [Column(FieldName = "password", FieldType = typeof(string))]
        public string Password { get; set; }
    }
}
