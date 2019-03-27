using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace bazydanych
{
    public partial class Form1 : Form
    {
        public class osoba
        {
            
            public string identyfikator;
            public string imie;
            public string nazwisko;
            
           


            public osoba(string imie, string nazwisko, string identyfikator)
            {
                this.identyfikator = identyfikator;
                this.imie = imie;
                this.nazwisko = nazwisko;
                

            }

            public override string ToString()
            {
                return $" {identyfikator} {imie} {nazwisko}";
            }
        }

        List<osoba> users = new List<osoba>();

        public Form1()
        {
            InitializeComponent();

            textBox5.Text = AppDomain.CurrentDomain.BaseDirectory + @"\test.txt";
        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            MessageBox.Show(listBox1.SelectedItem.ToString());
        }

        private void label5_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            osoba newosoba = new osoba(textBox1.Text, textBox2.Text, textBox3.Text);
            users.Add(newosoba);
            listBox1.Items.Add(newosoba.ToString());
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            
        }

       

        private void button2_Click(object sender, EventArgs e)
        {
            string lines = "";
    
     
            foreach (var user in users)
            {
                lines += $"{user.identyfikator} {user.imie} {user.nazwisko}  \n";
            }
            using (StreamWriter sw1 = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"\baza.txt"))
            {
               
                sw1.WriteLine(lines);
                sw1.Close();
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox5.Text = AppDomain.CurrentDomain.BaseDirectory + @"\baza.txt";
            listBox1.Items.Clear();
            try
            {
                
                using (StreamReader sr = new StreamReader(textBox5.Text))
                {
                   
                    String line = sr.ReadToEnd();
                    String[] dana = line.Split(new string[] {"\n"}, StringSplitOptions.None);
                    foreach (var userek in dana)
                    {
                        if (userek != "\n" && userek != " " && userek != "\r")
                        {
                            listBox1.Items.Add(userek);
                        }
                    }
                    
                }

                MessageBox.Show("Pomyslnie zaladowano dane");
            }
            catch
            {
                MessageBox.Show("Nie odczytano pliku.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }

   
}