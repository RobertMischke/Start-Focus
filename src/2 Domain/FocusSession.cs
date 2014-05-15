using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class FocusSession
{
    public string On;
    
    /// <summary>Minutes modified trough silence and noise modificators </summary>
    public int Minutes;

    /// <summary>Real minutes</summary>
    public int MinutesNet;

    public bool Success;
    public bool FailedBecauseMyself;
    public bool FailedBecauseWorld;

    public bool InSilence;
    public bool InNoise;

    public DateTime DateSaved;

}

