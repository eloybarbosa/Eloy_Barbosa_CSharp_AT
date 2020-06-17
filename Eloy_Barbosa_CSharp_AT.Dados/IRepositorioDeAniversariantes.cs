using Eloy_Barbosa_CSharp_AT.Dominio;
using System;
using System.Collections.Generic;

namespace Eloy_Barbosa_CSharp_AT.Dados
{
    public interface IRepositorioDeAniversariantes
    {
        IEnumerable<Aniversariante> BuscarTodosOsAniversariantes();
        IEnumerable<Aniversariante> BuscarTodosOsAniversariantes(DateTime dataNascimento);
        IEnumerable<Aniversariante> BuscarTodosOsAniversariantes(string nome);
        void CadastrarAniversariante(Aniversariante aniversariante);
        void Excluir(string nome);
        void RecriarArquivo(List<Aniversariante> aniversariantes);
    }
}