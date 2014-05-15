using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


class Session_data : FocusSession
{
    [Test]
    public void Should_calculate_minutes()
    {
        var focusSession = new FocusTimer();
        
        focusSession.Start(10 * 60, "", inTotalSilcene:true, withDistractions:false); 
        Assert.That(focusSession.MinutesWithModificators, Is.EqualTo(15));

        focusSession.Start(10 * 60, "", inTotalSilcene: false, withDistractions: true);
        Assert.That(focusSession.MinutesWithModificators, Is.EqualTo(3));
    }
}
