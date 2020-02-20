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
            
            //TODO - validações

            string _cep = cep.Text.Trim();

            if (IsValidCep(_cep))
            {
                try
                {
                    Endereco end = ViaCep.BuscarEndereco(_cep);

                    if (end != null)
                    {
                        resultado.Text = string.Format("Endereço : {0}, {1}, {2}, {3} CEP: {4}",
                        end.UF, end.Localidade, end.Logradouro, end.Bairro, end.Cep);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O cep informado não foi encontrado! CEP: " + _cep,"OK");
                    }
                    
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                    
                }
                

            }


           
        }


        private bool IsValidCep(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "Cep inválido, deve conter 8 caracteres", "OK");

                valido = false;
            }

            int novoCep = 0;
            if (!int.TryParse(cep, out novoCep))
            {
                DisplayAlert("ERRO", "Cep inválido, Deve ser digitado somente Números!", "OK");

                valido = false;
            }

            return valido;
        }
    }
}
