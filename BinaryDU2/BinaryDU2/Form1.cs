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

namespace BinaryDU2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            StreamReader sr = new StreamReader("sport.txt", Encoding.GetEncoding("windows-1250"));
            FileStream fs = new FileStream("sport.dat", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            BinaryWriter bw = new BinaryWriter(fs, Encoding.GetEncoding("windows-1250"));
            while(!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                string[] pole = s.Split(';');
                for (int i = 0; i < pole.Length; i++)
                {
                    if(i==0||i==4||i==5)
                    {
                        bw.Write(int.Parse(pole[i]));
                    } else if (i == 3)
                    {
                        bw.Write(char.Parse(pole[i]));
                    }else
                    {
                        bw.Write(pole[i]);
                    }

                }
            }
            BinaryReader br = new BinaryReader(fs, Encoding.GetEncoding("windows-1250"));
            br.BaseStream.Position = 0;
            while(br.BaseStream.Position < br.BaseStream.Length)
            {
                string s = "";
                s += br.ReadInt32() + ";";
                s += br.ReadString() + ";";
                s += br.ReadString() + ";";
                s += br.ReadChar() + ";";
                s += br.ReadInt32() + ";";
                s += br.ReadInt32();
                textBox1.AppendText(s + "\r\n");
            }
            br.Close();
            fs.Close();
            sr.Close();
        }
    }
}
