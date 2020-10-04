using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms.DataVisualization.Charting;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SiAOD_prak_2_3sem
{
    public partial class Form1 : Form
    {
        public void SplineChartExample()
        {
            this.chart1.Series.Clear();

            this.chart1.Titles.Add("Norwegian krone");

            Series series = this.chart1.Series.Add("Exchange rate per 10");
            series.ChartType = SeriesChartType.Spline;
            double cnt1 = 0;
            double cnt2 = 0;
            Series series1 = this.chart1.Series.Add("SMA10");
            series1.ChartType = SeriesChartType.Spline;
            Series series2 = this.chart1.Series.Add("SMA100");
            series2.ChartType = SeriesChartType.Spline;
            for (int i = 0; i < Class1.num; i++)
            {
                cnt1 = 0;
                cnt2 = 0;
                if (i > 8)
                 {
                    cnt1 += Class1.transi[i - 1];
                    cnt1 += Class1.transi[i - 2];
                    cnt1 += Class1.transi[i - 3];
                    cnt1 += Class1.transi[i - 4];
                    cnt1 += Class1.transi[i - 5];
                    cnt1 += Class1.transi[i - 6];
                    cnt1 += Class1.transi[i - 7];
                    cnt1 += Class1.transi[i - 8];
                    cnt1 += Class1.transi[i - 9];
                }
                if (i > 98)
                {
                    for (int j = i - 1; j > i - 99; j--)
                    {
                        cnt2 += Class1.transi[j];
                    }
                }
                series.Points.AddXY(Class1.transs[i], Class1.transi[i]);
                series1.Points.AddXY(Class1.transs[i], cnt1 / 10);
                series2.Points.AddXY(Class1.transs[i], cnt2 / 100);
            }
        }

        public Form1()
        {
            InitializeComponent();
            SplineChartExample();
        }


    }
}
