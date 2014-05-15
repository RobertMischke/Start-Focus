using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
    /// Interaction logic for ucHeader_focus_in_progress.xaml
    /// </summary>
    public partial class ucHeader_focus_in_progress : UserControl
    {
        public event Interuppted Interrupted;
        private Timer _timer = new Timer(); 
 
        public ucHeader_focus_in_progress()
        {
            InitializeComponent();

            var focusTimer = App.FocusTimer;

            lblFocusOn.Content = "Focus on: '..........'";
            txtTimeLeft.Content = ".......... thinking ..........";

            _timer.Interval = 1000;
            _timer.Start();
            _timer.Elapsed += (sender, args) =>
            {
                
                if (!focusTimer.IsRunning())
                    return;

                var timeLeft = focusTimer.GetTimeLeft();

                Dispatcher.Invoke(() =>
                {
                    lblFocusOn.Content = "Focus on: '" + focusTimer.FocusOn + "'";
                    txtTimeLeft.Content = String.Format("{0} min {1} sec left of {2} min",
                        timeLeft.Minutes, timeLeft.Seconds, focusTimer.Minutes);    
                } );
                
            };
        }

        private void btnInterruptedOutsideWorld_Click(object sender, RoutedEventArgs e)
        {
            Interrupted(new InterupptedArgs { InterruptedByOutsideWorld  = true});
        }

        private void btnInterruptedMyself_Click(object sender, RoutedEventArgs e)
        {
            Interrupted(new InterupptedArgs { InterruptedByMyself  = true});
        }
    }

    public delegate void Interuppted(InterupptedArgs args);

    public class InterupptedArgs
    {
        public bool InterruptedByOutsideWorld;
        public bool InterruptedByMyself;
    }
}
