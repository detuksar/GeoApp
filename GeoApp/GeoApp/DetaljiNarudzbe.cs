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
    public partial class DetaljiNarudzbe : Form
    {
        decimal suma;
        public DetaljiNarudzbe(int idNarudzbe)
        {
            InitializeComponent();
            using (var db = new Entities1())
            {
                var query = (from a in db.Artikl
                             join n in db.Stavke_narudzbe on a.ID_artikla equals n.ArtiklID_artikla
                             where n.NarudzbaID_narudzbe == idNarudzbe
                             select new
                             {
                                 a.ID_artikla,
                                 a.Naziv,
                                 a.Opis,
                                 a.Proizvodac,
                                 a.Serijski_broj,
                                 a.Cijena,
                                 n.Kolicina
                             }).ToList();
                uiPrikazDetalja.DataSource = query;
                uiPrikazDetalja.Columns[0].HeaderText = "ID artikla";
                uiPrikazDetalja.Columns[3].HeaderText = "Proizvođač";
                uiPrikazDetalja.Columns[4].HeaderText = "Serijski broj";
                uiPrikazDetalja.Columns[6].HeaderText = "Količina";

                suma = Convert.ToDecimal((from a in db.Stavke_narudzbe
                                          where a.NarudzbaID_narudzbe == idNarudzbe
                                          select a).Sum(b => b.Kolicina * b.Artikl.Cijena));
                lblCijena.Text = suma.ToString();
                lblCijena.Text += " HRK";
            }
        }

        private void DetaljiNarudzbe_Load(object sender, EventArgs e)
        {
            helpDetaljiNarudzbe.HelpNamespace = Environment.CurrentDirectory + "/help/detaljiNarudzbe.html";

            this.MaximizeBox = false;
        }
    }
}
