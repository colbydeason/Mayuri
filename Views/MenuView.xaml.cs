using Mayuri.Models;
using Microsoft.Extensions.DependencyInjection;
using ScottPlot;
using ScottPlot.Plottable;
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

namespace Mayuri.Views
{
    /// <summary>
    /// Interaction logic for MenuView.xaml
    /// </summary>
    public partial class MenuView : UserControl
    {
        public MenuView()
        {
            InitializeComponent();
            ILogList lgList = App.Current.Services.GetService<ILogList>();
            List<double[]> barList = LogPlotList(lgList);
            Plot plt = WeeklyLogs.Plot;
            ScottPlot.Control.Configuration cf = WeeklyLogs.Configuration;
            plt.AxisAuto();
            plt.XAxis.DateTimeFormat(true);
            plt.YAxis2.SetSizeLimit(min: 0);
            cf.Pan = false;
            cf.Zoom = false;
            cf.ScrollWheelZoom = false;
            cf.MiddleClickDragZoom = false;
            plt.XAxis.Layout(padding: 0);
            plt.YAxis.Layout(padding: 0);
            plt.XAxis.Label("Date");
            plt.YAxis.Label("Hours");



            double[] source1 = { 1, 0, 3, 4 , 0, 0, 0};
            double[] source2 = { 2, 2, 0, 0 , 0, 0, 0};
            double[] source12 = new double[source2.Length];
            for (int i = 0; i < source2.Length; i++)
            {
                source12[i] = source2[i] + source1[i];
            }
            double[] positions = { DateTime.Now.ToOADate(), DateTime.Now.AddDays(1).ToOADate(), DateTime.Now.AddDays(2).ToOADate(), DateTime.Now.AddDays(3).ToOADate(),
            DateTime.Now.AddDays(4).ToOADate(), DateTime.Now.AddDays(5).ToOADate(), DateTime.Now.AddDays(6).ToOADate() };



            plt.AddBar(source12, positions);
            plt.AddBar(source1, positions);

            WeeklyLogs.Refresh();
        }
        private List<double[]> LogPlotList(ILogList l)
        {
            IEnumerable<Log> logs = l.GetAllLogs().Result;
            List<double[]> logList = new();
            int logNum = logs.Count();

            foreach(Log log in logs)
            {

            }

            return logList;
        }
    }
}
