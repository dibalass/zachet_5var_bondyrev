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

namespace Диф.Зачет_5_вариант_Бондырев
{
    public partial class Form1 :Form
    {
        public Form1 ()
        {
            InitializeComponent( );
        }
        static bool checkFile (string file)
        {
            if ( File.Exists(file) )
            {
                string [ ] Lines = File.ReadAllLines(file);
                if ( Lines.Length == 0 )
                {
                    MessageBox.Show("Файла пустой");
                    return true;
                }
            }
            else
            {
                MessageBox.Show("Файла не существует");
                return true;
            }
            return true;
        }

        private void button1_Click (object sender, EventArgs e)
        {
            if ( checkFile($"{textBox1.Text}"))
            {
                string [ ] Lines = File.ReadAllLines($"{textBox1.Text}");
                for ( int i = 0; i < Lines.Length; i++ )
                {
                    listBox1.Items.Add(Lines[ i ]);
                }
                groupBox1.Visible = true;
            }
        }

        private void label2_Click (object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged (object sender, EventArgs e)
        {

        }

        string [ ] tovars = File.ReadAllLines($"list.txt");
        //List<string> tovar = new List<string>( );
        private void button2_Click (object sender, EventArgs e)
        {
            if ( textBox2.Text.Length == 1 )
            {
                int LineIndex =100 ;
                if ( Char.IsLetter(Convert.ToChar(textBox2.Text)) )
                {
                    listBox1.Items.Clear( );
                    string [ ] Lines = File.ReadAllLines($"{textBox1.Text}");
                    //string [ ] tovars = File.ReadAllLines($"{textBox1.Text}");
                    for ( int i = 1; i < Lines.Length; i++ )
                    {
                        int index = Lines [ i ].IndexOf(':');
                        Lines [ i ] = Lines [ i ].Remove(0,index+1);
                        if ( Lines [ i ].Contains(textBox2.Text) )
                        {
                            LineIndex = i;
                            i = Lines.Length;
                        }
                    }
                    for ( int i = 0; i < tovars.Length; i++ )
                    {
                        if ( i != LineIndex )
                            listBox1.Items.Add(tovars [ i ]);
                    }
                }
                else
                    MessageBox.Show("Введи букву");
            }
            else
                MessageBox.Show("Введи один символ");
        }

        private void button3_Click (object sender, EventArgs e)
        {
            if ( textBox3.Text.Length != 0 )
            {
                if ( Char.IsLetter(Convert.ToChar(textBox3.Text.Remove(1))) )
                {
                    if (!listBox1.Items.Contains(textBox3.Text + $": {textBox3.Text.Remove(1).ToLower( )}") )
                    {
                        listBox1.Items.Add(textBox3.Text + $": {textBox3.Text.Remove(1).ToLower( )}");
                    }
                    else
                        MessageBox.Show("такой тавар уже есть");
                }
                else
                    MessageBox.Show("первая символ не можеть быть цифрой");
            }
            else
                MessageBox.Show("строка пустая");
        }

        private void button4_Click (object sender, EventArgs e)
        {
            listBox1.Items.Clear( );
            var orderedPeople = from p in tovars orderby p select p;
            foreach ( var p in orderedPeople )
                listBox1.Items.Add(p);
        }
    }
}
