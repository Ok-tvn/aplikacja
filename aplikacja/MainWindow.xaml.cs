using System;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace aplikacja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int N = 20;
        int[] d = new int[N];
        int i, j, x;

        public MainWindow()
        {
            InitializeComponent();
        }
        void Sortuj_szybko(int lewy, int prawy)
        {
            int i, j, piwot;

            i = (lewy + prawy) / 2;
            piwot = d[i]; d[i] = d[prawy];
            for (j = i = lewy; i < prawy; i++)
                if (d[i] < piwot)
                {
                    d[i] = d[i] + d[j];
                    d[j] = d[i] - d[j];
                    d[i] = d[i] - d[j];
                    j++;
                }
            d[prawy] = d[j]; d[j] = piwot;
            if (lewy < j - 1) Sortuj_szybko(lewy, j - 1);
            if (j + 1 < prawy) Sortuj_szybko(j + 1, prawy);
        }
        private void radiobox_1_Checked(object sender, RoutedEventArgs e)
        {
            var rand = new Random();

            for (int g = 0; g < 20; g++)
            {
                d[g] = rand.Next(0, 30);
            }
            /*for (int m = 0; m < 20; m++)
            {
                this.wynik.Text += d[m].ToString() + " ";
            }*/

        }

        private void radiobox_2_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void radiobox_3_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void btn_szybkie_Click(object sender, RoutedEventArgs e)
        {
            Sortuj_szybko(0, N - 1);
            this.wynik.Clear();
            for (i = 0; i < N; i++)  this.wynik.Text= wynik.Text.PadRight(4)+" "+d[i];
        }

        private void dwa_Click(object sender, RoutedEventArgs e)
        {/*
            const int N = 20;
            int pmin = 0;
            int pmax = N - 1;
            int k, p;
            do
            {
                p = -1;
                for (k = pmin; k < pmax; k++)
                    if (d[k] > d[k + 1])
                    {
                        Swap<int>()    swap(d[k], d[k + 1]);
                        if (p < 0) pmin = k;
                        p = k;
                    }
                if (pmin) pmin--;
                pmax = p;
            } while{ (p >= 0); }

            // Wyświetlamy wynik sortowania

            for (k = 0; k < N; k++) cout << setw(4) << d[k];
         */  
        }

        private void jeden_Click(object sender, RoutedEventArgs e)
        {
            for (j = N - 2; j >= 0; j--)
            {   
                x = d[j];
                i = j + 1;
                while ((i < N) && (x > d[i]))
                {
                    d[i - 1] = d[i];
                    i++;
                }
                d[i - 1] = x;
            }
            this.wynik.Clear();
            for (int m = 0; m < 20; m++)
            {
               this.wynik.Text += d[m].ToString() + " ";
            }
        }

        private void wynik_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
