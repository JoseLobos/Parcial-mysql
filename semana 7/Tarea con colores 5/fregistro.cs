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
    }
}
