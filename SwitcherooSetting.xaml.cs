﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Wox.Infrastructure.Storage;

namespace Wox.Plugin.Switcheroo
{
    /// <summary>
    /// Interaction logic for SwitcherooSetting.xaml
    /// </summary>
    public partial class SwitcherooSetting : UserControl
    {
        private readonly SwitcherooSettings _settings;
        private readonly PluginJsonStorage<SwitcherooSettings> _storage;

        public SwitcherooSetting(SwitcherooSettings settings, PluginJsonStorage<SwitcherooSettings> storage)
        {
            _settings = settings;
            _storage = storage;

            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            cbOverrideAltTab.IsChecked = _settings.OverrideAltTab;

            cbOverrideAltTab.Checked += (o, args) =>
            {
                _settings.OverrideAltTab = true;
                _storage.Save();
            };
            cbOverrideAltTab.Unchecked += (o, args) =>
            {
                _settings.OverrideAltTab = false;
                _storage.Save();
            };
        }

        private void label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/kvakulo/Switcheroo");
        }
    }
}
