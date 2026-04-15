using System;
using System.Timers;
using System.Windows;
using System.Collections.Generic;

namespace InstronLike
{
    public partial class MainWindow : Window
    {
        private Timer _timer;
        private double _time;
        private double _position;
        private double _force;

        private List<double> _x = new();
        private List<double> _y = new();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            _time = 0;
            _position = 0;
            _force = 0;

            _x.Clear();
            _y.Clear();

            Plot.Plot.Clear();
            Plot.Refresh();

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

            _x.Add(_position);
            _y.Add(_force);

            Dispatcher.Invoke(() =>
            {
                ForceText.Text = $"Force: {_force:F2} N";
                PositionText.Text = $"Position: {_position:F2} mm";
                TimeText.Text = $"Time: {_time:F2} s";

                Plot.Plot.Clear();
                Plot.Plot.Add.Scatter(_x.ToArray(), _y.ToArray());
                Plot.Refresh();
            });
        }
    }
}
