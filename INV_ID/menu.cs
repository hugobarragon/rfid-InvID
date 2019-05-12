using MetroFramework.Forms;
using System.Windows.Forms;
using System.Diagnostics;
using MetroFramework;
using RFID;
using System;

namespace INV_ID
{
    public partial class menu : MetroForm
    {
        static ListViewItem items;
        data_layer data_layer = new data_layer();
        RFIDReader reader = new RFIDReader();
        DateTime dateTime;

        static string current_id = "";
        int current_tab = 3;
        string[] dados_alug;
        string[] dados_inv;

        public menu()
        {
            InitializeComponent();
            metroTabControl1.SelectedIndexChanged += new EventHandler(Tabs_SelectedIndexChanged);
            //funções da anteda darfid.dll que devole quando a tag entra em alcance e quanoa  tag saie de alcance
            reader.OnTagEnter += reader_OnTagEnter; // Called when the library detects a tag has entered the antenna field
            reader.OnTagLeave += reader_OnTagLeave; // Called when the library detects a tag has left the antenna field
            //reader.OnTagRead += reader_OnTagRead; // Called when the library gets a message from the device with the tags it read

        }

        public void SetListview(string[] a)
        {
            //escreve na list view a tag que entrou em alcance e verifica se consegue aceder á
            //listview


            items = new ListViewItem(a);

            if (metroListView1.InvokeRequired)
                metroListView1.Invoke(new MethodInvoker(delegate
                {//se nao conseguir aceder faz um thread para aceder ah listview
                    metroListView1.Items.Insert(0, items);
                    //escreve na list view e a list view essta limitada a 100 tags para evitar overflow
                    if (metroListView1.Items.Count > 100) { 
                        metroListView1.Items.RemoveAt(metroListView1.Items.Count - 1);
                }

                }));
            else {
                metroListView1.Items.Insert(0, items);
                if (metroListView1.Items.Count > 100)
                {
                    //se conseguir aceder escreve na listview
                    metroListView1.Items.RemoveAt(metroListView1.Items.Count - 1);
                }
            }

        }

        public void Set_registar(string a)
        {
            //função para detectar se ferramenta é para devolver ou requisitar
            current_id = a;

            if (String.IsNullOrEmpty(input_requisitar_tag_id.Text) && current_id != "")
            {
                //escreve na input box tag id
                if (input_requisitar_tag_id.InvokeRequired)
                    input_requisitar_tag_id.Invoke(new MethodInvoker(delegate
                    {
                        input_requisitar_tag_id.Text = current_id;
                        current_id = "";
                    }));
                else
                {
                    input_requisitar_tag_id.Text = current_id;
                    current_id = "";
                }
                //-----------------

                if (l_erro_requisitar_1.InvokeRequired)
                    l_erro_requisitar_1.Invoke(new MethodInvoker(delegate
                    {
                        //verifica se ferramenta existe
                        l_erro_requisitar_1.Text = data_layer.check_db_exists_id(input_requisitar_tag_id.Text);

                        if (l_erro_requisitar_1.Text.Contains("Ainda não existe"))
                        {
                            //ferrametna nao existe apresenta erro
                            l_erro_requisitar_1.Visible = true;
                            current_id = "";

                        }
                        else if (l_erro_requisitar_1.Text.Contains("Ja existe"))
                        {
                            //verificar se é para devolver ou requistiar
                            dados_alug = data_layer.check_db_exists_aluger(input_requisitar_tag_id.Text);

                            if (dados_alug[5].Contains("Ja existe"))
                            {
                                //desbloqueia o devolver
                                devolver_groupBox.Visible = true;
                                devolver_aluno_nome.Text = dados_alug[6];
                                devolver_tag_nome.Text = dados_alug[7];

                            }
                            else if (dados_alug[5].Contains("Ainda não existe"))
                            {
                                //desbloquei o requistar pois ferrametna nao existe na tabela aluguer
                                dados_inv = data_layer.get_inv_data(input_requisitar_tag_id.Text);
                                req_tag_id.Text = dados_inv[0];
                                req_tag_name.Text = dados_inv[1];
                                req_tag_desc.Text = dados_inv[3];
                                requisitar_groupBox.Visible = true;

                            }
                            else
                            {//tratamento erros
                                l_erro_requisitar_1.Text = dados_alug[5];
                                l_erro_requisitar_1.Visible = true;
                            }
                            current_id = "";
                        }
                        else { l_erro_requisitar_1.Visible = true; }

                    }));
                else
                {//repetição ao que stá acima pois é a outra vercente da treath
                    l_erro_requisitar_1.Text = data_layer.check_db_exists_id(input_requisitar_tag_id.Text);

                    if (l_erro_requisitar_1.Text.Contains("Ainda não existe"))
                    {
                        l_erro_requisitar_1.Visible = true;
                        current_id = "";

                    }
                    else if (l_erro_requisitar_1.Text.Contains("Ja existe"))
                    {
                        //verificar se é para devolver
                        dados_alug = data_layer.check_db_exists_aluger(input_requisitar_tag_id.Text);

                        if (dados_alug[5].Contains("Ja existe"))
                        {
                            //abre o devolver
                            devolver_groupBox.Visible = true;
                            devolver_aluno_nome.Text = dados_alug[6];
                            devolver_tag_nome.Text = dados_alug[7];

                        }
                        else if (dados_alug[5].Contains("Ainda não existe"))
                        {
                            //deteta que nao existe alugado e permite alugar
                            dados_inv = data_layer.get_inv_data(input_requisitar_tag_id.Text);
                            req_tag_id.Text = dados_inv[0];
                            req_tag_name.Text = dados_inv[1];
                            req_tag_desc.Text = dados_inv[3];
                            requisitar_groupBox.Visible = true;

                        }
                        else
                        {
                            l_erro_requisitar_1.Text = dados_alug[5];
                            l_erro_requisitar_1.Visible = true;
                        }
                        current_id = "";
                    }
                    else { l_erro_requisitar_1.Visible = true; }
                }
            }
        }

