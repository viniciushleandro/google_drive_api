using Google.Apis.Auth.OAuth2;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Integracao
{
    public partial class Configuracoes : Form
    {
        public Configuracoes()
        {
            InitializeComponent();
        }

        private void btnCriarPasta_Click(object sender, EventArgs e)
        {
            System.Threading.Tasks.Task<string> idPasta;
            string nomePasta = Interaction.InputBox("Informe o nome da pasta a ser criada. Se vazio, nome padrão: Arquivos.", "Criar Pasta");
            if (nomePasta == "")
            {
                idPasta = GoogleDrive.CreateFolder("Arquivos");
            }
            else
            {
                idPasta = GoogleDrive.CreateFolder(nomePasta);
            }
            txtIdPasta.Text = idPasta.Result;
        }

        private async void btnAutorizarApi_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(dlg.FileName))
                {
                    UserCredential credenciais = await GoogleDrive.Autenticar(dlg.FileName);
                    if (credenciais != null)
                    {
                        txtAccessToken.Text = credenciais.Token.AccessToken;
                        txtRefreshToken.Text = credenciais.Token.RefreshToken;
                    }
                    string json = File.ReadAllText(dlg.FileName);
                    Newtonsoft.Json.Linq.JObject jsonObject = Newtonsoft.Json.Linq.JObject.Parse(json);
                    Newtonsoft.Json.Linq.JObject installedObject = (Newtonsoft.Json.Linq.JObject)jsonObject["installed"];

                    string clientId = installedObject["client_id"].ToString();
                    string clientSecret = installedObject["client_secret"].ToString();

                    txtClienteId.Text = clientId;
                    txtChaveSecreta.Text = clientSecret;

                    MessageBox.Show("Acesso autorizado!");
                }
                else
                {
                    MessageBox.Show("Não foi possível realizar a autorização da API.");
                }
            }
        }

        private void AtualizarPropriedades()
        {
            GoogleDrive.ClienteId = txtClienteId.Text;
            GoogleDrive.ChaveSecreta = txtChaveSecreta.Text;
            GoogleDrive.IdPasta = txtIdPasta.Text;
            GoogleDrive.Email = txtEmail.Text;
            GoogleDrive.AccessToken = txtAccessToken.Text;
            GoogleDrive.RefreshToken = txtRefreshToken.Text;
            GoogleDrive.NomeAplicativo = txtNomeAplicativo.Text;
        }

        private void btnAttDados_Click(object sender, EventArgs e)
        {
            AtualizarPropriedades();
        }

        private void btnEnviarArq_Click(object sender, EventArgs e)
        {
            GoogleDrive.UploadFile(txtCaminArq.Text, txtNomeArq.Text, GoogleDrive.eGoogleDriveMimeType.PDF, txtDescrArq.Text,GoogleDrive.eRetornoLink.LINK);
        }
    }
}
