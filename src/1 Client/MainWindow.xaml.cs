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
        public MainWindow()
        {
            InitializeComponent();

            var ucFocusInProgress = new ucHeader_focus_in_progress();
            var ucFocusInterrupted = new ucHeader_focus_interrupted();
            var ucFocusCompleted = new ucHeader_focus_time_completed();

            ucStartFocus.FocusStarted += (sender, args) => SetControl(ucFocusInProgress);
            ucFocusInProgress.Interrupted += args => SetControl(ucFocusInterrupted);
            ucFocusInterrupted.InterruptConfirmed += (sender, args) => SetControl(ucStartFocus);
            ucFocusInterrupted.InterruptCancelled += (sender, args) => SetControl(ucFocusInProgress);
            ucFocusCompleted.CompleteConfirmed += (sender, args) => SetControl(ucStartFocus);
            ucFocusCompleted.InterrupedByMyself += (sender, args) => SetControl(ucStartFocus);
            ucFocusCompleted.InterruptedByWorld += (sender, args) => SetControl(ucStartFocus);
        }

        private void SetControl(UIElement uiElement)
        {
            if (uiElement is ucHeader_start_focus)
                lblHeader.Content = "Keep calm and start focus!";
            else
                lblHeader.Content = "Keep calm and maintain focus!";

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
        }
    }
}
