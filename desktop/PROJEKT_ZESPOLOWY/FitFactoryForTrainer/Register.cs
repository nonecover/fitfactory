﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FitFactoryForTrainer
{
    public partial class Register : Form
    {
        DataBase db = DataBase.getInstance();
        public Register()
        {
            InitializeComponent();
            wczytajLB();
        }

  

        private void wczytajLB()
        {
            string sql = "select * from SPECJALIZACJE";
            DataTable d = db.ExecuteStoredProcedure(sql);
          //  cbSpecjalizacja.DataSource = d;
          //  cbSpecjalizacja.DisplayMember = "nazwa";
          //  cbSpecjalizacja.ValueMember = "id";
          //  cbSpecjalizacja.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPlec.DropDownStyle = ComboBoxStyle.DropDownList;
            //foreach (DataRow dr in d.Rows)
            //{
            //    cbSpecjalizacja.Items.Add(dr["nazwa"].ToString());
            //}
        }

        private Boolean validate()
        {
            if (tbHaslo1.Text != "" || tbHaslo2.Text != "" || tbImie.Text != ""  || tbLogin.Text != "" || tbMail.Text != "" || tbNazwisko.Text != "" || cbPlec.Text !="")
            {
                if(tbHaslo1.Text == tbHaslo2.Text)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show("Niezgodność haseł.");
                    return false;
                }
            }
            else
            {
                MessageBox.Show("Wszystkie pola muszą zostać wypełnione");
                return false;
            }        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(validate())
            {
                MD5 md = MD5.Create();
                String login ="" + tbLogin.Text + "";
                String imie1 = "" + tbImie.Text + "";
                String imie2 = "" + tbImie2.Text + "";
                String mail = "" + tbMail.Text + "";
                String nazwisko = "" + tbNazwisko.Text + "";
                String haslo = "" + GetMd5Hash(md, tbHaslo1.Text) + "";


                String plec;
                if(cbPlec.Text=="Mężczyzna")
                {
                    plec = "M";
                }
                else
                {
                    plec = "K";
                }

                string rok = dataUr.Value.Year.ToString();
                string miesiac = dataUr.Value.Month.ToString();
                string dzien = dataUr.Value.Day.ToString();
                if (miesiac.Length == 1)
                {
                    miesiac = "0";
                    miesiac += dataUr.Value.Month.ToString();
                }
                if (dzien.Length == 1)
                {
                    dzien = "0";
                    dzien += dataUr.Value.Day.ToString();
                }

                String data_ur = "" + dzien + "/" + miesiac + "/" + rok + "";
                DataTable tokenHanlder = new DataTable();
                tokenHanlder = db.InsertIntoDb(login, mail, imie1, imie2, nazwisko, plec, data_ur, haslo, "T");

                DataRow r = tokenHanlder.Rows[0];

                MessageBox.Show(r["Column1"].ToString());


            }
        }

        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}
