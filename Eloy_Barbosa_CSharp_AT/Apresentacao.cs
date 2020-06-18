using Eloy_Barbosa_CSharp_AT.Dominio;
using System;
using System.Linq;
using Eloy_Barbosa_CSharp_AT.Dados;

namespace Eloy_Barbosa_CSharp_AT
{
    public class Apresentacao
    {
        public static IRepositorioDeAniversariantes RepositorioDeAniversariantes = new RepositorioDeAniversariantes();
        public static void Cabecalho()
        {
            EscreverNaTela("---------------------- Instituto Infnet ----------------------");
            EscreverNaTela("");
            EscreverNaTela("Fundamentos de Desenvolvimento com C#");
            EscreverNaTela("Assessment");
            EscreverNaTela("Aluno: Eloy Barbosa");
            EscreverNaTela("Professor: Vitor Fitzner");
            EscreverNaTela("");
        }
        private static void EscreverNaTela(string texto)
        {
            Console.WriteLine(texto);
        }
        public static void MenuPrincipal()
        {
            EscreverNaTela("------------------- Gerenciar Aniversários -------------------");
            EscreverNaTela("");
            EscreverNaTela("Menu Principal");
            EscreverNaTela("");
            EscreverNaTela("1 - Aniversariantes Cadastrados");
            EscreverNaTela("2 - Cadastrar Aniversariante");
            EscreverNaTela("3 - Pesquisar por Nome");
            EscreverNaTela("4 - Pesquisar por Data de Nascimento");
            EscreverNaTela("5 - Deletar Aniversariante");
            EscreverNaTela("6 - Editar Aniversariante");
            EscreverNaTela("7 - Sair");
            EscreverNaTela("");

            EscreverNaTela("Informe a opção desejada:");
            char operacao = Console.ReadLine().ToCharArray()[0];

            switch (operacao)
            {
                case '1':
                    EscreverNaTela("");
                    EscreverNaTela("Aniversariantes Cadastrados");
                    EscreverNaTela("");
                    ConsultarAniversariante(); break;

                case '2':
                    EscreverNaTela("");
                    EscreverNaTela("Cadastrar Aniversariantes");
                    EscreverNaTela("");
                    CadastrarAniversariante(); break;
                case '3':
                    EscreverNaTela("");
                    EscreverNaTela("Pesquisar por Nome");
                    EscreverNaTela("");
                    ConsultarPeloNome(); break;
                case '4':
                    EscreverNaTela("");
                    EscreverNaTela("Pesquisar por data de Nascimento");
                    EscreverNaTela("");
                    ConsultarPelaData(); break;
                case '5':
                    EscreverNaTela("");
                    EscreverNaTela("Deletar Aniversariante");
                    EscreverNaTela("");
                    ExcluirAniversariante(); break;
                case '6':
                    EscreverNaTela("");
                    EscreverNaTela("Editar Aniversariante");
                    EscreverNaTela("");
                    EditarAniversariante();break;
                case '7':
                    EscreverNaTela("");
                    EscreverNaTela("Até a Próxima!!!"); break;
                default:
                    EscreverNaTela("");
                    EscreverNaTela("Opção Inválida,tente novamente!");
                    EscreverNaTela(" ");
                    MenuPrincipal(); break;
            }
        }
        public static void CadastrarAniversariante()
        {
            Console.Clear();
            Cabecalho();

            EscreverNaTela("Cadastrando Aniversariante");
            EscreverNaTela("");
            EscreverNaTela("Digite o Nome:");
            string nome = Console.ReadLine();
            EscreverNaTela("Digite o Sobrenome:");
            string sobrenome = Console.ReadLine();
            EscreverNaTela("Digite a data do aniverário (DD/MM/YYYY)");
            DateTime dataNascimento = DateTime.Parse(Console.ReadLine());

            Aniversariante aniversariante = new Aniversariante();
            aniversariante.Nome = nome;
            aniversariante.Sobrenome = sobrenome;
            aniversariante.DataNascimento = dataNascimento;
            aniversariante.DataCadastro = DateTime.Now;

            RepositorioDeAniversariantes.CadastrarAniversariante(aniversariante);
            ContinuarCadastro();
        }
        public static void ContinuarCadastro()
        {
            EscreverNaTela("");
            EscreverNaTela("Deseja cadastrar outro aniversariante?");
            EscreverNaTela("1 - Sim");
            EscreverNaTela("2 - Não");
            string Escolha = Console.ReadLine();

            if (Escolha == "1")
            {

                CadastrarAniversariante();
            }
            else if (Escolha == "2")
            {
                Console.Clear();
                Cabecalho();
                MenuPrincipal();

            }
            else
            {
                EscreverNaTela("Opção Inválida");
            }
        }

