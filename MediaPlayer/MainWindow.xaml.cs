using Microsoft.Win32;
using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MediaPlayer
{
    public partial class MainWindow : Window
    {
        private bool fullscreen = false;
        private DispatcherTimer DoubleClickTimer = new DispatcherTimer();
        private DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();

            DoubleClickTimer.Interval = TimeSpan.FromMilliseconds(GetDoubleClickTime());
            DoubleClickTimer.Tick += (s, e) => DoubleClickTimer.Stop();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
            PlayedMedia.Play();

            if (timer != null)
                timer.Start();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            PlayedMedia.Stop();
            MediaSlider.Value = 0;

            if (timer != null)
                timer.Stop();
        }
        private void PauseButton_Click(object sender, RoutedEventArgs e) => PlayedMedia.Pause();
        private void DefaultBinding_CanExecute(object sender, CanExecuteRoutedEventArgs e) => e.CanExecute = true;
        private void ExitBinding_Executed(object sender, ExecutedRoutedEventArgs e) => Application.Current.Shutdown();
        private void OpenBinding_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "mp4 files (*.mp4)|*.mp4|All files (*.*)|*.*",
                RestoreDirectory = true
            };

            if (openFileDialog.ShowDialog() != null)
            {
                try
                {
                    Uri path = new Uri(openFileDialog.FileName);
                    PlayedMedia.Source = path;
                    PlayedMedia.Stop();
                }
                catch(Exception ex)
                { MessageBox.Show(ex.Message,"Something went wrong",MessageBoxButton.OK, MessageBoxImage.Error); }
            }
        }

        private void PlayedMedia_MediaFailed(object sender, ExceptionRoutedEventArgs e) => MessageBox.Show(e.ErrorException.Message);

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            PlayedMedia.ScrubbingEnabled = true;
            PlayedMedia.Stop();
        }

        private void PlayedMedia_MediaOpened(object sender, RoutedEventArgs e)
        {
            MediaSlider.Maximum = PlayedMedia.NaturalDuration.TimeSpan.TotalSeconds;

            timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(0.5)
            };

            timer.Tick += Timer_Tick;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            MediaSlider.Value = PlayedMedia.Position.TotalSeconds;
        }

        private void MediaSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            PlayedMedia.Position = TimeSpan.FromSeconds(MediaSlider.Value);
        }

        private void MediaSlider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
        {
            PlayedMedia.Pause();

            if (timer != null)
                timer.Stop();
        }

        private void MediaSlider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
        {
            PlayedMedia.Play();

            if (timer != null)
                timer.Start();
        }

        private void PlayedMedia_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (!DoubleClickTimer.IsEnabled)
            {
                DoubleClickTimer.Start();
            }
            else
            {
                if (!fullscreen)
                {
                    this.WindowStyle = WindowStyle.None;
                    this.WindowState = WindowState.Maximized;
                    ToolsGrid.Visibility = Visibility.Collapsed;
                    MenuBar.Visibility = Visibility.Collapsed;
                    //PlayedMedia.Cursor = Cursors.None;
                }
                else
                {
                    this.WindowStyle = WindowStyle.SingleBorderWindow;
                    this.WindowState = WindowState.Normal;
                    ToolsGrid.Visibility = Visibility.Visible;
                    MenuBar.Visibility = Visibility.Visible;
                   //PlayedMedia.Cursor = Cursors.Arrow;
                }

                fullscreen = !fullscreen;
            }
        }

        [DllImport("user32.dll")]
        private static extern uint GetDoubleClickTime();
    }
}
