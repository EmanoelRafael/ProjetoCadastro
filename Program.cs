using System;
using System.Collections.Generic;
using ProjetoCadastro.Classes;
//using ProjetoCadastro.Enum;

namespace ProjetoCadastro
{
    class Program
    {
        static SRepositorio series = new SRepositorio();
        static FRepositorio filmes = new FRepositorio();

        static void Main(string[] args)
        {
            //SRepositorio Series = new SRepositorio();
            //FRepositorio filmes = new FRepositorio();
            
            List<string> operacoesValidas = new List<string>();
            operacoesValidas.Add("1");
            operacoesValidas.Add("2");
            operacoesValidas.Add("3");
            operacoesValidas.Add("4");
            operacoesValidas.Add("5");
            operacoesValidas.Add("6");
            operacoesValidas.Add("7");
            operacoesValidas.Add("8");
            operacoesValidas.Add("X");

            Console.WriteLine("Bem vindo(a) ao sistema de Cadastro de Filmes e Séries");
            string operacao = obtemOperacao(operacoesValidas);
            
            while (!String.Equals(operacao.ToUpper(),"X"))
            {

                switch (operacao)
                {
                    case "1":
                        insereFilme(true, 0);
                        break;
                    case "2":
                        insereSerie(true, 0);
                        break;
                    case "3":
                        excluirFilme();
                        break;
                    case "4":
                        excluirSerie();
                        break;
                    case "5":
                        alterarFilme();
                        break;
                    case "6":
                        alterarSerie();
                        break;
                    case "7":
                        listarFilmes();
                        break;
                    case "8":
                        listarSeries();
                        break;    
                    default:
                        break;
                }

                 operacao = obtemOperacao(operacoesValidas);
            }
        }

        private static string obtemOperacao(List<string> operacoesValidas)
        {
            Console.WriteLine();
            Console.WriteLine("Digite a operação desejada:");
            Console.WriteLine("1 - Inserir filme.");
            Console.WriteLine("2 - Inserir serie.");
            Console.WriteLine("3 - Excluir filme.");
            Console.WriteLine("4 - Excluir serie.");
            Console.WriteLine("5 - Alterar filme.");
            Console.WriteLine("6 - Alterar serie.");
            Console.WriteLine("7 - listar filmes.");
            Console.WriteLine("8 - listar series.");
            Console.WriteLine("X - sair.");
            string operacao = Console.ReadLine().ToUpper();
            //List<string> operacoesValidas = new List<string>;

            //while (!String.Equals(operacao,"1")&&!String.Equals(operacao,"2")&&!String.Equals(operacao,"3")&&!String.Equals(operacao,"4")&&!String.Equals(operacao.ToUpper(),"X"))
            while (!operacoesValidas.Contains(operacao))
            {
                Console.WriteLine();
                Console.WriteLine("OPERAÇÃO INVÁLIDA.");
                Console.WriteLine("Digite novamente:");
                Console.WriteLine("1 - Inserir filme.");
                Console.WriteLine("2 - Inserir serie.");
                Console.WriteLine("3 - Excluir filme.");
                Console.WriteLine("4 - Excluir serie.");
                Console.WriteLine("5 - Alterar filme.");
                Console.WriteLine("6 - Alterar serie.");
                Console.WriteLine("7 - listar filmes.");
                Console.WriteLine("8 - listar series.");
                Console.WriteLine("X - sair.");
                operacao = Console.ReadLine().ToUpper();
            }
                 
            return operacao;
        }

        private static void insereFilme(bool funcionalidade, int id)
        {
            string nome;
            int duracao = 0;
            int ano = 0;
            int genero = 0;
            string descricao;
            bool verificadorA, verificadorB = false;

            Console.WriteLine("Digite os dados do filme à ser inserido:");

            Console.WriteLine("Nome:");
            nome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Gênero:");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }
            Console.WriteLine();
            Console.WriteLine("Digite o valor correspondente ao gênero do filme:");
            verificadorA = Int32.TryParse(Console.ReadLine(),out genero);
            if(verificadorA)
            {
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    if(i==genero)verificadorB=true;
                }
            }
            while (!(verificadorA&&verificadorB))
            {
                Console.WriteLine("Dado inválido, digite novamente:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out genero);
                if(verificadorA)
                {
                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        if(i==genero)verificadorB=true;
                    }
                }
            }

