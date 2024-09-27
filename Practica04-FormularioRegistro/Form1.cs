using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Practica04_FormularioRegistro
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            tbNombres.Leave += checkNombres;
            tbApellidos.Leave += checkApellidos;
            tbEdad.Leave += checkEdad;
            tbEstatura.Leave += checkEstatura;
            tbTelefono.Leave += checkTelefono;
        }
        private bool isValidInt(string str)
        {
            int resultado;
            return int.TryParse(str, out resultado);
        }
        private bool isValidFloat(string str)
        {
            decimal resultado;
            return decimal.TryParse(str, out resultado);
        }
        private bool isValidTenDigitNum(string str)
        {
            long resultado;
            return long.TryParse(str, out resultado);
        }
        private bool isValidText(string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-Z\s]+$");
        }
        
        private void checkNombres(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length != 0)
            {
                if (!isValidText(textBox.Text))
                {
                    MessageBox.Show("Introduzca un nombre valido","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }
        private void checkApellidos(object sender, EventArgs args)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length != 0)
            {
                if (!isValidText(textBox.Text))
                {
                    MessageBox.Show("Introduzca un apellido valido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }
        private void checkEdad(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length != 0)
            {
                if (!isValidInt(textBox.Text))
                {
                    MessageBox.Show("Introduzca una edad valida","Error",MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }
        private void checkEstatura(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (textBox.Text.Length != 0)
            {
                if (!isValidFloat(textBox.Text))
                {
                    MessageBox.Show("Introduzca una estatura decimal valida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }
        private void checkTelefono(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if(textBox.Text.Length != 0)
            {
                if (!isValidTenDigitNum(textBox.Text))
                {
                    MessageBox.Show("Introduzca un telefono valido de 10 digitos", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox.Clear();
                }
            }
        }


        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void bGuardar_Click(object sender, EventArgs e)
        {
            string nombres, apellidos;
            int edad;
            float estatura;
            long telefono;
            nombres = tbNombres.Text;
            apellidos = tbApellidos.Text;
            edad = int.Parse(tbEdad.Text);
            estatura = float.Parse(tbEstatura.Text);
            telefono = long.Parse(tbTelefono.Text);

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
