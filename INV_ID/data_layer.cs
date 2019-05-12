using System;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace INV_ID
{
    class data_layer
    {
        //camada responsavel por acesso a base de dados
        //vai buscar ao config ini os dados para conecção a base de dados
        private static string connectionString = ConfigurationManager.ConnectionStrings["db"].ConnectionString;//"datasource=localhost;port=3306;username=root;password=;database=inv_id;";

        public string insert_inventario(string tag_id, string tag_name, string depart, string tag_desc, DateTime data)
        {
            //recebe dados para inserir a ferrametna nova

            string query = "INSERT INTO inventario(`tag_id`, `nome`,`Departamento`,`desc`, `data_add`) VALUES ("+
                "@tag_id,"+
                "@tag_name,"+
                "@depart,"+
                "@tag_desc,"+
                "@data)";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.CommandTimeout = 60;
            //query com parametros para dar prevent a mysql
            cmd.Parameters.AddWithValue("@tag_id", tag_id);
            cmd.Parameters.AddWithValue("@tag_name", tag_name);
            cmd.Parameters.AddWithValue("@depart", depart);
            cmd.Parameters.AddWithValue("@tag_desc", tag_desc);
            cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd H:mm:ss"));
            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();
                databaseConnection.Close();
                return "Material registado com sucesso";

            }
            catch (Exception ex)
            {
                // Show any error message.
                return ex.ToString();
            }
        }

        public string check_db_exists_id(string tag_id)
        {
            //verifica se a tag id passada já existe na base de dados

            // Select all
            string query = "SELECT * FROM inventario";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (tag_id == reader.GetString(0))
                        {//se existir retorna nome da ferramenta e erro
                            string temp = reader.GetString(1);
                            databaseConnection.Close();
                            return "Ja existe " + temp;
                        }
                    }
                }
                else
                {
                    databaseConnection.Close();
                    return "Ainda não existe tabela vazia"; ;
                }
                databaseConnection.Close();
                return "Ainda não existe";
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
                return "ERRO:" + ex.Message.ToString();
            }

        }

        public string[] check_db_exists_aluger(string tag_id)
        {
            //verifica se o aluguer existe e retorna array com dados do mesmo

            // Select especifico
            string query = "SELECT inv_id.aluguer.id_aluger, inv_id.aluguer.users_n_mec," +
                           " inv_id.aluguer.inventario_tag_id, inv_id.aluguer.t_aluger," +
                           "inv_id.aluguer.data_aluguer, inv_id.users.Nome,inv_id.inventario.nome" +
                           " FROM((" +
                           "inv_id.aluguer INNER JOIN inv_id.users ON users.n_mec = aluguer.users_n_mec) " +
                           "INNER JOIN inv_id.inventario ON inventario.tag_id = aluguer.inventario_tag_id)";


            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            string[] temp = new string[8];

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // If there are available rows

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (tag_id == reader.GetString(2))
                        {
                            //se existir um aluguer com a tag id passada retorna os dados do aluguer

                            temp[0] = reader.GetString(0);
                            temp[1] = reader.GetString(1);
                            temp[2] = reader.GetString(2);
                            temp[3] = reader.GetString(3);
                            temp[4] = reader.GetString(4);
                            temp[5] = "Ja existe";
                            temp[6] = reader.GetString(5);
                            temp[7] = reader.GetString(6);
                            databaseConnection.Close();
                            return temp;
                        }
                    }
                }
                else
                {
                    databaseConnection.Close();
                    temp[0] = temp[1] = temp[2] = temp[3] = temp[4] = temp[6] = temp[7] = null;
                    temp[5] = "Ainda não existe tabela vazia";
                    return temp;
                }
                databaseConnection.Close();
                temp[0] = temp[1] = temp[2] = temp[3] = temp[4] = temp[6] = temp[7] = null;
                temp[5] = "Ainda não existe";
                return temp;
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
                temp[0] = temp[1] = temp[2] = temp[3] = temp[4] = temp[6] = temp[7] = null;
                temp[5] = "ERRO:" + ex.Message.ToString();
                return temp;
            }

        }

        public string[] get_inv_data(string tag_id)
        {
            //recebe tagid para retornar array com os dados da ferramenta
            // Select all
            string query = "SELECT * FROM inventario";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            string[] temp = new string[5];

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // If there are available rows

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (tag_id == reader.GetString(0))
                        {
                            //se encontrar a tag id na base de dados retorna um array com dados
                            temp[0] = reader.GetString(0);
                            temp[1] = reader.GetString(1);
                            temp[2] = reader.GetString(2);
                            temp[3] = reader.GetString(3);
                            temp[4] = reader.GetString(4);
                            databaseConnection.Close();
                            return temp;
                        }
                    }
                }
                else
                {
                    databaseConnection.Close();
                    temp[0] = temp[1] = temp[2] = temp[3] = temp[4] = null;
                    return temp;
                }
                databaseConnection.Close();
                temp[0] = temp[1] = temp[2] = temp[3] = temp[4] = null;
                return temp;
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
                temp[0] = temp[1] = temp[2] = temp[3] = temp[4] = null;
                return temp;
            }

        }

        public string insert_aluguer(int n_mec, string tag_id, int tempo_aluguer, DateTime data)
        {
            //recebe dados do material para reqgistar o aluguer

            string query = "INSERT INTO aluguer(`id_aluger`,`users_n_mec`,`inventario_tag_id`,`t_aluger`,`data_aluguer`) VALUES ("+
                "null,"+
                "@n_mec," +
                "@tag_id,"+
                "@tempo_aluguer," +
                "@data)";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.CommandTimeout = 60;

            //query parametrizada para dar prevent a mysql injection
            cmd.Parameters.AddWithValue("@n_mec", n_mec);
            cmd.Parameters.AddWithValue("@tag_id", tag_id);
            cmd.Parameters.AddWithValue("@tempo_aluguer", tempo_aluguer);
            cmd.Parameters.AddWithValue("@data", data.ToString("yyyy-MM-dd H:mm:ss"));

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();
                databaseConnection.Close();
                return "Aluguer registado com sucesso";

            }
            catch (Exception ex)
            {
                // Show any error message.
                return ex.ToString();
            }
        }

        public string check_db_exists_user(int n_mec)
        {

            //recebe numero mecanografico para ver se utilizador existe

            // Select all
            string query = "SELECT * FROM users";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // If there are available rows
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (n_mec == reader.GetInt32(0))
                        {
                            databaseConnection.Close();
                            //retorno para tratamento
                            return "Ja existe";
                        }
                    }
                }
                else
                {
                    databaseConnection.Close();
                    return "Ainda não existe tabela vazia"; ;
                }
                databaseConnection.Close();
                return "Utilizador não existe";
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
                return "ERRO:" + ex.Message.ToString();
            }

        }

        public string insert_log(string nome_tag, string tag_id,string departamento, string nome_aluno, int n_mec_aluno, DateTime data_aluguer, int t_alug_permitido, DateTime data_devol)
        {
            //recebe dados todos passados e cria um registo na tabela log, cria apenas quando ferramenta é devolvida

            string query = "INSERT INTO logs(`id_log`, `nome_tag`, `id_tag`,`Departamento`, `nome_aluno`, `m_mec_aluno`, `data_aluguer`, `t_aluguer_permitido`, `data_devolvido`) VALUES('null'," +
                " @nome_tag, @tag_id,@departamento," +
                "@nome_aluno,@n_mec_aluno," +
                "@data_aluguer,@t_alug_permitido,@data_devol)";
            //(@val1,@val2,@txt)
            //command.AddParameterWithValue( "val1", value1 );
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.CommandTimeout = 60;

            //query paramterized para prevent mysql injection

            cmd.Parameters.AddWithValue("@nome_tag", nome_tag);
            cmd.Parameters.AddWithValue("@tag_id", tag_id);
            cmd.Parameters.AddWithValue("@departamento", departamento);
            cmd.Parameters.AddWithValue("@nome_aluno", nome_aluno);
            cmd.Parameters.AddWithValue("@n_mec_aluno", n_mec_aluno);
            cmd.Parameters.AddWithValue("@data_aluguer", data_aluguer.ToString("yyyy-MM-dd H:mm:ss"));
            cmd.Parameters.AddWithValue("@t_alug_permitido", t_alug_permitido);
            cmd.Parameters.AddWithValue("@data_devol", data_devol.ToString("yyyy-MM-dd H:mm:ss"));

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();
                databaseConnection.Close();
                //retorno para tratamento
                return "Log registado com sucesso";

            }
            catch (Exception ex)
            {
                // Show any error message.
                return ex.ToString();
            }
        }

        public string drop_row_aluguer(int id_row)
        {
            //devolver material recebe id da row para apgar da talea aluguer pois foi devolvido

            string query = "DELETE FROM `aluguer` WHERE `aluguer`.`id_aluger` = @id_row";
            //(@val1,@val2,@txt)
            //command.AddParameterWithValue( "val1", value1 );
            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.CommandTimeout = 60;

            cmd.Parameters.AddWithValue("@id_row", id_row);

            try
            {
                databaseConnection.Open();
                MySqlDataReader myReader = cmd.ExecuteReader();
                databaseConnection.Close();
                //retorno da mensagem para tratamento
                return " Aluguer devolvido";

            }
            catch (Exception ex)
            {
                // Show any error message.
                return ex.ToString();
            }
        }

        public string[] get_acc_data(string user)
        {
            //recebe o username inserido para retornar os dados da conta caso exista

            // Select all
            string query = "SELECT * FROM acc";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand commandDatabase = new MySqlCommand(query, databaseConnection);
            commandDatabase.CommandTimeout = 60;
            MySqlDataReader reader;

            string[] temp = new string[3];

            try
            {
                databaseConnection.Open();
                reader = commandDatabase.ExecuteReader();
                // If there are available rows

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (user == reader.GetString(1))
                        {
                            //caso o username exista retorna em array os dados necessários 
                            //e a mensagem para tratar erros
                            temp[0] = reader.GetString(1);
                            temp[1] = reader.GetString(2);
                            temp[2] = "Existe";
                            databaseConnection.Close();
                            return temp;
                        }
                    }
                }
                else
                {
                    //caso de erro retorna mensagem para tratamento do erro e array empy
                    databaseConnection.Close();
                    temp[0] = temp[1] = null;
                    temp[2] = "Tabela empty";
                    return temp;
                }
                databaseConnection.Close();
                temp[0] = temp[1] = null;
                temp[2] = "Não existe";
                return temp;
            }
            catch (Exception ex)
            {
                databaseConnection.Close();
                temp[0] = temp[1] = null;
                temp[2] = ex.Message.ToString();
                return temp;
            }

        }

        public string get_depart(string tag_id)
        {
            //função que recebe a tag id e retorna o departamento

            // Select all
            string query = "SELECT * FROM `inventario` WHERE inventario.tag_id=@id_tag";

            MySqlConnection databaseConnection = new MySqlConnection(connectionString);
            MySqlCommand cmd = new MySqlCommand(query, databaseConnection);
            cmd.CommandTimeout = 60;
            cmd.Parameters.AddWithValue("@id_tag", tag_id);
            MySqlDataReader reader;
            
            string temp = "";

            try
            {
                databaseConnection.Open();
                reader = cmd.ExecuteReader();
                // If there are available rows
                

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (tag_id == reader.GetString(0))
                        {
                            //se tag existir recebe os dados e retorna
                           temp= reader.GetString(2); ;
                           databaseConnection.Close();
                           return temp;
                        }
                    }
                }
                else
                {
                    databaseConnection.Close();

                    return "0 rows";
                }
                databaseConnection.Close();

                return "pois";
            }
            catch (Exception e)
            {
                databaseConnection.Close();

                return e.Message;
            }

        }

    }
}