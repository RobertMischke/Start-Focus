using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;


public class LoadAllSessions
{
    public static List<FocusSession> Run()
    {
        var lines = File.ReadAllLines(Settings.GetSessionFileFullPath());
        return lines.Select(JsonConvert.DeserializeObject<FocusSession>).ToList();
    }
}
