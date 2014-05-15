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
    /// Interaction logic for ucHeader_start_focus.xaml
    /// </summary>
    public partial class ucHeader_start_focus : UserControl
    {
        public event FocusStarted FocusStarted;

        public ucHeader_start_focus()
        {
            InitializeComponent();
        }

        private void btnStartFocus_Click(object sender, RoutedEventArgs e)
        {
            int minutes;
            if (!Int32.TryParse(txtMinutes.Text, out minutes))
            {
                MessageBox.Show("Hi, try a valid number - not: '" + txtMinutes.Text + "'.");
                return;
            }

            if (minutes == 0)
            {
                MessageBox.Show("Hi, try something above 0.");
                return;
            }

            App.FocusTimer.Start(minutes * 60);

            if(FocusStarted != null)
                FocusStarted(this, new FocusStartedArgs());
        }
    }

    public delegate void FocusStarted(object sender, FocusStartedArgs args);

    public class FocusStartedArgs
    {
    }
}
