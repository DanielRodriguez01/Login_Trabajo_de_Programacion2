using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Linq.Expressions;


namespace Login_Trabajo_de_Programacion2
{
    public partial class Form1 : Form
    {
        OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\Escritorio\\TP\\BD\\Login_Usuario.mdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                conexion.Open();
                MessageBox.Show("Conectado");
            }
            
            catch (Exception a)
                {
                    MessageBox.Show("Error por: " + a.ToString());
                
            }
            

        }

        private void BtnEntrar_Click(object sender, EventArgs e)
        {
            string consulta = "Escriba su contraseña = " + TxtContraseña.Text + "Escriba su usario = " + TxTUsuario + " ;";
            OleDbCommand comando = new OleDbCommand(consulta, conexion);
            OleDbDataReader leeBd;
            leeBd = comando.ExecuteReader();
            Boolean existereg = leeBd.HasRows;
            if (existereg )
            {
                MessageBox.Show("Bienvenido al Sistema " + TxTUsuario);
                Form2 abrir = new Form2();
                this.Hide();
                abrir.Show();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrecto, ingrese de nuevo");
                return;
            }
            conexion.Close();
   
        }
    }
}