        public void set_inserir_material(string a)
        {
            current_id = a;
            //funcao para inserir ferremant

            if (String.IsNullOrEmpty(try1.Text) && current_id != "")
            {
                //se compo tiver preenchido guarda a tag id numa var
                //verifica acesso com ou sem threath
                if (try1.InvokeRequired)
                    try1.Invoke(new MethodInvoker(delegate
                    {
                        try1.Text = current_id;
                        current_id = "";

                    }));
                else
                {
                    try1.Text = current_id;
                    current_id = "";
                }
            }

            if (String.IsNullOrEmpty(try2.Text) && current_id != "" && !String.IsNullOrEmpty(try1.Text))
            {//verifica se os 3 campos sao iguais
                if (try2.InvokeRequired)
                    try2.Invoke(new MethodInvoker(delegate
                    {
                        try2.Text = current_id;
                        current_id = "";

                    }));
                else
                {
                    try2.Text = current_id;
                    current_id = "";
                }
            }

            if (String.IsNullOrEmpty(try3.Text) && current_id != "" && !String.IsNullOrEmpty(try2.Text))
            {//verifica se os 3 campos sao iguais
                if (try3.InvokeRequired)
                    try3.Invoke(new MethodInvoker(delegate
                    {
                        try3.Text = current_id;
                        current_id = "";
                        //verifica se tag já existe no sistema pois nao pode existir tags iguais
                        if (try1.Text == try2.Text && try2.Text == try3.Text && data_layer.check_db_exists_id(try3.Text).Contains("Ainda não existe"))
                        {

                            insert_groupbox.Visible = true;
                            input_tag_id.Text = try3.Text;

                        }
                        else
                        {
                            //trataento erros
                            l_insert_erro.Visible = true;

                            if (try1.Text != try2.Text || try2.Text != try3.Text)
                            {
                                l_insert_erro.Text = "ERRO: TAGS DIFERENTES ";

                            }
                            else { l_insert_erro.Text = data_layer.check_db_exists_id(try3.Text); }

                        }


                    }));
                else
                {
                    try3.Text = current_id;
                    current_id = "";
                }
            }
        }

