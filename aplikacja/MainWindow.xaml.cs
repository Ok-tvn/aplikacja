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
using System.Windows.Threading;

namespace aplikacja
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        const int N = 20;
        int[] table = new int[N+1];
        int[] table_merge = new int[N];
        int[] d = new int[N];
        int  u,i,x,j;
        int pmin = 0;
        int pmax = N - 1;
        int k, p;
        DispatcherTimer dt = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            dt.Interval = TimeSpan.FromMilliseconds(1);
            dt.Tick += Dt_Tick;
        }
        private int increment = 0;
        private void Dt_Tick(object sender, EventArgs e)
        {
            increment++;
            czas_inp.Text = increment.ToString();
        }
        void Sortuj_szybko(int lewy, int prawy)
        {
            dt.Start();
            int f,q,h=0, piwot;

            f = (lewy + prawy) / 2;
            piwot = d[f]; d[f] = d[prawy];
            for (q = f = lewy; f < prawy; f++)
            {
                if (d[f] < piwot)
                {
                    h = d[f];
                    d[f] = d[q];
                    d[q] = h;
                    q++;
                }
            }
            
            d[prawy] = d[q]; d[q] = piwot;
            if (lewy < q - 1) Sortuj_szybko(lewy, q - 1);
            if (q + 1 < prawy) Sortuj_szybko(q + 1, prawy);
        }
        void MergeSort(int i_p, int i_k)
        {
            dt.Start();
            int i_s, i1, i2, i_o;

            i_s = (i_p + i_k + 1) / 2;
            if (i_s - i_p > 1)
            {
                MergeSort(i_p, i_s - 1);
            }
            if (i_k - i_s > 0)
            {
                MergeSort(i_s, i_k);
            }
            i1 = i_p; i2 = i_s;
            for (i_o = i_p; i_o <= i_k; i_o++)
            {
                table_merge[i_o] = ((i1 == i_s) || ((i2 <= i_k) && (d[i1] > d[i2]))) ? d[i2++] : d[i1++];
            }
            for (i_o = i_p; i_o <= i_k; i_o++)
            {
                d[i_o] = table_merge[i_o];
            }
        }   
        private void radiobox_1_Checked(object sender, RoutedEventArgs e)
        {
            var rand = new Random();

            for (int g = 0; g < 20; g++)
            {
                d[g] = rand.Next(0, 30);
                table[g] = rand.Next(0, 30);
            }

        }

        private void radiobox_2_Checked(object sender, RoutedEventArgs e)
        {
            var rand = new Random();

            for (int g = 0; g < 20; g++)
            {
                d[g] = rand.Next(0, 30);
                table[g] = rand.Next(0, 30);
            }
        }

        private void radiobox_3_Checked(object sender, RoutedEventArgs e)
        {
            var rand = new Random();

            for (int g = 0; g < 20; g++)
            {
                d[g] = rand.Next(0, 30);
                table[g] = rand.Next(0, 30);
            }
        }

        private void dwa_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
            pmin = 0; pmax = N - 2;
            do
            {
                p = -1;
                for (k = pmin; k <= pmax; k++)
                    if (d[k] > d[k + 1])
                    {
                        d[k] = d[k] + d[k + 1];
                        d[k + 1] = d[k] - d[k + 1];
                        d[k] = d[k] - d[k + 1];
                        p = k;
                    }
                if (p < 0) break;
                pmax = p - 1;
                p = -1;
                for (k = pmax; k >= pmin; k--)
                    if (d[k] > d[k + 1])
                    {
                        d[k] = d[k] + d[k + 1];
                        d[k + 1] = d[k] - d[k + 1];
                        d[k] = d[k] - d[k + 1];
                        p = k;
                    }
                pmin = p + 1;
            } while (p >= 0);



            // Wyświetlamy wynik sortowania
            this.wynik.Clear();
            for (k = 0; k < N; k++) this.wynik.Text = wynik.Text.PadRight(4) + " " + d[k];
            dt.Stop();

        }

        private void jeden_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
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
            dt.Stop();
        }

        private void heapsort_btn_Click(object sender, RoutedEventArgs e)
        {
            dt.Start();
            int a,b,c,v,l,k;
            for (a = 2; a <= N; a++)
            {
                b = a; c = b / 2;
                v = table[a];
                while ((c > 0) && (table[c] < v))
                {
                    table[b] = table[c];
                    b = c; c = b / 2;
                }
                table[b] = v;
            }
            for (a = N; a > 1; a--)
            {
                k = 0;
                k = table[a];
                table[a] = table[1];
                table[1] = k;
                b = 1; c = 2;
                while (c < a)
                {
                    if ((c + 1 < a) && (table[c + 1] > table[c]))
                    {
                        l = c + 1;
                    }
                    else
                    {
                        l = c;
                    }
                    if (table[l] <= table[b])
                    { 
                        break;
                    } 
                    k = 0;
                    k = table[b];
                    table[b] = table[l];
                    table[l] = k;
                    b = l; 
                    c = b + b;
                }
            }
            this.wynik.Clear();
            for (a = 1; a <= N; a++) this.wynik.Text = wynik.Text.PadRight(4) + " " + table[a];
            dt.Stop();
        }

        private void scal_btn_Click(object sender, RoutedEventArgs e)
        {
            MergeSort(0, N - 1);
            this.wynik.Clear();
            for (i = 0; i < N; i++) this.wynik.Text = wynik.Text.PadRight(4) + " " + d[i];
            dt.Stop();
        }

        private void szybkie_Click(object sender, RoutedEventArgs e)
        {
            Sortuj_szybko(0, N - 1);
            this.wynik.Clear();
            for (u = 0; u < N; u++) this.wynik.Text = wynik.Text.PadRight(4) + " " + d[u];
            dt.Stop();
        }

        private void wynik_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
 }

