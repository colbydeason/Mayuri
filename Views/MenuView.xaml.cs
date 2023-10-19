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
        public MenuView()
        {
            InitializeComponent();
            ILogList lgList = App.Current.Services.GetService<ILogList>();
            Plot plt = WeeklyLogs.Plot;
            ScottPlot.Control.Configuration cf = WeeklyLogs.Configuration;
            string tTD;
            string tTGP;
            string tAGP;
            string tT;
            PlotLogList(lgList, plt, cf, out tTD, out tTGP, out tAGP, out tT, "week");
            TotalTimeDay.Text = tTD;
            TotalTimeGivenPeriod.Text = tTGP;
            TimeAverageGivenPeriod.Text = tAGP;
            TotalTime.Text = tT;

            WeeklyLogs.Refresh();
        }

        // Input: ILogList l, Plot plot, Configuration conf, string logPeriod (all, day, week, month)
        // Output: void
        //         Adds bars to plot
        // Assumption: In order datetime from most to least
        // 
        // Process: load first values (time, genre) into the first two arrays, set current day
        //          for every next value:
        //          if the date is the same as the one in the list, put the values in and go next
        //          if not, add bar using the current arrays, then create a new array with the new
        //
        // Info format for stats:
        //          Hours for: Source, SourceType, Per Day,

        private static void PlotLogList(ILogList l, ScottPlot.Plot plot, ScottPlot.Control.Configuration conf, 
            out string totalTimeDay, out string totalTimeGivenPeriod, out string timeAverageGivenPeriod, out string totalTime, string logPeriod = "all")
        {
            Dictionary<string, Color> SourceColor = new Dictionary<string, Color>
            {
                { "Book", Color.FromArgb(255, 105, 97) },
                { "Anime", Color.FromArgb(255, 180, 128)},
                { "Manga", Color.FromArgb(248, 243, 141)},
                { "Visual Novel", Color.FromArgb(66, 214, 164) },
                { "Video Game", Color.FromArgb(8, 202, 209)},
                { "Reading", Color.FromArgb(89, 173, 246) },
                { "Listening", Color.FromArgb(157, 148, 255)},
                { "Other", Color.FromArgb(199, 128, 232)},
            };
            IEnumerable<Log> logEnum = l.GetAllLogs().Result;
            IEnumerator<Log> logs = logEnum.GetEnumerator();
            if (logEnum == null || !logEnum.Any())
            {
                totalTimeDay = "Go Immerse!!!!";
                totalTimeGivenPeriod = "";
                timeAverageGivenPeriod = "";
                totalTime = "";
                return;
            }

            conf.Pan = false;
            conf.Zoom = false;
            conf.ScrollWheelZoom = false;
            conf.MiddleClickDragZoom = false;

            plot.XAxis.DateTimeFormat(true);
            plot.YAxis2.SetSizeLimit(min: 0);
            plot.XAxis.Layout(padding: 0, maximumSize: 22);
            //plot.YAxis.Layout(padding: 0, maximumSize: 30);
            plot.XAxis.Label("");
            plot.YAxis.Label("Minutes");
            //plot.Style(Color.Transparent);
            plot.Style(figureBackground: Color.FromArgb(127, 0, 0, 0),grid: Color.FromArgb(127, 0, 0, 0) ,axisLabel: Color.White, tick: Color.White) ;
            plot.Style();

            DateTime oldestDate;
            DateTime currentBarDate;
            DateTime nowDate = DateTime.Today;
            BarSeries barSeries = plot.AddBarSeries();
            double ttd = 0;
            double ttgp = 0;
            double tagp = 0;
            double tt = 0;

            if (logPeriod == "all")
            {
                plot.AxisAuto();
                logs.MoveNext();
                tagp = (nowDate - logs.Current.LoggedAt.Date).Days;
                currentBarDate = logs.Current.LoggedAt.Date;

            } else if (logPeriod == "day")
            {
                tagp = 1;
                plot.SetAxisLimitsX(nowDate.AddDays(-.5).ToOADate(), nowDate.AddDays(.5).ToOADate());
                logs.MoveNext();
                currentBarDate = logs.Current.LoggedAt.Date;
                while (currentBarDate < nowDate)
                {
                    logs.MoveNext();
                    tt += logs.Current.Duration;
                    currentBarDate = logs.Current.LoggedAt.Date;
                }
            } else if(logPeriod == "week")
            {
                tagp = 7;
                oldestDate = nowDate.AddDays(-6);
                plot.SetAxisLimitsX(oldestDate.AddDays(-.5).ToOADate(), nowDate.AddDays(.5).ToOADate());
                logs.MoveNext();
                currentBarDate = logs.Current.LoggedAt.Date;
                while (currentBarDate < oldestDate)
                {
                    logs.MoveNext();
                    tt += logs.Current.Duration;
                    currentBarDate = logs.Current.LoggedAt.Date;
                }

            } else if(logPeriod == "month")
            {
                tagp = 30;
                oldestDate = nowDate.AddDays(-29);
                plot.SetAxisLimitsX(oldestDate.AddDays(-.5).ToOADate(), nowDate.AddDays(.5).ToOADate());
                logs.MoveNext();
                currentBarDate = logs.Current.LoggedAt.Date;
                while (currentBarDate < oldestDate)
                {
                    logs.MoveNext();
                    tt += logs.Current.Duration;
                    currentBarDate = logs.Current.LoggedAt.Date;
                }
            }
            else
            {
                throw new Exception("Invalid string for logPeriod");
            }
            double lastBarTop = 0;
            double tallestBar = 10;
            do
            {
                Log curLog = logs.Current;
                if (currentBarDate.Year != curLog.LoggedAt.Year ||
                    currentBarDate.Month != curLog.LoggedAt.Month ||
                    currentBarDate.Day != curLog.LoggedAt.Day)
                {
                    lastBarTop = 0;
                    currentBarDate = curLog.LoggedAt.Date;
                } 
                double barTop = lastBarTop + curLog.Duration;
                double barBottom = lastBarTop;
                lastBarTop += curLog.Duration;

                tt += curLog.Duration;
                ttgp += curLog.Duration;
                if (curLog.LoggedAt.Date == nowDate)
                {
                    ttd += curLog.Duration;
                }

                if (barTop > tallestBar)
                {
                    tallestBar = barTop;
                }

                barSeries.Bars.Add(new Bar()
                {
                    Value = barTop,
                    ValueBase = barBottom,
                    FillColor = SourceColor[$"{curLog.LogSource.Type}"],
                    LineColor = Color.Black,
                    LineWidth = 1,
                    Position = currentBarDate.ToOADate(),


                });
            } while(logs.MoveNext());
            plot.SetAxisLimitsY(0, tallestBar + 10);

            totalTime = "Total: " + tt.ToString();
            totalTimeGivenPeriod = ($"Total time for {logPeriod}: ") + ttgp.ToString();
            totalTimeDay = "Today: " + ttd.ToString();
            tagp = ttgp / tagp;
            timeAverageGivenPeriod = $"Average Time for {logPeriod}: " + tagp.ToString("0.00");
        }
    }
}
