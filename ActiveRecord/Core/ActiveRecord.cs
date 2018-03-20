using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace ActiveRecord.Core
{
    public abstract class ActiveRecord<T> : INotifyPropertyChanged where T : ActiveRecord<T>, new()
    {
        private int _id;

        public int ID
        {
            get { return _id; }
            set
            {
                _id = value;
                OnPropertyChanged("ID");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public static T Find(int id)
        {
            var record = new T();
            var x = new Dictionary<string, object> {{"id", id}};
            var sql = CreateFindQuery(x);
            Console.WriteLine(sql);
            Console.WriteLine("Record found");
            return record;
        }

        public static T FindBy(Dictionary<string, object> parameters, string databaseName = "")
        {
            var record = new T();
            var sql = CreateFindQuery(parameters, databaseName);
            Console.WriteLine(sql);
            Console.WriteLine("Record found by " + string.Join(", ",parameters.Keys.ToArray()));
            return record;
        }

        public static List<T> Where(Dictionary<string, object> parameters)
        {
            return new List<T>
            {
                new T(),
                new T(),
                new T()
            };
        }

        public void Save()
        {
            if (ID == 0)
            {
                Create();
            }
            else
            {
                Update();
            }
        }

        public void Delete()
        {
            Console.WriteLine("Record Deleted");
        }

        private void Update()
        {
            Console.WriteLine("Record Updated");
        }

        private void Create()
        {
            Console.WriteLine("Record Created");
        }

        public static string CreateFindQuery(Dictionary<string, object> parameters, string databaseName = "")
        {
            var tableName = GetTableName(databaseName);
            var filterList = new List<string>();
            foreach (var parameter in parameters)
            {
                filterList.Add(string.Format("{0} = ?{0}", parameter.Key));
            }
            var whereCondition = "WHERE " + string.Join(" AND ", filterList.ToArray());
            return string.Format("SELECT * FROM {0} ", tableName) + whereCondition;
        }

        private static string GetTableName(string databaseName ="")
        {
            var tableAttribute =
                typeof (T).GetCustomAttributes(typeof (TableAttribute), true).FirstOrDefault() as TableAttribute;

            if (tableAttribute != null)
            {
                return string.IsNullOrEmpty(databaseName)
                    ? tableAttribute.TableName
                    : string.Format("`{0}`.`{1}`", databaseName, tableAttribute.TableName);

            }
            return "";
        }
    }
}