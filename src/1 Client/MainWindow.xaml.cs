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

namespace FocusControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public FocusTimer FocusTimer;

        public MainWindow()
        {
            InitializeComponent();

            FillStats();

            var ucFocusInProgress = new ucHeader_focus_in_progress();
            var ucFocusInterrupted = new ucHeader_focus_interrupted();
            var ucFocusCompleted = new ucHeader_focus_time_completed();

            ucStartFocus.FocusStarted += (sender, args) => SetControl(ucFocusInProgress);
            ucFocusInProgress.Interrupted += (sender, args) => SetControl(ucFocusInterrupted);
            ucFocusInterrupted.InterruptConfirmed += (sender, args) => SetControl(ucStartFocus);
            ucFocusInterrupted.InterruptCancelled += (sender, args) => SetControl(ucFocusInProgress);
            ucFocusCompleted.CompleteConfirmed += (sender, args) => SetControl(ucStartFocus);
            ucFocusCompleted.InterrupedByMyself += (sender, args) => SetControl(ucStartFocus);
            ucFocusCompleted.InterruptedByWorld += (sender, args) => SetControl(ucStartFocus);

            App.FocusTimer.Finished += (sender, args) => SetControl(ucFocusCompleted);
        }

        private void SetControl(UIElement uiElement)
        {
            Dispatcher.Invoke(() =>
            {
                if (uiElement is ucHeader_start_focus)
                    lblHeader.Content = "Keep calm and start focus!";
                else
                    lblHeader.Content = "Keep calm and maintain focus!";

                if (uiElement is ucHeader_focus_time_completed)
                    ((ucHeader_focus_time_completed) uiElement).GainAttention(this);

                ((IHeaderUc)uiElement).Activated();

                const int controlRow = 1;
                const int controlColumn = 0;

                var control = grid.Children
                  .Cast<UIElement>()
                  .First(e =>
                      Grid.GetRow(e) == controlRow &&
                      Grid.GetColumn(e) == controlColumn &&
                      e is UserControl);

                Grid.SetRow(uiElement, controlRow);

                grid.Children.Remove(control);
                grid.Children.Add(uiElement);

                FillStats();
            });
        }

        private void FillStats()
        {
            var stats = GetStatistics.Run();

            if (stats.Today.FocusMinutes < 0)
            {
                lblFocusToday.Content = stats.Today.FocusMinutes;
                lblFocusToday.Foreground = new SolidColorBrush(Colors.Crimson);
            }
            else
            {
                lblFocusToday.Content = "+" + stats.Today.FocusMinutes;
                lblFocusToday.Foreground = new SolidColorBrush(Colors.Green);
            }

            if (stats.Today.FocusMinutes < 0)
            {
                lblFocusEver.Content = stats.Ever.FocusMinutes;
                lblFocusEver.Foreground = new SolidColorBrush(Colors.Crimson);
            }
            else
            {
                lblFocusEver.Content = "+" + stats.Ever.FocusMinutes;
                lblFocusEver.Foreground = new SolidColorBrush(Colors.Green);
            }

            lblTotalMinToday.Content = Math.Abs(stats.Today.TotalMinutes);
            lblInterruptsToday.Content = stats.Today.InterruptionCount + "x (" +  stats.Today.InterruptionMinutes + "min)";
            tbSessionToday.Text = stats.Today.SessionCount + " (click)";

            lblTotalMinEver.Content = Math.Abs(stats.Today.TotalMinutes);
            tbSessionEver.Text = stats.Ever.SessionCount + " (click)";
        }
    }
}
