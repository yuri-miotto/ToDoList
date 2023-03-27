using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Person
    {
        private string _id;
        public string Name { get; set; }

        public Person(string id, string name)
        {
            this._id = id;
            this.Name = name;
        }

        public Person(string name)
        {
            var temp = Guid.NewGuid();
            _id = temp.ToString().Substring(0, 8);

            this.Name = name;
        }

        public override string ToString()
        {
            return "ID: " + this._id + "\nNome: " + this.Name +"\n";
        }

        public string SaveToFile()
        {
            return this._id + ";" + this.Name;
        }
    }
}
