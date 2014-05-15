using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


public class Settings
{
    public static string SessionFileName = "Sessions.json";

    public static string GetDirectory()
    {
        var dir = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        dir = Path.Combine(dir, "Start-Focus");
        if (!Directory.Exists(dir))
            Directory.CreateDirectory(dir);
        return dir;         
    }

    public static string GetSessionFileFullPath()
    {
        var fullPath = Path.Combine(GetDirectory(), SessionFileName);
        if (!File.Exists(fullPath)){
            File.Create(fullPath);
        }
            


        return fullPath;
    }
}

