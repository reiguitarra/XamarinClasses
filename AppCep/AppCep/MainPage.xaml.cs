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
            try
            {
                string _cep = cep.Text.Trim();



                if (IsValidCep(_cep))
                {
                    try
                    {
                        Endereco end = ViaCep.BuscarEndereco(_cep);

                        if (end != null)
                        {
                            cep.Text = end.Cep;
                            Endereco ende = new Endereco(end.Cep,end.Logradouro, end.Complemento, end.Bairro, end.Localidade, end.UF, end.Unidade, end.IBGE, end.Gia);
                            resultado.Text = ende.ToString();
                        }
                        else
                        {
                            DisplayAlert("ERRO", "O cep informado não foi encontrado! CEP: " + _cep, "OK");
                            cep.Text = null;
                            
                        }

                    }
                    catch (Exception e)
                    {
                        DisplayAlert("ERRO CRÍTICO","O CEP deve ser informado para efetuar a Busca! "+ e.Message, "OK");
                        

                    }


                }
                else
                {
                    cep.Text = "";
                }

            }catch(Exception e)
            {
                DisplayAlert("ERRO", "O CEP deve ser informado para efetuar a busca! "+ e.Message, "OK");
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
