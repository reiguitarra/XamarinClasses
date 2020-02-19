using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using AppCep.Servicos;
using AppCep.Servicos.Modulos;

namespace AppCep
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();



            btn.Clicked += BuscarCep;
        }

        private void BuscarCep(object sender, EventArgs args)
        {
            //TODO - Lógica do Programa.
            //TODO - validações

            string _cep = cep.Text.Trim();
            Endereco end = ViaCep.BuscarEndereco(_cep);

            resultado.Text = string.Format("Endereço : {0}, {1}, {2}, {3} CEP: {4}", 
                end.UF,end.Localidade, end.Logradouro, end.Bairro,end.Cep);
        }
    }
}
