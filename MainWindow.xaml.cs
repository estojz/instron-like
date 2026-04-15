using System;
using System.Timers;
using System.Windows;

namespace InstronLike
{
    public partial class MainWindow : Window
    {
        private Timer _timer;
        private double _time;
        private double _position;
        private double _force;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            _time = 0;
            _position = 0;
            _force = 0;

            _timer = new Timer(50);
            _timer.Elapsed += Loop;
            _timer.Start();
        }

        private void Stop_Click(object sender, RoutedEventArgs e)
        {
            _timer?.Stop();
        }

        private void Loop(object sender, ElapsedEventArgs e)
        {
            _time += 0.05;
            _position += 0.1;
            _force = _position * 10;

            Dispatcher.Invoke(() =>
            {
                ForceText.Text = $"Force: {_force:F2} N";
                PositionText.Text = $"Position: {_position:F2} mm";
                TimeText.Text = $"Time: {_time:F2} s";
            });
        }
    }
}
