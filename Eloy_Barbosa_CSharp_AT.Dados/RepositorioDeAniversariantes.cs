using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Eloy_Barbosa_CSharp_AT.Dominio;


namespace Eloy_Barbosa_CSharp_AT.Dados
{
    public class RepositorioDeAniversariantes : IRepositorioDeAniversariantes
    {
        private static string ObterNomeArquivo()
        {
            var pastaDesktop = Environment.SpecialFolder.Desktop;

            string localDaPastaDesktop = Environment.GetFolderPath(pastaDesktop);
            string nomeDoArquivo = @"\AniversariantesDB.txt";

            return localDaPastaDesktop + nomeDoArquivo;
        }
        public IEnumerable<Aniversariante> BuscarTodosOsAniversariantes()
        {
            string nomeDoArquivo = ObterNomeArquivo();

            FileStream arquivo;
            if (!File.Exists(nomeDoArquivo))
            {
                arquivo = File.Create(nomeDoArquivo);
                arquivo.Close();
            }

            string resultado = File.ReadAllText(nomeDoArquivo);

            //identificar cada aniversariante
            string[] aniversariantes = resultado.Split(';');

            List<Aniversariante> aniversariantesList = new List<Aniversariante>();

            for (int i = 0; i < aniversariantes.Length - 1; i++)
            {
                string[] dadosDoAniversariante = aniversariantes[i].Split(',');

                //identificar cada dado do aniversariante
                string nome = dadosDoAniversariante[0];
                string sobrenome = dadosDoAniversariante[1];
                DateTime dataNascimento = Convert.ToDateTime(dadosDoAniversariante[2]);
                DateTime dataCadastro = Convert.ToDateTime(dadosDoAniversariante[3]);

                Aniversariante aniversariante = new Aniversariante(nome, sobrenome, dataNascimento, dataCadastro);

                aniversariantesList.Add(aniversariante);
            }

            //retornar a lista
            return aniversariantesList;
        }
        public void CadastrarAniversariante(Aniversariante aniversariante)
        {
            string nomeDoArquivo = ObterNomeArquivo();

            string formato = $"{aniversariante.Nome},{aniversariante.Sobrenome},{aniversariante.DataNascimento.ToString()},{aniversariante.DataCadastro.ToString()};";

            File.AppendAllText(nomeDoArquivo, formato);
        }
        public IEnumerable<Aniversariante> BuscarTodosOsAniversariantes(string nome)
        {
            return from x in BuscarTodosOsAniversariantes()
                   where x.Nome.Contains(nome)
                   orderby x.Nome
                   select x;
        }
        public IEnumerable<Aniversariante> BuscarTodosOsAniversariantes(DateTime dataNascimento)
        {
            return from x in BuscarTodosOsAniversariantes()
                   where x.DataNascimento == dataNascimento
                   orderby x.Nome
                   select x;
        }
        public void Excluir(string nome)
        {
            var todosOsAniversariantes = BuscarTodosOsAniversariantes();
            List<Aniversariante> aniversariantesUpdate = new List<Aniversariante>();
            foreach(var aniversariante in todosOsAniversariantes)
            {
                if (nome != aniversariante.Nome)
                {
                    aniversariantesUpdate.Add(aniversariante);
                }
                else
                {
                }
            }
            RecriarArquivo(aniversariantesUpdate);
            
        }
        public void RecriarArquivo(List<Aniversariante> aniversariantesUpdate)
        {
            string nomeDoArquivo = ObterNomeArquivo();
            File.Delete(ObterNomeArquivo());
            FileStream arquivo;
            if (!File.Exists(nomeDoArquivo))
            {
                arquivo = File.Create(nomeDoArquivo);
                arquivo.Close();
            }
            foreach (var aniversariante in aniversariantesUpdate)
            {
                CadastrarAniversariante(aniversariante);
            }

        }

    }


}
