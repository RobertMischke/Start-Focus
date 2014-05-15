using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class SaveFocusSession
{
    public static void Run(FocusSession session)
    {
        var fullPath = Settings.GetSessionFileFullPath();
        
        session.DateSaved = DateTime.Now;

        using (StreamWriter sw = File.AppendText(fullPath)){
            sw.WriteLine(JsonConvert.SerializeObject(session));
        }	
    }
}