        public static void ConsultarAniversariante()
        {
            foreach (var aniversariante in RepositorioDeAniversariantes.BuscarTodosOsAniversariantes())
            {

                EscreverNaTela($"{aniversariante.Nome} {aniversariante.Sobrenome}");
                EscreverNaTela($"Idade: {(DateTime.Now - aniversariante.DataNascimento).Days / 30 / 12 - 1}");
                EscreverNaTela($"Data de Nascimento: {aniversariante.DataNascimento:dd/MM/yyyy}");
                EscreverNaTela($"Data de Cadastro: {aniversariante.DataCadastro:dd/MM/yyyy}");

                int dia = aniversariante.DataNascimento.Day;
                int mes = aniversariante.DataNascimento.Month;
                if (DateTime.Today.Month < aniversariante.DataNascimento.Month)
                {
                    DateTime proximoNiver = new DateTime(DateTime.Today.Year, mes, dia);

                    double resultado = proximoNiver.Subtract(DateTime.Today).TotalDays;

                    EscreverNaTela($"Seu proximo aniversário é em {resultado} dias");
                    EscreverNaTela("");
                }
                else
                {
                    DateTime proximoNiver = new DateTime(DateTime.Today.Year + 1, mes, dia);

                    double resultado = proximoNiver.Subtract(DateTime.Today).TotalDays;

                    EscreverNaTela($"Seu proximo aniversário é em {resultado} dias");
                    EscreverNaTela("");
                }
            }

            EscreverNaTela("");
            EscreverNaTela("Pressione Qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Cabecalho();
            MenuPrincipal();
        }

        public static void ConsultarPeloNome()
        {
            EscreverNaTela("Entre com o nome que deseja buscar:");
            string nome = Console.ReadLine();


            var aniversariantesEncontrados = RepositorioDeAniversariantes.BuscarTodosOsAniversariantes(nome);

            int qtdaniversariantesEncontrados = aniversariantesEncontrados.Count();

            if (qtdaniversariantesEncontrados > 0)
            {
                foreach (var aniversariante in aniversariantesEncontrados)
                {
                    EscreverNaTela($"{aniversariante.Nome} {aniversariante.Sobrenome}");
                    EscreverNaTela($"Idade: {(DateTime.Now - aniversariante.DataNascimento).Days / 30 / 12 - 1}");
                    EscreverNaTela($"Data de Nascimento: {aniversariante.DataNascimento:dd/MM/yyyy}");
                    EscreverNaTela($"Data de Cadastro: {aniversariante.DataCadastro:dd/MM/yyyy}");
                }
            }
            else
            {
                EscreverNaTela("Nenhum aniversariante encontrado com esse nome!!!");
            }


            EscreverNaTela("");
            EscreverNaTela("Pressione Qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Cabecalho();
            MenuPrincipal();
        }

        public static void EditarAniversariante()
        {
            EscreverNaTela("Entre com o nome do aniversariante que deseja editar:");
            EscreverNaTela("");
            string nome = Console.ReadLine();

            var aniversariantesEncontrados = RepositorioDeAniversariantes.BuscarTodosOsAniversariantes(nome);

            int qtdaniversariantesEncontrados = aniversariantesEncontrados.Count();

            if (qtdaniversariantesEncontrados > 0)
            {
                EscreverNaTela("Pessoas Encontradas:");
                EscreverNaTela("");
                foreach (var aniversariante in aniversariantesEncontrados)
                {
                    EscreverNaTela($"{aniversariante.Nome} {aniversariante.Sobrenome}");
                    EscreverNaTela($"Idade: {(DateTime.Now - aniversariante.DataNascimento).Days / 30 / 12 - 1}");
                    EscreverNaTela($"Data de Nascimento: {aniversariante.DataNascimento:dd/MM/yyyy}");
                    EscreverNaTela($"Data de Cadastro: {aniversariante.DataCadastro:dd/MM/yyyy}");
                    EscreverNaTela("");
                }
            }
            else
            {
                EscreverNaTela("Nenhum aniversariante encontrado com esse nome!!!");
                EscreverNaTela("");
                EditarAniversariante();
            }

            EscreverNaTela("Caso queira prosseguir digite novamente o SOBRENOME do aniversariante que deseja Editar!");
            string escolha2 = Console.ReadLine();

            foreach (var aniversariante in aniversariantesEncontrados)
            {
                if (aniversariante.Sobrenome == escolha2)
                {
                    RepositorioDeAniversariantes.Excluir(aniversariante.Nome);

                }
                else
                {
                    EscreverNaTela("Nenhum aniversariante encontrado com esse SOBRENOME!!!");
                    EscreverNaTela("");
                    EditarAniversariante();
                }
            }           
                            
            EscreverNaTela("Editando Aniversariante");
            EscreverNaTela("");
            EscreverNaTela("Digite o Nome:");
            string newNome = Console.ReadLine();
            EscreverNaTela("Digite o Sobrenome:");
            string newSobrenome = Console.ReadLine();
            EscreverNaTela("Digite a data do aniverário (DD/MM/YYYY)");
            DateTime newDataNascimento = DateTime.Parse(Console.ReadLine());

            Aniversariante aniversariante1 = new Aniversariante();
            aniversariante1.Nome = newNome;
            aniversariante1.Sobrenome = newSobrenome;
            aniversariante1.DataNascimento = newDataNascimento;
            aniversariante1.DataCadastro = DateTime.Now;

            RepositorioDeAniversariantes.CadastrarAniversariante(aniversariante1);
            EscreverNaTela("");
            EscreverNaTela("Pressione Qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Cabecalho();
            MenuPrincipal();

        }

        public static void ConsultarPelaData()
        {
            EscreverNaTela("Entre com a data que deseja buscar:");
            DateTime data = DateTime.Parse(Console.ReadLine());


            var aniversariantesEncontrados = RepositorioDeAniversariantes.BuscarTodosOsAniversariantes(data);

            int qtdaniversariantesEncontrados = aniversariantesEncontrados.Count();

            if (qtdaniversariantesEncontrados > 0)
            {

                foreach (var aniversariante in aniversariantesEncontrados)
                {
                    EscreverNaTela($"{aniversariante.Nome} {aniversariante.Sobrenome}");
                    EscreverNaTela($"Idade: {(DateTime.Now - aniversariante.DataNascimento).Days / 30 / 12 - 1}");
                    EscreverNaTela($"Data de Nascimento: {aniversariante.DataNascimento:dd/MM/yyyy}");
                    EscreverNaTela($"Data de Cadastro: {aniversariante.DataCadastro:dd/MM/yyyy}");
                }

            }
            else
            {
                EscreverNaTela("Nenhum aniversariante encontrado para esta data!!!");
            }

            EscreverNaTela("");
            EscreverNaTela("Pressione Qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Cabecalho();
            MenuPrincipal();
        }

        public static void AniversariantesDoDia()
        {
            EscreverNaTela("------------------- Aniversariantes do dia -------------------");

            foreach (var aniversariante in RepositorioDeAniversariantes.BuscarTodosOsAniversariantes())
            {
                if (DateTime.Now.Month == aniversariante.DataNascimento.Month && DateTime.Now.Day == aniversariante.DataNascimento.Day)
                {
                    EscreverNaTela($"{aniversariante.Nome} {aniversariante.Sobrenome}");
                    EscreverNaTela($"Idade: {(DateTime.Now - aniversariante.DataNascimento).Days / 30 / 12 - 1}");
                    EscreverNaTela($"Data de Nascimento: {aniversariante.DataNascimento:dd/MM/yyyy}");
                    EscreverNaTela($"Data de Cadastro: {aniversariante.DataCadastro:dd/MM/yyyy}");
                }
                else
                {
                    EscreverNaTela("");
                }

            }

            EscreverNaTela("");

        }

        public static void ExcluirAniversariante()
        {
            EscreverNaTela("Entre com o nome do aniversariante que deseja excluir:");
            EscreverNaTela("");
            string nome = Console.ReadLine();

            var aniversariantesEncontrados = RepositorioDeAniversariantes.BuscarTodosOsAniversariantes(nome);

            int qtdaniversariantesEncontrados = aniversariantesEncontrados.Count();

            if (qtdaniversariantesEncontrados > 0)
            {
                EscreverNaTela("Pessoas Encontradas:");
                EscreverNaTela("");
                foreach (var aniversariante in aniversariantesEncontrados) 
                {
                    EscreverNaTela($"{aniversariante.Nome} {aniversariante.Sobrenome}");
                    EscreverNaTela($"Idade: {(DateTime.Now - aniversariante.DataNascimento).Days / 30 / 12 - 1}");
                    EscreverNaTela($"Data de Nascimento: {aniversariante.DataNascimento:dd/MM/yyyy}");
                    EscreverNaTela($"Data de Cadastro: {aniversariante.DataCadastro:dd/MM/yyyy}");
                    EscreverNaTela("");
                }
            }
            else
            {
                EscreverNaTela("Nenhum aniversariante encontrado com esse nome!!!");
                EscreverNaTela("");
                ExcluirAniversariante();
            }

            EscreverNaTela("Caso queira prosseguir digite novamente o SOBRENOME do aniversariante que deseja excluir!");
            string sobrenome2 = Console.ReadLine();

            foreach(var aniversariante in aniversariantesEncontrados)
            {
                if(aniversariante.Sobrenome == sobrenome2)
                {
                    RepositorioDeAniversariantes.Excluir(aniversariante.Nome);
                }
            }

            EscreverNaTela("");
            EscreverNaTela("Pressione Qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
            Cabecalho();
            MenuPrincipal();

        }

    }
}
