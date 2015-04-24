﻿using System;
using System.Linq;
using Windows.ApplicationModel.DataTransfer;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using SharpTox.Core;
using WinTox.ViewModel;

namespace WinTox.View
{
    public sealed partial class ProfileSettingsFlyout : SettingsFlyout
    {
        private ProfileSettingsViewModel _viewModel;

        public ProfileSettingsFlyout()
        {
            InitializeComponent();
            _viewModel = DataContext as ProfileSettingsViewModel;
            StatusComboBox.ItemsSource = Enum.GetValues(typeof (ToxUserStatus)).Cast<ToxUserStatus>();
        }

        private void NameTextBoxLostFocus(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox.Text == String.Empty)
                textBox.Text = _viewModel.Name;
        }

        private void CopyButtonClick(object sender, RoutedEventArgs e)
        {
            var dataPackage = new DataPackage();
            dataPackage.RequestedOperation = DataPackageOperation.Copy;
            dataPackage.SetText(ToxIdTextBlock.Text);
            Clipboard.SetContent(dataPackage);
        }

        private async void ProfileSettingsFlyoutLostFocus(object sender, RoutedEventArgs e)
        {
            await _viewModel.SaveDataAsync();
        }
    }
}