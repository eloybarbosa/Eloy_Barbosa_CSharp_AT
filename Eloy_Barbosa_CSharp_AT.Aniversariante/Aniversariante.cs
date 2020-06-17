﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Eloy_Barbosa_CSharp_AT.Dominio
{
    public class Aniversariante
    {

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }

        public Aniversariante()
        {
            DataCadastro = DateTime.Now;
        }

        public Aniversariante(string nome, string sobrenome, DateTime dataNascimento)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }
        public Aniversariante(string nome, string sobrenome, DateTime dataNascimento, DateTime dataCadastro)
        {
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
            DataCadastro = dataCadastro;

        }
    }


}
