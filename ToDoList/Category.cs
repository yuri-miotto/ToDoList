using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList
{
    internal class Category
    {
        public string categoryName { get; set; }

        public Category(string name)
        {
            this.categoryName = name;
        }

        public override string ToString()
        {
            return "Categoria: " + this.categoryName;
        }

        public string SaveToFile()
        {
            return categoryName;
        }
    }
}
