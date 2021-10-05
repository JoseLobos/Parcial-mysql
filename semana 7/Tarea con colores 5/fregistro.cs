using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data;
using MySql.Data.MySqlClient;


namespace Tarea_con_colores_5
{
    public partial class fregistro : Form
   
    {
        public string cadena_conexion = "Database=agenda;Data Source=localhost;User Id=dba;Password=dba";
        public fregistro()
        {
            InitializeComponent();
        }

        private void fregistro_Load(object sender, EventArgs e)
        {
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            comboBox2.Enabled = false;
            try
            {
                string consulta = "select * from contactos";
                MySqlConnection conexion = new MySqlConnection("Database=agenda;Data Source=localhost;User Id=dba;Password=dba");
                MySqlDataAdapter comando = new MySqlDataAdapter(consulta, conexion); System.Data.DataSet ds = new System.Data.DataSet();
                comando.Fill(ds, "agenda"); dataGridView1.DataSource = ds; dataGridView1.DataMember = "agenda";
            }
            catch (MySqlException)
            {
                MessageBox.Show("Error de conexion", "Error!", MessageBoxButtons.OK,
                MessageBoxIcon.Error);
            }

        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            comboBox2.Enabled = true;
            textBox1.Text = "";
            textBox2.Text = "";
            comboBox2.Text = "Seleccione nivel";
            textBox1.Focus();
            button5.Visible = false;
            button9.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection myConnection = new MySqlConnection("Database=agenda;Data Source=localhost;User Id=dba;Password=dba");
                string myInsertQuery = "INSERT INTO contactos(nombre,clave,nivel) Values(?nombre,?clave,?nivel)"; MySqlCommand myCommand = new MySqlCommand(myInsertQuery);

                myCommand.Parameters.Add("?nombre", MySqlDbType.VarChar, 40).Value = textBox1.Text; myCommand.Parameters.Add("?clave", MySqlDbType.VarChar, 45).Value = textBox2.Text; myCommand.Parameters.Add("?nivel", MySqlDbType.Int32, 4).Value = comboBox2.Text;

                myCommand.Connection = myConnection;
                myConnection.Open(); myCommand.ExecuteNonQuery(); myCommand.Connection.Close();

                MessageBox.Show("Usuario agregado con éxito", "Ok", MessageBoxButtons.OK, MessageBoxIcon.Information);

                string consulta = "select * from contactos";

                MySqlConnection conexion = new MySqlConnection("Database=agenda;Data Source=localhost;User Id=dba;Password=dba");
                MySqlDataAdapter da = new MySqlDataAdapter(consulta, conexion); System.Data.DataSet ds = new System.Data.DataSet(); da.Fill(ds, "agenda"); dataGridView1.DataSource = ds; dataGridView1.DataMember = "agenda";
             catch (MySqlException)
            {
                MessageBox.Show("Ya existe el usuario", "Alerta!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            button5.Visible = true; button9.Visible = false;
            textBox1.Enabled = false; textBox2.Enabled = false; comboBox2.Enabled = false; button5.Focus();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true; textBox2.Enabled = true; comboBox2.Enabled = true;

            textBox1.Focus(); button7.Visible = false; button10.Visible = true;

        }

        private void button12_Click(object sender, EventArgs e)
        {
            try
            {
                string myConnectionString = ""; if (myConnectionString == "")
                {
                    myConnectionString = "Database = agenda; Data Source = localhost; User Id = dba; Password = dba = ";  } 
              MySqlConnection myConnection = new MySqlConnection(myConnectionString); string mySelectQuery = "SELECT * From agenda Where id=" + id.Text + "";
                    MySqlCommand myCommand = new MySqlCommand(mySelectQuery, myConnection); myConnection.Open(); MySqlDataReader myReader; myReader = myCommand.ExecuteReader(); if (myReader.Read())
                    {
                        Nombre.Text = (myReader.GetString(1)); telefono.Text = (myReader.GetString(2));
                    }
                    else
                    {
                        avisos a = new avisos();
                        a.label1.Text = "El Registro No Existe";
                        a.ShowDialog();
                    }
                    myReader.Close(); myConnection.Close();
                }
            
            catch (System.Exception)
            {
                avisos a = new avisos();
                a.label1.Text = "Escribe el ID";
                a.ShowDialog();
            }



        }
    }


}
    

