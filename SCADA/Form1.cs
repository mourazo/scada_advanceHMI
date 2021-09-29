using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SCADA
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        string conexion = "datasource=localhost;port=3306;username=root;password=root";

        private void timerTick(object sender, EventArgs e)
        {
            try { 
            SqlConnection cn = new SqlConnection(conexion);

            string query = @"INSERT INTO tabla (value1)
                                VALUES (@value1)"; //query de insercción
            cn.Open(); //abro conexión 

            SqlCommand cmd = new SqlCommand(query, cn);

            cmd.Parameters.Add("@value1", SqlDbType.Int); //Otro parámetro
            cmd.Parameters["@value1"].Value = int.Parse(basicLabel2.Text); //valor parámetro

            cmd.ExecuteNonQuery();//ejecuto el comando
            cn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ERROR DE DATOS" + ex);
            }

}
    }
}
