﻿using System;
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
        public fregistro()
        {
            InitializeComponent();
        }
        static string conexion = "SERVER=127.0.0.1;PORT=3306;DATABASE=agenda;UID=root;PASSWORDS=;";
        MySqlConnection cn = new MySqlConnection(conexion);


        private void fregistro_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = llenar_grid();
        }
        public DataTable llenar_grid()
        {
            cn.Open();
            DataTable dt = new DataTable();
            string llenar = "Select* From contactos";
            MySqlCommand cdm = new MySqlCommand(llenar, cn);
            MySqlDataAdapter da = new MySqlDataAdapter(cdm);
            da.Fill(dt);
            cn.Close();
            return dt;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cn.Open();
            string insertar = "INSERT INTO contactos (CODIGO,NOMBRE,USUARIO,CLAVE,NIVEL,CORREO)values(@codigo,@nombre,@usuario,@clave,@nivel,@correo)";
            MySqlCommand cmd = new MySqlCommand(insertar, cn);

            cmd.Parameters.AddWithValue("@codigo", textBox5.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmd.Parameters.AddWithValue("@usuario", textBox1.Text);
            cmd.Parameters.AddWithValue("@clave", textBox3.Text);
            cmd.Parameters.AddWithValue("@nivel", comboBox2.Text);
            cmd.Parameters.AddWithValue("@correo", textBox4.Text);
            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Los datos fueron agregados con exito");
            dataGridView1.DataSource = llenar_grid();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            cn.Open();
            string actualizar = "UPDATE contactos SET CODIGO=@codigo,NOMBRE=@nombre,USUARIO=@usuario,CLAVE=@clave,NIVEL=@nivel,CORREO=@correo WHERE CODIGO=@codigo";
            MySqlCommand cmd = new MySqlCommand(actualizar, cn);

            cmd.Parameters.AddWithValue("@codigo", textBox5.Text);
            cmd.Parameters.AddWithValue("@nombre", textBox2.Text);
            cmd.Parameters.AddWithValue("@usuario", textBox1.Text);
            cmd.Parameters.AddWithValue("@clave", textBox3.Text);
            cmd.Parameters.AddWithValue("@nivel", comboBox2.Text);
            cmd.Parameters.AddWithValue("@correo", textBox4.Text);
            cmd.ExecuteNonQuery();

            cn.Close();
            MessageBox.Show("Datos actualizados con exito");
            dataGridView1.DataSource = llenar_grid();


        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try 
            { 
            textBox5.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox1.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            comboBox2.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }
        catch {
    }
        
       }

        private void button6_Click(object sender, EventArgs e)
        {
            cn.Open();
            string eliminar = "DELETE FROM contactos WHERE CODIGO=@CODIGO";
            MySqlCommand cmd = new MySqlCommand (eliminar, cn);

            cmd.Parameters.AddWithValue("@codigo", textBox5.Text);
            cmd.ExecuteNonQuery();
            cn.Close();
            MessageBox.Show(" Los datos fueron eliminados  con exito");
            dataGridView1.DataSource = llenar_grid();
        }
    }
}



