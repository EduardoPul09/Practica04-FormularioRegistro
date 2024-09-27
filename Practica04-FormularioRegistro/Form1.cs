using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Practica04_FormularioRegistro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            string nombres = tbNombres.Text;
            string apellidos = tbApellidos.Text;
            string edad = tbEdad.Text;
            string estatura = tbEstatura.Text;
            string telefono = tbTelefono.Text;

            string genero = "";
            if (rbHombre.Checked)
            {
                genero = "Hombre";
            }
            else if (rbMujer.Checked)
            {
                genero = "Mujer";
            }
            string datos = $"Nombres: {nombres}\r\nApellidos: {apellidos}\r\nTelefono: {telefono} \r\nEstatura: {estatura} \r\nEdad: {edad} años\r\nGenero: {genero}";

            string rutaAchivos = "C:\\Users\\eduso\\Desktop\\Prog. A\\datos.txt";
            //File.WriteAllText(rutaAchivos, datos);
            bool archivoExiste = File.Exists(rutaAchivos);

            using (StreamWriter writer = new StreamWriter(rutaAchivos, true))
            {
                if (archivoExiste)
                {
                    writer.WriteLine();
                }
                writer.WriteLine(datos);

            }
            MessageBox.Show("Datos guardados: \n\n" + datos, "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);


        }

        private void bBorrar_Click(object sender, EventArgs e)
        {
            tbNombres.Clear();
            tbApellidos.Clear();
            tbEstatura.Clear();
            tbTelefono.Clear();
            tbEdad.Clear();
            rbHombre.Checked = false;
            rbMujer.Checked = false;
        }
    }
}
