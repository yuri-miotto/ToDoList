using System.Collections.Generic;
using System.ComponentModel.Design;
using ToDoList;
internal class Program
{
    

    private static void Main(string[] args)
    {
        List<Category> categorias = new List<Category>();
        List<Person> responsaveis = new List<Person>();
        List<ToDo> afazeres = new List<ToDo>();

        afazeres = CarregarAfazeres(afazeres);
        categorias = CarregarCategorias(categorias);
        responsaveis = CarregarResponsaveis(responsaveis);

        int opc = Menu();
        do
        {
            opc = Menu();
            switch (opc)
            {
                case 1:
                    afazeres.Add(CadastrarTarefa());
                    break;
                case 2:
                    categorias.Add(CadastrarCategoria());
                    break;
                case 3:
                    responsaveis.Add(CadastrarResponsavel());
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Informe o ID da tarefa: ");
                    string id = Console.ReadLine();
                    FinalizarTarefa(afazeres, id);
                    break;
                case 5:
                    Console.Clear();
                    MostrarAfazeres(afazeres);
                    Console.ReadLine();
                    break;
                case 6:
                    Console.Clear();
                    MostrarTarefasConcluidas(afazeres);
                    Console.ReadLine();
                    break;
                case 7:
                    Console.Clear();
                    MostrarCategorias(categorias);
                    Console.ReadLine();
                    break;
                case 8:
                    Console.Clear();
                    MostrarResponsaveis(responsaveis);
                    Console.ReadLine();
                    break;
                case 9:
                    GravarAfazeres(afazeres);
                    GravarCategorias(categorias);
                    GravarResponsaveis(responsaveis);
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("\nOpção inválida");
                    Thread.Sleep(1000);
                    break;
            }
        } while (opc != 9);


    }

    private static int Menu()
    {
        Console.Clear();
        Console.WriteLine(">>>> Menu Principal <<<<");
        Console.WriteLine("1- Cadastrar uma nova tarefa");
        Console.WriteLine("2- Cadastrar uma categoria");
        Console.WriteLine("3- Cadastrar uma pessoa responsável");
        Console.WriteLine("4- Finalizar uma tarefa");
        Console.WriteLine("5- Mostrar a lista de tarefas à fazer");
        Console.WriteLine("6- Mostrar a lista de tarefas finalizadas");
        Console.WriteLine("7- Mostrar a lista de categorias");
        Console.WriteLine("8- Mostrar a lista de responsáveis");
        Console.WriteLine("9- Sair");
        Console.WriteLine("Informe a opção desejada....");

        int opc = int.Parse(Console.ReadLine());
        return opc;
    }


    private static ToDo CadastrarTarefa()
    {
        Console.Clear();
        Console.WriteLine("Informe a descrição da tarefa: ");
        string descricao = Console.ReadLine();
        ToDo tarefa = new ToDo(descricao);

        Console.Clear();
        Console.WriteLine("Informe a categoria da tarefa: ");
        string categoria = Console.ReadLine();
        tarefa.Categoria = categoria;

        Console.Clear();
        Console.WriteLine("Informe o responsável pela tarefa tarefa: ");
        string responsavel = Console.ReadLine();
        tarefa.Responsavel = responsavel;

        Console.Clear();
        Console.WriteLine("Informe a data prevista para finalizar a tarefa: ");
        string data = Console.ReadLine();
        tarefa.DataFinal = data;

        return tarefa;
    }

    private static Category CadastrarCategoria()
    {
        Console.Clear();
        Console.WriteLine("Informe o nome da categoria: ");
        string nome = Console.ReadLine();
        Category categoria = new Category(nome);
        
        return categoria;
    }

    private static Person CadastrarResponsavel()
    {
        Console.Clear();
        Console.WriteLine("Informe o nome de uma pessoa: ");
        string nome = Console.ReadLine();
        Person pessoa = new Person(nome);
        return pessoa;
    }

