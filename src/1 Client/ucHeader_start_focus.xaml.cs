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
    public partial class ucHeader_start_focus : UserControl, IHeaderUc
    {
        public event FocusStarted FocusStarted;

        public ucHeader_start_focus()
        {
            InitializeComponent();
        }

        public void Activated()
        {

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

            if (txtFocusOn.Text.Trim().Length <= 3)
            {
                MessageBox.Show("Please use at least 3 letters to describe on what you want to start to focus.");
                return;
            }
            
            App.FocusTimer.Start(
                minutes * 60, 
                txtFocusOn.Text,
                Convert.ToBoolean(ckbInTotalSilence.IsChecked),
                Convert.ToBoolean(ckbWithHighDistractions.IsChecked));

            if(FocusStarted != null)
                FocusStarted(this, new FocusStartedArgs());
        }
    }

    public delegate void FocusStarted(object sender, FocusStartedArgs args);

    public class FocusStartedArgs
    {
    }
}
