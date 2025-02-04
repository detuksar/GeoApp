﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GeoApp
{
    public partial class Pocetna : Form
    {
        public Pocetna()
        {
            InitializeComponent();
            uiPrikazKorisnickogImena.Text = LoginInfo.Korime;
            uiPrikazUloge.Text = LoginInfo.Uloga;
        }

        private void unosUredaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            UnosArtikla unos = new UnosArtikla();
            unos.ShowDialog();
            this.Close();
        }

        private void azuriranjeUredaja_Click(object sender, EventArgs e)
        {
            this.Hide();
            AzuriranjeArtikla azuriranje = new AzuriranjeArtikla();
            azuriranje.ShowDialog();
            this.Close();
        }

        private void Pocetna_Load(object sender, EventArgs e)
        {

            helpPocetna.HelpNamespace = Environment.CurrentDirectory + "/help/pocetna.html";


            this.MaximizeBox = false;
            if (LoginInfo.Uloga == "Kupac")
            {
             
                uiUnesiArtikl.Visible = false;
                uiAzurirajUredaj.Visible = false;
                uiUrediUloge.Visible = false;
                btnServis.Location = new Point(13, 146);
                this.Size = new Size(384, 250);
            }
            else if (LoginInfo.Uloga == "Zaposlenik" )
            {

                btnServis.Location = new Point(13, 324);
                uiUrediUloge.Visible = false;
              
                this.Size = new Size(384,420);
            }
            
          
       
        }

        private void Pocetna_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void btnOdjava_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginInfo.IDKorisnika = 0;
            LoginInfo.Uloga = "";
            LoginInfo.Korime = "";


            Prijava prijava = new Prijava();
            prijava.ShowDialog();
            this.Close();
        }

        private void btnNarucivanje_Click(object sender, EventArgs e)
        {
            this.Hide();
            Narucivanje narucivanje = new Narucivanje();
            narucivanje.ShowDialog();
            this.Close();
        }

        private void btnOdobravanje_Click(object sender, EventArgs e)
        {
            this.Hide();
            OdobravanjeNarudzbe odobravanje = new OdobravanjeNarudzbe();
            odobravanje.ShowDialog();
            this.Close();
        }

        private void btnOvlasti_Click(object sender, EventArgs e)
        {
            this.Hide();
            OvlastiZaposlenika ovlastiZaposlenika = new OvlastiZaposlenika();
            ovlastiZaposlenika.ShowDialog();
            this.Close();
        }
    }
}
