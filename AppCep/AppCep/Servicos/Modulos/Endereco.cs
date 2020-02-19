﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AppCep.Servicos.Modulos
{
    public class Endereco
    {

        public string Cep { get; set; }
        public string Logradouro { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Localidade { get; set; }
        public string UF { get; set; }
        public string Unidade { get; set; }
        public string IBGE { get; set; }
        public string Gia { get; set; }

        public Endereco()
        {

        }

        public Endereco(string cep, string logradouro, string complemento, string bairro, string localidade, string uF, string unidade, string iBGE, string gia)
        {
            Cep = cep;
            Logradouro = logradouro;
            Complemento = complemento;
            Bairro = bairro;
            Localidade = localidade;
            UF = uF;
            Unidade = unidade;
            IBGE = iBGE;
            Gia = gia;
        }



        
    }
}
