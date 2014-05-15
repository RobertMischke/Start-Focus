using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

public class FocusTimer
{
    public event FocusFinishedHandler Finished;

    public int Minutes{get { return _durationInSecs/60; }}

    private int _durationInSecs = 0; 
    private readonly Timer _timer = new Timer();
    private readonly Stopwatch _stopwatch = new Stopwatch();

    public void Start(int seconds)
    {
        _durationInSecs = seconds;

        _timer.AutoReset = true;
        _timer.Interval = (double)seconds*1000;
        _timer.Start();
        _timer.Elapsed += (sender, args) =>
        {
            if (Finished != null) 
                Finished(this, new FocusFinishedArgs());
        };

        _stopwatch.Reset();
        _stopwatch.Start();
    }

    public bool IsRunning()
    {
        return _timer.Enabled;
    }

    public TimeSpan GetTimeLeft()
    {
        return new TimeSpan(0, 0, _durationInSecs) - _stopwatch.Elapsed; ;
    }

    public void Stop()
    {
        _timer.Stop();
        _stopwatch.Stop();
        _stopwatch.Reset();
    }
}
