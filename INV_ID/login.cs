using MetroFramework.Forms;
using CryptSharp;
using System;
using System.Drawing;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace INV_ID
{
    public partial class login : MetroForm
    {
        public static string modemID = "";

        data_layer data_layer = new data_layer();

        public login()
        {
            InitializeComponent();
        }

        public async Task Foo()
        {
            //faz um delay para ler mensage de sucesso
            await Task.Delay(500);
            this.Hide();
            menu f_menu = new menu();
            //abre o dashboard app principal
            f_menu.ShowDialog();
            this.Close();
        }

        private void login_Load(object sender, EventArgs e)
        {
            //esconde a password com chars
            i_pass.PasswordChar = '*';
        }

        private void btn_log_Click(object sender, EventArgs e)
        {
            //tratamento dos inputs antes de validar loggin
            l_erro.Visible = false;
            //guarda nas vars os inputs
            string[] dados_acc;
            string user = i_user.Text;
            string pass = i_pass.Text;

            modemID = i_modem.Text.Replace(" ", "").Replace(":", "").Replace("-", "");
            //regex para mac adress
            Regex r = new Regex("^[a-fA-F0-9]{12}$");
            
            //check se os campos estão vazios
            if (!String.IsNullOrEmpty(user)&& !String.IsNullOrEmpty(pass) && !String.IsNullOrEmpty(modemID))
            {
                //se for um max adress faz umg et dos ultimos 6 chars para fazer o "name do modem"
                if (r.IsMatch(modemID))
                { modemID = "FX7400"+ modemID.Substring(modemID.Length - 6);}

                //envia o username para saber retornar os dados encriptados da conta se existir em array
                dados_acc = data_layer.get_acc_data(user);
                if (dados_acc[2] == "Existe")
                {//se existir verifica se a pass inserida o hash é igual ah encriptada
                    if (Crypter.CheckPassword(pass, dados_acc[1]))
                    {
                        //mostra mensagem de sucesso se password for certa
                        l_erro.Visible = true;
                        l_erro.Text = "Login com sucesso";
                        l_erro.ForeColor = Color.Green;
                        
                        //chama função para abrir dashboard
                        Foo();

                    }
                    else
                    {
                        //se nao existir apresentar erro
                        l_erro.Visible = true;
                        l_erro.Text = "ERRO: user/password errada";

                    }
                }
                else
                {
                    //apresenta erro diferente ex sql connection....
                    l_erro.Visible = true;
                    l_erro.Text = "ERRO: Conta " + dados_acc[2];

                }
            }
            else
            {
                //apresenta erro diferente ex sql connection....
                l_erro.Visible = true;
                l_erro.Text = "Obrigatório preencher todos os campos!";

            }

        }
        
    }
}
