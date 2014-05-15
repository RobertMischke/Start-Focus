using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class FocusSession
{
    public string On;
    public int Minutes;

    public bool Success;
    public bool FailedBecauseMyself;
    public bool FailedBecauseWorld;

    public DateTime DateSaved;

}

