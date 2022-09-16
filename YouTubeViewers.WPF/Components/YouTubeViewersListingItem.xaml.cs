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

namespace YouTubeViewers.WPF.Components
{
    /// <summary>
    /// YouTubeViewersListingItem.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class YouTubeViewersListingItem : UserControl
    {
        public YouTubeViewersListingItem()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            dropdown.IsOpen = false;
        }
    }
}