        private void Tabs_SelectedIndexChanged(object sender, EventArgs e)
        {
            //guarda a tab em que o user está
            current_tab = metroTabControl1.SelectedIndex;

        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Menu_Load(object sender, EventArgs e)
        {
            metroTabControl1.SelectedIndex = 3;
            metroComboBox1.Items.Insert(0, "Oficina");
            metroComboBox1.Items.Insert(1, "Laboratório");
            metroComboBox1.SelectedIndex = 0;
            //id do modem do kit
            Debug.Write("TESTE FINAL"+login.modemID);
            if (reader.Open(login.modemID, 5) == false)
            { // FX7400C717C3 "FX7400C717C3"
                // FX7400C2F712 avaria não lê tags seguidas delay de uns 30 min
                // Tries connecting 5 times, if it fails, we give error and terminate program
                MetroMessageBox.Show(this, "Não conectado\nFaça login outravez");
            }
            else
            {
                MetroMessageBox.Show(this, "Detetado");
            }

        }

        private void reader_OnTagEnter(object sender, OnTagStatusChangedEventHandlerArgs e)
        {
            dateTime = DateTime.Now;
            //tem um listener no leitor para quando detectar uma nova tag corre o programa
            string[] row = { e.Timestamp.ToString(), e.Tag.Size.ToString(), " tag entered ", "[" + e.Tag.ID.ToString() + "]", dateTime.ToString() };
            SetListview(row);

            if (current_tab == 2)
            {
                set_inserir_material("[" + e.Tag.ID + "]");

            }
            else if (current_tab == 0)
            {
                Set_registar("[" + e.Tag.ID + "]");
            }

        }

        private void reader_OnTagLeave(object sender, OnTagStatusChangedEventHandlerArgs e)
        {
            //corre sempre que detecta que uma tag saiu de alcance
            string[] row = { e.Timestamp.ToString(), e.Tag.Size.ToString(), " tag left ", "[" + e.Tag.ID + "]", dateTime.ToString() };
            SetListview(row);

        }

        //tag read le sempre que a tag esta em alcance ou seja se deiar a tag em cima da antena crsha por overflow
        //private void reader_OnTagRead(object sender, OnTagReadEventHandlerArgs e)
        //{
        //    dateTime = DateTime.Now;
        //    foreach (RFIDTag tag in e.Tags)
        //    {
        //        string[] row = { e.Timestamp.ToString(), tag.Size.ToString(), " tag read ", "[" + tag.ID + "]", dateTime.ToString() };
        //        SetListview(row);
        //    }
        //}

        private void add_inv_bd_btn_Click(object sender, EventArgs e)
        {
            l_insert_erro2.Visible = true;

            if (!String.IsNullOrEmpty(input_tag_id.Text) && !String.IsNullOrEmpty(input_nome_tag.Text) && !String.IsNullOrEmpty(input_desc_tag.Text))
            {
                //adicionar ferramenta nova se os campos tiverem preenhidos
                //vai ah base de dados ver se existe
                l_insert_erro2.Text = data_layer.check_db_exists_id(input_tag_id.Text);

                if (l_insert_erro2.Text.Contains("Ja existe"))
                {
                    l_insert_erro2.ForeColor = System.Drawing.Color.DarkRed;
                }

                else if (l_insert_erro2.Text.Contains("Ainda não existe"))
                {
                    //se não existir apresneta mensagem e inserer a tag na base de dados
                    l_insert_erro2.ForeColor = System.Drawing.Color.Green;
                    l_insert_erro2.Text = data_layer.insert_inventario(input_tag_id.Text, input_nome_tag.Text, metroComboBox1.SelectedItem.ToString(), input_desc_tag.Text, dateTime);
                }
                else
                {
                    //se existir vai a base de dados buscar o nome da tag que já está associada
                    l_insert_erro2.ForeColor = System.Drawing.Color.Green;
                    l_insert_erro2.Text = "Erro inesperado" + data_layer.check_db_exists_id(input_tag_id.Text);
                }

            }
            else
            {
                l_insert_erro2.ForeColor = System.Drawing.Color.DarkRed;
                l_insert_erro2.Text = "Tem de prencher todos os campos";
            }
        }

        private void clean_requisitar_Click(object sender, EventArgs e)
        {
            //limpa o formulário
            requisitar_devolver.Visible = true;
            input_requisitar_tag_id.Text = null;
            requisitar_groupBox.Visible = false;
            l_erro_requisitar_1.Visible = false;
            l_erro_requisitar_2.Visible = false;
            req_tag_id.Text = null;
            req_tag_name.Text = null;
            req_tag_desc.Text = null;
            input_n_mec.Text = null;
            input_t_dias.Text = null;

            devolver_groupBox.Visible = false;
            devolver_aluno_nome.Text = null;
            devolver_tag_nome.Text = null;
            l_erro_devovler.Visible = false;
        }

        private void requisitar_submeter_Click(object sender, EventArgs e)
        {
            //butao responsavel por requisitar ferramenta
            l_erro_requisitar_2.Visible = true;
            int bin_teste = 1;
            //verifica se ferraenta está alugada passando o input da tag
            dados_alug = data_layer.check_db_exists_aluger(input_requisitar_tag_id.Text);
            if (dados_alug[5].Contains("Ja existe"))
            {
                //se já alugada apresneta eerro
                l_erro_requisitar_2.ForeColor = System.Drawing.Color.DarkRed;
                l_erro_requisitar_2.Text = "Material ja alugado";
            }
            else { 
            if (!String.IsNullOrEmpty(req_tag_id.Text) &&
                !String.IsNullOrEmpty(req_tag_name.Text) &&
                !String.IsNullOrEmpty(req_tag_desc.Text) &&
                !String.IsNullOrEmpty(input_n_mec.Text) &&
                !String.IsNullOrEmpty(input_t_dias.Text))
            {
                    //senão estiver alugada verifica se os campos todos foram preenchidos

                int dias_aluguer = 0;
                int numero_mec = 0;

                try
                {
                        //verifica se os valores inseridos sãointeiros dias/numero mecanografico
                    dias_aluguer = Int32.Parse(input_t_dias.Text);
                    numero_mec = Int32.Parse(input_n_mec.Text);
                }
                catch (Exception)
                {
                    bin_teste = 0;
                        //apresenta erro se nao for
                    l_erro_requisitar_2.Text = "Dias/numero mec tem de ser inteiro!";
                }
                if (bin_teste != 0)
                {
                    if (dias_aluguer > 0 && numero_mec > 0)
                    {
                            //verifica se o numero mecanografico existe na base de dados
                        string test_temp = data_layer.check_db_exists_user(numero_mec);

                        if (test_temp.Contains("Ja existe"))
                        {
                                //se utiizador existir inserir o aluguer e mostra mensagem
                            l_erro_requisitar_2.ForeColor = System.Drawing.Color.Green;
                            l_erro_requisitar_2.Text = data_layer.insert_aluguer(numero_mec, req_tag_id.Text, dias_aluguer, dateTime);
                        }
                        else
                        {
                            l_erro_requisitar_2.Text = test_temp;
                        }
                    }
                    else
                    {
                        l_erro_requisitar_2.Text = "Tem de ser superior a 0!";
                    }
                }


            }
            else
            {
                l_erro_requisitar_2.Text = "Tem de preencher todos os campos";

            }
        }
    }
        
        private void clean_add_inv_Click_1(object sender, EventArgs e)
        {
            //limpa formulário
            try1.Text = null;
            try2.Text = null;
            try3.Text = null;

            input_desc_tag.Text = null;
            input_nome_tag.Text = null;
            input_tag_id.Text = null;
            l_insert_erro.Visible = false;
            l_insert_erro2.Visible = false;
            insert_groupbox.Visible = false;
            metroComboBox1.SelectedIndex = 0;
        }

        private void requisitar_devolver_Click(object sender, EventArgs e)
        {
            //função para devolver tag

            if (!String.IsNullOrEmpty(devolver_aluno_nome.Text) && !String.IsNullOrEmpty(devolver_tag_nome.Text))
            {//verifica se os campos foram preenchidos e da remove ao butao para dar preent a spam de logs
                requisitar_devolver.Visible = false;
                l_erro_devovler.Visible = true;
                string mensagem;
                // 4 / 84654 / [E20020808004006913008E5A] | 10 | 10/11/2017 00:00:00 / Ja existe / Hugo Barragon / Brebequim
                try
                {
                    //recebe dados do array global guarda
                    int id_row= Int32.Parse(dados_alug[0]);
                    int n_mec = Int32.Parse(dados_alug[1]);
                    string nome_tag = dados_alug[7];
                    string tag_id_alug = dados_alug[2];
                    string aluno_nome = dados_alug[6];
                    int tempo_aluguer = Int32.Parse(dados_alug[3]);
                    DateTime data_aluguer = Convert.ToDateTime(dados_alug[4]);
                    //conversao das datas e calculo para saber se existe atraso na entrega
                    double tempo_alugado_double = (dateTime - data_aluguer).TotalDays;
                    int tempo_alugado= Int32.Parse(Math.Round(tempo_alugado_double).ToString());

                    string departamento = data_layer.get_depart(tag_id_alug);
                    //cria registo de devolução
                    mensagem = data_layer.insert_log(nome_tag, tag_id_alug, departamento, aluno_nome, n_mec, data_aluguer, tempo_aluguer, dateTime);

                    if (mensagem== "Log registado com sucesso")
                    {
                        //remove ferramenta da tabela aluguer
                        mensagem = mensagem + data_layer.drop_row_aluguer(id_row);
                        if (mensagem== "Log registado com sucesso"+ " Aluguer devolvido")
                        {
                            if (tempo_alugado> tempo_aluguer)
                            {
                                //calculo final da data para dias para saber o atraso e apresenta a vermelho
                                int atraso = tempo_alugado - tempo_aluguer;
                                l_erro_devovler.ForeColor = System.Drawing.Color.DarkRed;
                                //apresneta aviso atraso
                                l_erro_devovler.Text = mensagem+" com atraso: "+ atraso + "dias";
                            }
                            else
                            {
                                l_erro_devovler.ForeColor = System.Drawing.Color.Green;
                                l_erro_devovler.Text = mensagem;
                            }
                            
                        }
                        else
                        {
                            l_erro_devovler.Text = mensagem;
                        }
                    }
                    else
                    {
                        l_erro_devovler.Text = mensagem;
                    }
                }
                catch (Exception erro)
                {

                    l_erro_devovler.Text = erro.Message;
                }
                
            }
            else
            {l_erro_devovler.Text = "Os campos teem de estar preenchidos";}
        }
    }
}
