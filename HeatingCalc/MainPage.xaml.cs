using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HeatingCalc
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        double Q, G, t1, t2;
        bool flag;

        private void txtQ_TextChanged(object sender, TextChangedEventArgs e)
        {
            flag = true;
            ReCalc();
        }

        private void txtG_TextChanged(object sender, TextChangedEventArgs e)
        {
            flag = false;
            ReCalc();
        }

        private void txtT1_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReCalc();
        }

        public MainPage()
        {
            this.InitializeComponent();
            txtT1.Text = "20";
            txtT2.Text = "-23";
        }

        private void txtT2_TextChanged(object sender, TextChangedEventArgs e)
        {
            ReCalc();
        }
        private void ReCalc()
        {
            Q = ParseStr(txtQ.Text);
            G = ParseStr(txtG.Text); 
            t1 = ParseStr(txtT1.Text); 
            t2 = ParseStr(txtT2.Text);
            try
            {
                if (flag)
                {
                    
                    G = 0.86 * Q / (t1 - t2);
                    txtG.Text = Math.Round(G, 2).ToString();
                }
                else
                {
                    Q = G * (t1 - t2) / 0.86;
                    txtQ.Text = Q.ToString();
                }
            }
            catch
            {
                return;
            }

        }

        private double ParseStr(string Txt)
        {
            try
            {
                return double.Parse(Txt);
            }
            catch
            {
                return 0;
            }
            

        }
    }
}
