﻿using System;
using Windows.UI.Xaml.Data;
using WinTox.ViewModel.FileTransfer;

namespace WinTox.Converters
{
    internal class TransferStateToEnabledConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var state = (FileTransferState) value;
            return (state != FileTransferState.PausedByFriend);
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            return null;
        }
    }
}