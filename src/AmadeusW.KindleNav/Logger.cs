using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Core;
using Windows.UI.Xaml.Controls;

namespace AmadeusW.KindleNav
{
    static class Logger
    {
        private static TextBlock _textBlock;

        public static void RegisterControl(TextBlock textBlock)
        {
            _textBlock = textBlock;
        }

        public static async Task Log(string message)
        {
            if (_textBlock == null)
                return;

            await _textBlock.Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
            {
                _textBlock.Text += $"{message}\n";
            });
            
        }
    }
}
