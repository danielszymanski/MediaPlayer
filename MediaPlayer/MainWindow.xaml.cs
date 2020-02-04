using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace MediaPlayer
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //public static int intVolume;

        DispatcherTimer timer;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void PlayButton_Click(object sender, RoutedEventArgs e)
        {
           // intVolume = (int)PlayedMedia.Volume * 100;
            PlayedMedia.Play();

            if (timer != null)
                timer.Start();
        }
        private void StopButton_Click(object sender, RoutedEventArgs e)
        {
            PlayedMedia.Stop();

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

            timer.Start();
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
    }
}
