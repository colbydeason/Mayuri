using Mayuri.Models;
using Microsoft.Extensions.DependencyInjection;
using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
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
        public List<KeyValuePair<string, System.Drawing.Color>> colorPallate = new()
        {
            new KeyValuePair<string, System.Drawing.Color>("Book", Color.Red),
            new KeyValuePair<string, System.Drawing.Color>("Anime", Color.Blue),
            new KeyValuePair<string, System.Drawing.Color>("Manga", Color.Orange),
            new KeyValuePair<string, System.Drawing.Color>("Visual Novel", Color.Yellow),
            new KeyValuePair<string, System.Drawing.Color>("Video Game", Color.Green),
            new KeyValuePair<string, System.Drawing.Color>("Reading", Color.Purple),
            new KeyValuePair<string, System.Drawing.Color>("Listening", Color.Brown),
            new KeyValuePair<string, System.Drawing.Color>("Other", Color.Gray),

        };
        public MenuView()
        {
            InitializeComponent();
            ILogList lgList = App.Current.Services.GetService<ILogList>();
            Plot plt = WeeklyLogs.Plot;
            ScottPlot.Control.Configuration cf = WeeklyLogs.Configuration;

            PlotLogList(lgList, plt, cf, 7); 


            WeeklyLogs.Refresh();
        }

        // Input: ILogList l, int dayPeriod
        // Output: two arrays containing the x and y axis for the given day period to be 
        //         set on a bar graph
        // Assumption: The logs are in order by datetime from most to least recent
        //
        // Process: For every log, check to see if the date is the same as the last one in the date list
        //          If it is, add the time to the last value in the other list, if not, add it to the end of the list along with the new datetime.
        // 
        // OR
        //
        // Input: ILogList l, Plot plot, Configuration conf, int dayPeriod
        // Output: void
        //         Adds bars to plot
        // Assumption: In order datetime from most to least
        // 
        // Process: load first values (time, genre) into the first two arrays, set current day
        //          for every next value:
        //          if the date is the same as the one in the list, put the values in and go next
        //          if not, add bar using the current arrays, then create a new array with the new


        private void PlotLogList(ILogList l, ScottPlot.Plot plot, ScottPlot.Control.Configuration conf, int dayPeriod)
        {
            IEnumerable<Log> logEnum = l.GetAllLogs().Result;
            IEnumerator<Log> logs = logEnum.GetEnumerator();
            DateTime nowDate = DateTime.Today;
            DateTime oldestDate = nowDate.AddDays(dayPeriod * -1);
            double tallestBar = 5;

            plot.SetAxisLimitsX(oldestDate.AddDays(-1).ToOADate(), nowDate.AddDays(1).ToOADate());
            plot.XAxis.DateTimeFormat(true);
            plot.YAxis2.SetSizeLimit(min: 0);
            conf.Pan = false;
            conf.Zoom = false;
            conf.ScrollWheelZoom = false;
            conf.MiddleClickDragZoom = false;
            plot.XAxis.Layout(padding: 0, maximumSize: 20);
            plot.YAxis.Layout(padding: 0, maximumSize: 20);
            plot.XAxis.Label("");
            plot.YAxis.Label("");

            if (logEnum == null || !logEnum.Any())
            {
                return;
            }

            BarSeries barSeries = plot.AddBarSeries();
            List<double> currentBarHours = new();
            List<string> currentBarLabels = new();
            double lastBarTop = 0;
            logs.MoveNext();
            DateTime currentBarDate = logs.Current.LoggedAt.Date;
            while (currentBarDate <= oldestDate)
            {
                logs.MoveNext();
                currentBarDate = logs.Current.LoggedAt.Date;
            }
            do
            {
                Log curLog = logs.Current;
                if (currentBarDate.Year != curLog.LoggedAt.Year ||
                    currentBarDate.Month != curLog.LoggedAt.Month ||
                    currentBarDate.Day != curLog.LoggedAt.Day)
                {
                    lastBarTop = 0;
                    currentBarDate = curLog.LoggedAt;
                } 
                double barTop = lastBarTop + curLog.Duration;
                double barBottom = lastBarTop;
                lastBarTop += curLog.Duration;
                if (barTop > tallestBar)
                {
                    tallestBar = barTop;
                }

                barSeries.Bars.Add(new Bar()
                {
                    Value = barTop,
                    ValueBase = barBottom,
                    // FillColor = (insert source type color here)
                    FillColor = Color.Blue,
                    LineColor = Color.Black,
                    Position = currentBarDate.ToOADate(),
                    
                });
            } while(logs.MoveNext());
            plot.SetAxisLimitsY(0, tallestBar);
        }
    }
}
