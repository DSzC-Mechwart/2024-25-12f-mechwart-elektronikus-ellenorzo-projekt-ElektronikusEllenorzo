﻿using IKT_II_Derecske_Holding_EE.API_Data;
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

namespace IKT_II_Derecske_Holding_EE.Ablakok.Tanar
{
    /// <summary>
    /// Interaction logic for TanarPanel.xaml
    /// </summary>
    public partial class TanarPanel : UserControl
    {
        SzerverAdatok szerverAdatok = new();

        public TanarPanel()
        {
            InitializeComponent();
        }
    }
}