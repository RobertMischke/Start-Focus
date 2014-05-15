using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


[TestFixture]
public class BaseTest
{
    public BaseTest()
    {
        Settings.SessionFileName = "Sessions.tests.json";
        File.WriteAllText(Settings.GetSessionFileFullPath(), "");
    }
}

