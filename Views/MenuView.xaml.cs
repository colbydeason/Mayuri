
using Mayuri.Models;
using Microsoft.Extensions.DependencyInjection;
using ScottPlot;
using ScottPlot.Plottable;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

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

        void RefreshScreen(object sender, RoutedEventArgs e)
        {
            InitializeComponent();
            ILogList lgList = App.Current.Services.GetService<ILogList>();
            Plot plt = WeeklyLogs.Plot;
            ScottPlot.Control.Configuration cf = WeeklyLogs.Configuration;

            PlotLogList(lgList, plt, cf, out string tTD, out string tTGP, out string tAGP, out string tT, "week");
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
            MainGraphBasicSetup(conf, plot);

            IEnumerable<Log> logEnum = l.GetAllLogs().Result;
            IEnumerator<Log> logs = logEnum.GetEnumerator();
            DateTime oldestDate;
            DateTime currentBarDate;
            DateTime nowDate = DateTime.Today;
            BarSeries barSeries = plot.AddBarSeries();

            if (logEnum == null || !logEnum.Any())
            {
                totalTimeDay = "Create a Source";
                totalTimeGivenPeriod = "Use Stopwatch to Track Time";
                timeAverageGivenPeriod = "Log Immersion Hours";
                totalTime = "Profit";
                oldestDate = nowDate.AddDays(-6);
                plot.SetAxisLimitsX(oldestDate.AddDays(-.5).ToOADate(), nowDate.AddDays(.5).ToOADate());
                plot.SetAxisLimitsY(0, 10);
                return;
            }

            int ttd = 0;
            int ttgp = 0;
            int tagp;
            int tt = 0;

            if (logPeriod == "all")
            {
                plot.AxisAuto();
                logs.MoveNext();
                tagp = (nowDate - logs.Current.LoggedAt.Date).Days;
                oldestDate = logs.Current.LoggedAt.Date;
            }
            else if (logPeriod == "day")
            {
                tagp = 1;
                oldestDate = nowDate;
                plot.SetAxisLimitsX(nowDate.AddDays(-.5).ToOADate(), nowDate.AddDays(.5).ToOADate());
                logs.MoveNext();
            }
            else if (logPeriod == "week")
            {
                tagp = 7;
                oldestDate = nowDate.AddDays(-6);
                plot.SetAxisLimitsX(oldestDate.AddDays(-.5).ToOADate(), nowDate.AddDays(.5).ToOADate());
                logs.MoveNext();
            }
            else if (logPeriod == "month")
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
            CreateBars(currentBarDate, logs, ref tt, ref ttgp, ref ttd, barSeries, plot);

            totalTime = "Total: \n" + ToTimeFormat(tt);
            totalTimeGivenPeriod = ($"Total for {logPeriod}: \n") + ToTimeFormat(ttgp);
            totalTimeDay = "Today: \n" + ToTimeFormat(ttd);
            tagp = ttgp / tagp;
            timeAverageGivenPeriod = $"Daily average for {logPeriod}: \n" + ToTimeFormat(tagp);
        }

        private static string ToTimeFormat(int time)
        {
            int days;
            int hours;
            int minutes;
            days = Math.DivRem(time, 1440, out hours);
            hours = Math.DivRem(hours, 60, out minutes);
            if (days == 0 && hours == 0 && minutes == 0)
            {
                return "None, Go Immerse!!!";
            }
            else if (days == 0 && hours == 0)
            {
                return $"{minutes}m";
            }
            else if (days == 0)
            {
                return $"{hours}h, {minutes}m";
            }
            else
            {
                return $"{days}d, {hours}h, {minutes}m";
            }
        }

        private static void MainGraphBasicSetup(ScottPlot.Control.Configuration c, ScottPlot.Plot p)
        {
            c.Pan = false;
            c.Zoom = false;
            c.ScrollWheelZoom = false;
            c.MiddleClickDragZoom = false;

            p.XAxis.DateTimeFormat(true);
            p.YAxis2.SetSizeLimit(min: 0);
            p.XAxis.Layout(padding: 0, maximumSize: 22);
            p.XAxis.Label("");
            p.YAxis.Label("Minutes");

            p.Style(figureBackground: Color.FromArgb(127, 0, 0, 0), grid: Color.FromArgb(127, 0, 0, 0), axisLabel: Color.White, tick: Color.White);
            p.Style();

            return;
        }
    }
}
