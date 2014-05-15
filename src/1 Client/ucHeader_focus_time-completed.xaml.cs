﻿using System;
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
    public partial class ucHeader_focus_time_completed : UserControl
    {
        public event EventHandler CompleteConfirmed;
        public event EventHandler InterrupedByMyself;
        public event EventHandler InterruptedByWorld;

        public ucHeader_focus_time_completed()
        {
            InitializeComponent();
        }

        private void btnConfirm_Click(object sender, RoutedEventArgs e)
        {
            CompleteConfirmed(this, new EventArgs());
        }

        private void btnInterruptedByMyself_Click(object sender, RoutedEventArgs e)
        {
            InterrupedByMyself(this, new EventArgs());
        }

        private void btnInterruptedByWorld_Click(object sender, RoutedEventArgs e)
        {
            InterruptedByWorld(this, new EventArgs());
        }
    }
}
