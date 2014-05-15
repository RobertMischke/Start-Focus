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

    public string FocusOn;
    public int MinutesNet{get { return _durationInSecs/60; }}

    public int MinutesWithModificators
    {
        get
        {
            if(InTotalSilence)
                return (int)Math.Round(MinutesNet * 1.5, 0);

            if (WithDistracionts)
                return (int)Math.Round(MinutesNet * 0.3, 0);

            return MinutesNet;
        }
    }

    private int _durationInSecs = 0; 
    private readonly Timer _timer = new Timer();
    private readonly Stopwatch _stopwatch = new Stopwatch();

    public bool InTotalSilence;
    public bool WithDistracionts;

    private DateTime _interruptAnnouncedTime;
    private bool _interruptByMyself;
    private bool _interruptByWorld;
    private bool _success;

    public void Start(int seconds, string focusOn, bool inTotalSilcene, bool withDistractions)
    {
        FocusOn = focusOn;
        InTotalSilence = inTotalSilcene;
        WithDistracionts = withDistractions;

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

    public void InterruptAnnounced(bool byMyself = false, bool byWorld = false)
    {
        _interruptByMyself = byMyself;
        _interruptByWorld = byWorld;
        _interruptAnnouncedTime = DateTime.Now;
    }

    public void Stop()
    {
        _timer.Stop();
        _stopwatch.Stop();
        _stopwatch.Reset();
    }

    public FocusSession ToFocusSession()
    {
        return new FocusSession
        {
            FailedBecauseMyself = _interruptByMyself,
            FailedBecauseWorld = _interruptByWorld,
            InNoise = InTotalSilence, 
            InSilence = InTotalSilence,
            MinutesNet = MinutesNet,
            Minutes = MinutesWithModificators,
            Success = _success,
            On = FocusOn
        };
    }

}