    private static void FinalizarTarefa(List<ToDo> afazeres, string id)
    {
        foreach(ToDo tarefa in afazeres)
        {
            if(tarefa._id == id)
            {
                tarefa.Status = false;
            }
        }
    }

    private static void MostrarAfazeres(List<ToDo> afazeres)
    {
        foreach (ToDo tarefa in afazeres)
        {
            if(tarefa.Status == true)
            {
                Console.WriteLine(tarefa.ToString());
            }
            
        }
    }

    private static void MostrarTarefasConcluidas(List<ToDo> afazeres)
    {
        foreach (ToDo tarefa in afazeres)
        {
            if (tarefa.Status == false)
            {
                Console.WriteLine(tarefa.ToString());
            }
        }
    }

    private static void MostrarCategorias(List<Category>categorias)
    {
        foreach (Category categoria in categorias)
        {
            Console.WriteLine(categoria.ToString());
        }
    }

    private static void MostrarResponsaveis(List<Person> responsaveis)
    {
        foreach (Person responsavel in responsaveis)
        {
            Console.WriteLine(responsavel.ToString());
        }
    }

    private static void GravarAfazeres(List<ToDo> afazeres)
    {
        StreamWriter sw = new StreamWriter("afazeres.txt");
        for (int i = 0; i < afazeres.Count; i++)
        {
            sw.WriteLine(afazeres[i].SaveToFile());
        }
        sw.Close();
    }

    private static void GravarCategorias(List<Category> categorias)
    {
        StreamWriter sw = new StreamWriter("categorias.txt");
        for (int i = 0; i < categorias.Count; i++)
        {
            sw.WriteLine(categorias[i].SaveToFile());
        }
        sw.Close();
    }

    private static void GravarResponsaveis(List<Person> responsaveis)
    {
        StreamWriter sw = new StreamWriter("responsaveis.txt");
        for (int i = 0; i < responsaveis.Count; i++)
        {
            sw.WriteLine(responsaveis[i].SaveToFile());
        }
        sw.Close();
    }

    private static List<ToDo> CarregarAfazeres(List<ToDo> afazeres)
    {
        if (File.Exists("afazeres.txt"))
        {
            StreamReader sr = new StreamReader("afazeres.txt");

            do
            {
                string[] tarefa = sr.ReadLine().Split(";");
                string id = tarefa[0];
                string descricao = tarefa[1];
                string categoria = tarefa[2];
                string responsavel = tarefa[3];
                DateTime dataInicial = DateTime.Parse(tarefa[4]);
                string dataFinal = tarefa[5];
                bool status = bool.Parse(tarefa[6]);
                afazeres.Add(new ToDo(id, descricao, categoria, responsavel, dataInicial, dataFinal, status));
            } while (!sr.EndOfStream);
            sr.Close();
        }
        else
        {
            Console.WriteLine("Arquivo sendo criado...");
        }
        Thread.Sleep(2000);
        return afazeres;
    }

    private static List<Person> CarregarResponsaveis(List<Person> responsaveis)
    {
        if (File.Exists("responsaveis.txt"))
        {
            StreamReader sr = new StreamReader("responsaveis.txt");

            do
            {
                string[] pessoa = sr.ReadLine().Split(";");
                string id = pessoa[0];
                string nome = pessoa[1];
                responsaveis.Add(new Person(id, nome));
            } while (!sr.EndOfStream);
            sr.Close();
        }
        else
        {
            Console.WriteLine("Arquivo sendo criado...");
        }
        Thread.Sleep(2000);
        return responsaveis;
    }

    private static List<Category> CarregarCategorias(List<Category> categorias)
    {
        if (File.Exists("categorias.txt"))
        {
            StreamReader sr = new StreamReader("categorias.txt");

            do
            {
                string nome = sr.ReadLine();
                categorias.Add(new Category(nome));
            } while (!sr.EndOfStream);
            sr.Close();
        }
        else
        {
            Console.WriteLine("Arquivo sendo criado...");
        }
        Thread.Sleep(2000);
        return categorias;
    }
}