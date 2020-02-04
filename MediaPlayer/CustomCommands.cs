using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MediaPlayer
{
    class CustomCommands
    {
        public static readonly RoutedUICommand Exit = new RoutedUICommand("Exit", "Exit", typeof(CustomCommands));
        public static readonly RoutedUICommand Play = new RoutedUICommand("Play", "Play", typeof(CustomCommands), new InputGestureCollection {new KeyGesture(Key.Space)});
        public static readonly RoutedUICommand Pause = new RoutedUICommand("Pause", "Pause", typeof(CustomCommands), new InputGestureCollection { new KeyGesture(Key.Space,ModifierKeys.Control) });
        public static readonly RoutedUICommand Stop = new RoutedUICommand("Stop", "Stop", typeof(CustomCommands), new InputGestureCollection { new KeyGesture(Key.S,ModifierKeys.Control) });
    }
}
