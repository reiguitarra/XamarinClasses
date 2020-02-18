using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using AppCep.Servicos.Modulos;
using Newtonsoft.Json;

namespace AppCep.Servicos
{
    public class ViaCep
    {

        private static string EnderecoUrl = "https://viacep.com.br/ws/{0}/json/";


        public static Endereco BuscarEndereco (string cep)
        {

            string novoEndereco = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();

            string conteudo = wc.DownloadString(novoEndereco);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(conteudo);

            return end;

        }

    }
}
