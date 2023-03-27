using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ToDoList
{
    internal class ToDo
    {
        public string _id;
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string Responsavel { get; set; }

        public bool Status;

        public DateTime DataInicial;

        public string DataFinal;

        public ToDo(string id, string descricao, string categoria, string responsavel, DateTime dataInicial, 
            string dataFinal, bool status)
        {
            this._id = id;

            this.Categoria = categoria;

            this.Responsavel = responsavel;

            this.Descricao = descricao;

            this.DataInicial = dataInicial;

            this.DataFinal = dataFinal;

            this.Status = status;
        }

        public ToDo(string descricao)
        {
            var temp = Guid.NewGuid();
            _id = temp.ToString().Substring(0, 8);

            this.Descricao = descricao;

            this.DataInicial = DateTime.Now;

            this.Status = true;
        }

        public override string ToString()
        {
            return "ID: " + this._id + "\nDescrição: " + this.Descricao + "\nCategoria: " + this.Categoria +
                "\nResponsável: " + this.Responsavel + "\nData inicial: " + this.DataInicial + 
                "\nData final: " + this.DataFinal + "\n";
        }

        public string SaveToFile()
        {
            return this._id + ";" + this.Descricao + ";" + this.Categoria + ";" + this.Responsavel + ";" + 
                this.DataInicial + ";" + this.DataFinal + ";" + this.Status;
        }
    }
}
