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
    /// Interaction logic for ucHeader_focus_in_progress.xaml
    /// </summary>
    public partial class ucHeader_focus_interrupted : UserControl
    {
        public event EventHandler InterruptCancelled; 
        public event EventHandler InterruptConfirmed;

        public ucHeader_focus_interrupted()
        {
            InitializeComponent();
        }

        private void btnInterrupConfirm_Click(object sender, RoutedEventArgs e)
        {
            InterruptConfirmed(this, new EventArgs());
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            InterruptCancelled(this, new EventArgs());
        }
    }
}