            Console.WriteLine("Ano de lançamento:");
            verificadorA = Int32.TryParse(Console.ReadLine(),out ano);
            while (!verificadorA)
            {
                Console.WriteLine("Dado inválido, digite novamente:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out ano);
            }

            Console.WriteLine("Duração em minutos:");
            verificadorA = Int32.TryParse(Console.ReadLine(),out duracao);
            while (!verificadorA)
            {
                Console.WriteLine("Dado inválido, digite novamente:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out duracao);
            }

            Console.WriteLine("Descrição:");
            descricao = Console.ReadLine();

            Filme filme = new Filme(filmes.Proximoid(),nome,(Genero) genero, ano, descricao, duracao);
            if(funcionalidade)
            {
                filmes.Inserir(filme);
            }else
            {
                filmes.Alterar(id, filme);
            }
        }

        private static void excluirFilme()
        {
            int id;
            bool verificadorA, verificadorB = false;
            
            if(filmes.Proximoid()>0)
            {
                Console.WriteLine("Digite o ID do filme à ser excluido:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out id);
                if(verificadorA)
                {
                    if(id>=0&&id<filmes.Proximoid())
                    {
                        verificadorB = true;
                    }
                }
                while (!(verificadorA&&verificadorB))
                {
                    Console.WriteLine("Digite um ID válido:");
                    verificadorA = Int32.TryParse(Console.ReadLine(),out id);
                    if(verificadorA)
                    {
                        if(id>=0 && id<filmes.Proximoid())
                        {
                            verificadorB = true;
                        }
                    }
                }
                filmes.Excluir(id);
            }
        }

        private static void alterarFilme()
        {
            int id;
            bool verificadorA, verificadorB = false;
            
            if(filmes.Proximoid()>0)
            {
                Console.WriteLine("Digite o ID do filme à ser alterado:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out id);
                if(verificadorA)
                {
                    if(id>=0&&id<filmes.Proximoid())
                    {
                        verificadorB = true;
                    }
                }
                while (!(verificadorA&&verificadorB))
                {
                    Console.WriteLine("Digite um ID válido:");
                    verificadorA = Int32.TryParse(Console.ReadLine(),out id);
                    if(verificadorA)
                    {
                        if(id>=0 && id<filmes.Proximoid())
                        {
                            verificadorB = true;
                        }
                    }
                }
                Console.WriteLine($"O filme à ser alterado é: {filmes.retornarPorId(id)}");
                insereFilme(false, id);
            }
        }

        private static void listarFilmes()
        {
            int i=0;
            foreach (Filme c in filmes.Lista())
            {
                Console.WriteLine($"Id: {i}");
                Console.WriteLine(c);

                i++;
            }
        }

        //Series

        private static void insereSerie(bool funcionalidade, int id)
        {
            string nome;
            int temporadas = 0;
            int ano = 0;
            int genero = 0;
            string descricao;
            bool verificadorA, verificadorB = false;

            Console.WriteLine("Digite os dados da série à ser inserida:");

            Console.WriteLine("Nome:");
            nome = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Gênero:");
            foreach (int i in Enum.GetValues(typeof(Genero)))
            {
                Console.WriteLine($"{i} - {Enum.GetName(typeof(Genero),i)}");
            }
            Console.WriteLine();
            Console.WriteLine("Digite o valor correspondente ao gênero da série:");
            verificadorA = Int32.TryParse(Console.ReadLine(),out genero);
            if(verificadorA)
            {
                foreach (int i in Enum.GetValues(typeof(Genero)))
                {
                    if(i==genero)verificadorB=true;
                }
            }
            while (!(verificadorA&&verificadorB))
            {
                Console.WriteLine("Dado inválido, digite novamente:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out genero);
                if(verificadorA)
                {
                    foreach (int i in Enum.GetValues(typeof(Genero)))
                    {
                        if(i==genero)verificadorB=true;
                    }
                }
            }

            Console.WriteLine("Ano de lançamento:");
            verificadorA = Int32.TryParse(Console.ReadLine(),out ano);
            while (!verificadorA)
            {
                Console.WriteLine("Dado inválido, digite novamente:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out ano);
            }

            Console.WriteLine("Numero de temporadas:");
            verificadorA = Int32.TryParse(Console.ReadLine(),out temporadas);
            while (!verificadorA)
            {
                Console.WriteLine("Dado inválido, digite novamente:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out temporadas);
            }

            Console.WriteLine("Descrição:");
            descricao = Console.ReadLine();

            Serie serie = new Serie(series.Proximoid(),nome,(Genero) genero, ano, descricao, temporadas);
            if(funcionalidade)
            {
                series.Inserir(serie);
            }else
            {
                series.Alterar(id, serie);
            }
        }

        private static void excluirSerie()
        {
            int id;
            bool verificadorA, verificadorB = false;
            
            if(series.Proximoid()>0)
            {
                Console.WriteLine("Digite o ID da série à ser excluida:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out id);
                if(verificadorA)
                {
                    if(id>=0&&id<series.Proximoid())
                    {
                        verificadorB = true;
                    }
                }
                while (!(verificadorA&&verificadorB))
                {
                    Console.WriteLine("Digite um ID válido:");
                    verificadorA = Int32.TryParse(Console.ReadLine(),out id);
                    if(verificadorA)
                    {
                        if(id>=0 && id<series.Proximoid())
                        {
                            verificadorB = true;
                        }
                    }
                }
                series.Excluir(id);
            }
        }

        private static void alterarSerie()
        {
            int id;
            bool verificadorA, verificadorB = false;
            
            if(series.Proximoid()>0)
            {
                Console.WriteLine("Digite o ID da série à ser alterada:");
                verificadorA = Int32.TryParse(Console.ReadLine(),out id);
                if(verificadorA)
                {
                    if(id>=0&&id<series.Proximoid())
                    {
                        verificadorB = true;
                    }
                }
                while (!(verificadorA&&verificadorB))
                {
                    Console.WriteLine("Digite um ID válido:");
                    verificadorA = Int32.TryParse(Console.ReadLine(),out id);
                    if(verificadorA)
                    {
                        if(id>=0 && id<series.Proximoid())
                        {
                            verificadorB = true;
                        }
                    }
                }
                Console.WriteLine($"A série à ser alterada é: {series.retornarPorId(id)}");
                insereSerie(false, id);
            }
        }

        private static void listarSeries()
        {
            int i = 0;
            foreach (Serie c in series.Lista())
            {
                Console.WriteLine($"Id: {i}");
                Console.WriteLine(c);

                i++;
            }
        }

    }

}
