﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Dnevnik_2._0
{
    public partial class Form3 : Form
    {

        public SQLiteConnection conn,conn2;
        public Form3()
        {
            InitializeComponent();
        }

        double nw;
        int rw, rh, x, y;
        public int a, b;
        int n = 0;
        int border=10;

        Form2 f2;
        public int id_odeljenja;
        public int id_predmeta;
        public int ind;

        public List<PictureBox> p = new List<PictureBox>();
        public List<Label> l = new List<Label>();
        int jedinice, dvojke, trojke, cetvorke, petice = 0;

        private void button3_Click(object sender, EventArgs e)
        {
            Microsoft.Office.Interop.Excel._Application app = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel._Workbook workbook = app.Workbooks.Add(Type.Missing);
            Microsoft.Office.Interop.Excel._Worksheet worksheet = null;
            app.Visible = true;


            worksheet = workbook.Sheets["Sheet1"];
            worksheet = workbook.ActiveSheet;
            worksheet.Columns.AutoFit();


            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                worksheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        worksheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                    }
                    else
                    {
                        worksheet.Cells[i + 2, j + 1] = "";
                    }
                    worksheet.Columns[j + 1].AutoFit();

                }
                //MessageBox.Show(progressBar1.Value.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Visible)
            {
                dataGridView1.Hide();
                button3.Hide();
                this.Size = s;
                foreach (var item in p)
                {
                    this.Controls.Add(item);
                }
                foreach (var item in l)
                {
                    this.Controls.Add(item);
                }
            }
            else
            {
                button3.Show();

                this.Width = dataGridView1.Width + button1.Location.X * 2;
                dataGridView1.Show();
                foreach (var item in p)
                {
                    this.Controls.Remove(item);
                }
                foreach (var item in l)
                {
                    this.Controls.Remove(item);
                }
            }
        }
        Size s;
        private void Form3_Load(object sender, EventArgs e)
        {
            s = this.Size;
            f2 = (Form2)Application.OpenForms[1];
            this.label1.Text = f2.label1.Text;
            conn = f2.conn;
            conn2 = f2.conn2;

            dataGridView1.Height = dataGridView1.RowHeadersWidth;
            //MessageBox.Show(id_predmeta.ToString());
            Kalkulacije_broja_ucenika();

            ucitaj();

            foreach (var pic in p)
            {
                pic.Click += new EventHandler(pictureBox1_Click);
                this.Controls.Add(pic);
            }
            //postavlja label sa imenom ucenika
            foreach (var label in l)
            {
                this.Controls.Add(label);
            }
        }
        //settings
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }
        public void kordinate()
        {
            x = Math.Max(button1.Width + button1.Location.X, label1.Width + label1.Location.X) + 20; ;

            y = border;
        }
        public void Kalkulacije_broja_ucenika()
        {
            int k = 0;
            kordinate();
            if (this.VerticalScroll.Visible == true)
            {
                k = System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            }
            rw = 15; rh = 40;
            a = 100; b = 120;
            double d = (this.Width - x - a - k) / (a + rw);
            nw = Math.Floor(d);
            if (nw < 1)
                nw = 1;
            

        }

        public void ucitaj()
        {
            f2.o[ind].u.Clear();

            conn.Open();

            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader2;
            SQLiteCommand sqlite_cmd2;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT * FROM Ucenik where ID_odeljenja = {id_odeljenja}";

            //MessageBox.Show(id_predmeta.ToString());
            sqlite_datareader = sqlite_cmd.ExecuteReader();
            while (sqlite_datareader.Read())
            {
                //tuple ocena,opis ocene
                List<Tuple<int, string>> o = new List<Tuple<int, string>>();


                int index = sqlite_datareader.GetInt16(0);
                string uc = sqlite_datareader.GetString(1);
                conn2.Open();
                //konekcija za tabelu ocene

                //komanda za citanje
                sqlite_cmd2 = conn2.CreateCommand();
                sqlite_cmd2.CommandText = $"SELECT * FROM Ocena Where ID_ucenika = {index} and ID_predmeta = 1";

                sqlite_datareader2 = sqlite_cmd2.ExecuteReader();
                int srednja = 0;

                dataGridView1.Rows.Add(uc);
                if(dataGridView1.Height<s.Height)
                    dataGridView1.Height += dataGridView1.RowHeadersWidth;

                //cita ocene i broj da li su 5, 4, 3, 2 ili 1 da bi se uradila pita 
                while (sqlite_datareader2.Read())
                {
                    int ocena = sqlite_datareader2.GetInt16(2);
                    string opis = sqlite_datareader2.GetString(4);
                    o.Add(Tuple.Create(ocena, opis));
                    srednja += ocena;
                    if (ocena == 5)
                        petice++;
                    else if (ocena == 4)
                        cetvorke++;
                    else if (ocena == 3)
                        trojke++;
                    else if (ocena == 2)
                        dvojke++;
                    else
                        jedinice++;
                    //izdvaja mesec iz datuma
                    int dt = int.Parse(sqlite_datareader2.GetString(3).Split('-')[1]);
                    dataGridView1.Rows[n].Cells[dt].Value += ocena.ToString()+" ";
                    dataGridView1.Rows[n].Cells[dt].Value += ocena.ToString() + " ";
                }
                //raspodela ucenika po ekranu
                Raspodela(uc, sqlite_datareader.GetBoolean(5));
                conn2.Close();

                //dodaje ucenika u klasu

                f2.o[ind].u.Add(new ucenik(uc, o, srednja, sqlite_datareader.GetInt16(0), sqlite_datareader.GetBoolean(5)));

                dataGridView1.Rows[n].Cells["prosek"].Value = f2.o[ind].u[n].srednja;
                //pomera u desno
                x += a + rw;
                n++;

                //kad ce da prelomi u novi red
                if (n % nw == 0)
                {
                    y += b + rh;
                    x = 100;
                }

            }
            conn.Close();
        }
        public void Raspodela(string uc, bool pol)
        {
            //rasporedjuje ucenike

            string odredi_pol;
            //pos
            if (pol)
                odredi_pol = "musko.jpg";
            else
                odredi_pol = "zensko.jpg";


            //dadavanje pictueboxa i labla
            p.Add(new PictureBox {
                Name = n.ToString(),
                Size = new Size(a, b),
                Location = new Point(x, y),
                Image = new Bitmap(Image.FromFile(odredi_pol), new Size(a, b)),
                BorderStyle = BorderStyle.Fixed3D
            });
            l.Add(new Label {
                Name = n.ToString(),
                Size = new Size(a, rh * 3 / 4),
                Location = new Point(x, y + b),
                Text = uc,
                TextAlign = ContentAlignment.MiddleCenter,
            });
        }
    }
}
