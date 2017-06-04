﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ePress
{
    /// <summary>
    /// Interaction logic for Dzial.xaml
    /// </summary>
    public partial class Dzial : Window
    {
        MainWindow page;
        List<Autor> listaAutorow;

        public Dzial(MainWindow start)
        {
            page = start;
            InitializeComponent();
            listaAutorow = new List<Autor>();
        }

        public void UstawDataContext(Autor a)
        {
            DoWyswietlenia.DlaAutorow d = new DoWyswietlenia.DlaAutorow();
            d.imie = a.Imie;
            d.nazwisko = a.Nazwisko;
            d.sprzedaz = a.sprzedaz;
            d.copisze = a.coPisze;
            d.wynagrodzenie = a.PokazUmowe().stawka.ToString();
            d.zysk = a.konto;
            if (a.PokazUmowe().GetType() == typeof(OPrace)) d.umowa = "O Prace";
            if (a.PokazUmowe().GetType() == typeof(ODzielo))
            {
                d.umowa = "O Dzieło";
                d.wynagrodzenie += "%";
            }

            Autors.Items.Add(d);
            Autors.Items.Refresh();
        }

        public void DodajAutora(Autor a)
        {
            listaAutorow.Add(a);
            UstawDataContext(a);
        }

        public List<Autor> GetAutorzy()
        {
            return listaAutorow;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            Umowy u = new Umowy(1, this);
            u.ShowDialog();
        }

        private void Usun_Click(object sender, RoutedEventArgs e)
        {
            Umowy u = new Umowy(2, this);
            u.ShowDialog();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Umowy u = new Umowy(3, this);
            u.ShowDialog();
        }

        private void Del_Click(object sender, RoutedEventArgs e)
        {
            Umowy u = new Umowy(4, this);
            u.ShowDialog();
        }
    }
}
