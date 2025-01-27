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
    public partial class Form6 : Form
    {
        public SQLiteConnection conn, conn2;
        Form1 f1;
        public List<Predmet> pred = new List<Predmet>();

        public Form6()
        {
            InitializeComponent();
        }
        //id_ucenika
        public int index;
        public string ime, username, password, odredi_pol;
        public bool pol;
        int x, y;
        //int n = 0;
        int m;
        List<Button> bu = new List<Button>();
        List<Label> la = new List<Label>();
        int strana = 40;
        int border = 20;
        int rw = 5;
        public int petice = 0, cetvorke = 0, trojke = 0, dvojke = 0, jedinice = 0;
        //string legenda = "Ocene";
        //List<Tuple<int,int, string>> P_oo = new List<Tuple<int,int, string>>();
        //List<string> predmeti = new List<string>();
        List<Tuple<int, string>> oo = new List<Tuple<int, string>>();

        string seriija = "Ocene";

        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;

        private void Form5_FormClosing(object sender, FormClosingEventArgs e)
        {
            f1.Show();
        }

        public void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;

            dragFormPoint = this.Location;
        }
        public void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        public void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        int a = 100, b = 120;
        public void postavke()
        {
            //label2.Text = "Prosek: ";
        }
        private void Form5_Load(object sender, EventArgs e)
        {
            //default podesavanja
            postavke();
            f1 = (Form1)Application.OpenForms[0];
            label2.Text += " "+ ime;
            conn = f1.conn2;
            conn2 = f1.conn3;

            chart1.Series.Add(seriija);
            //koliko ocena u jednom redu
            kalkulacija();
            //ucitavanje iz baze
            Ispis();
            //grafs ide ispos ispisa da se sve ocene prov prebroje
            
            //Prosek ucenika
            Prosek();

            chart();

            //odredjivanje pola za sliku
            if (pol)
                odredi_pol = "musko.jpg";
            else
                odredi_pol = "zensko.jpg";
            pictureBox1.Image = new Bitmap(Image.FromFile(odredi_pol), new Size(a, b));
            //postavljanje dugmica i dodavanje eventa
            foreach (var item in la)
            {
                this.Controls.Add(item);
            }
            foreach (var item in bu)
            {
                this.Controls.Add(item);
                item.Click += new EventHandler(klik);
            }
        }
        private void klik(object sender, EventArgs e)
        {
            int index_ocene = int.Parse(((Button)sender).Name);
            //opis ocene 
            MessageBox.Show(oo[index_ocene].Item2);
            //MessageBox.Show(index_ocene.ToString());
            //Form7 f7 = new Form7();
        }
        public void kalkulacija()
        {
            m = (this.Width- chart1.Location.X- border - border) / (strana + rw);
            y = pictureBox1.Location.Y + pictureBox1.Height + border;

        }
        public void prosek(int n,int k)
        {
            if (n == 0)
                return;
            pred[n - 1].racunaj();
            //MessageBox.Show(pred[n - 1].prosek.ToString("0.00"));
            Label label = new Label() {
                Name = $"Prosek: {n}",
                Text = "Prosek:"+pred[n-1].prosek.ToString("0.00"),
                TextAlign = ContentAlignment.MiddleCenter,
                Location = new Point((this.Width - chart1.Location.X - border - border)/2, bu[k-1].Location.Y+50)
            };
            this.Controls.Add(label);
        }
        public void Ispis()
        {
            conn.Open();
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            SQLiteDataReader sqlite_datareader2;
            SQLiteCommand sqlite_cmd2;

            sqlite_cmd = conn.CreateCommand();
            sqlite_cmd.CommandText = $"SELECT * FROM Ocena where ID_ucenika = {index} order by id_predmeta";
            sqlite_datareader = sqlite_cmd.ExecuteReader();

            int n = 0;
            int id=0;
            int k = 0;
            int id_ocene = 0;
            while (sqlite_datareader.Read())
            {
                int id_predmeta = sqlite_datareader.GetInt16(1);
                int ocena = sqlite_datareader.GetInt16(3);
                string opis = sqlite_datareader.GetString(5);
                string predmet = "";
                //MessageBox.Show(id_predmeta.ToString());
                oo.Add(Tuple.Create(ocena, opis));

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


                if (id!=id_predmeta)
                {
                    
                    if (n != 0)
                    {
                        prosek(n, id_ocene);
                    }
                    int qw = 50;
                    y += strana + qw;
                    sqlite_cmd2 = conn.CreateCommand();
                    sqlite_cmd2.CommandText = $"SELECT predmet FROM predmet where id_predmeta = {id_predmeta}";
                    sqlite_datareader2 = sqlite_cmd2.ExecuteReader();
                    while(sqlite_datareader2.Read())
                        predmet=sqlite_datareader2.GetString(0);
                    pred.Add(new Predmet(predmet));
                    
                    la.Add(new Label {
                        Name = n.ToString(),
                        Location = new Point(border, y),
                        Text = predmet
                    });
                    x = la[n].Width+border + rw; 
                    n++;
                    k = 0;
                }
                id = id_predmeta;
                pred[n-1].ocena_opis.Add(Tuple.Create(ocena,opis));
                
                bu.Add(new Button {
                    Name = id_ocene.ToString(),
                    Size = new Size(strana, strana),
                    Location = new Point(x, y),
                    Text = ocena.ToString(),
                    Font = new Font(this.Font,FontStyle.Bold)
                });
                x += strana + rw;
                k++;
                id_ocene++;
                if (k % m == 0)
                {
                    y += strana + rw;
                    x = la[n-1].Width + border + rw;
                }

            }
            prosek(n, id_ocene);
            conn.Close();
            //MessageBox.Show(pred[1].ocena_opis.Count.ToString());
            //MessageBox.Show(bu.Count.ToString());
        }
        public void chart()
        {
            if (petice != 0)
                chart1.Series[seriija].Points.AddXY("5", petice);
            if (cetvorke != 0)
                chart1.Series[seriija].Points.AddXY("4", cetvorke);
            if (trojke != 0)
                chart1.Series[seriija].Points.AddXY("3", trojke);
            if (dvojke != 0)
                chart1.Series[seriija].Points.AddXY("2", dvojke);
            if (jedinice != 0)
                chart1.Series[seriija].Points.AddXY("1", jedinice);
        }
        public void Prosek()
        {
            //prosek
            //double d = (5 * petice + 4 * cetvorke + 3 * trojke + 2 * dvojke + jedinice) / n;
        }
    }
}
