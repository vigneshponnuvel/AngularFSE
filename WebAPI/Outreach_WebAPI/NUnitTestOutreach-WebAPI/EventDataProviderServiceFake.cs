using Outreach_WebAPI.DataProvider;
using Outreach_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public class EventDataProviderServiceFake : IEventsDataProvider
{
    private readonly List<TEventSummary> _events;
    private readonly TEventInformation _eventinformation;

    public EventDataProviderServiceFake()
    {
        _events = new List<TEventSummary>()
            {
                new TEventSummary() { Sno=1,Eventid="55",Baselocation="Chennai",Beneficiaryname="Test",Venueaddress="Penungudi,Chennai,60096",Councilname="Chennai BFS Outreach",
                                     Project="Be a Teacher", Category="Multiple Subject",Eventname="Test-Event",Eventdescription="Test-Description",
                                     Eventdate=DateTime.Now, Totalnoofvolunteers=15, Totaltravelhours=50,Overallvolunteeringhours=65,Livesimpacted=50,
                                     Activitytype=3, Status="Approved", Pocid=665665, Pocname="Sribas Das",Poccontactnumber=96796146 },

               new TEventSummary() { Sno=1,Eventid="66",Baselocation="Kolkata",Beneficiaryname="Test",Venueaddress="Saltlake,Kolkata,70002",Councilname="Kolkata  Outreach",
                                     Project="Sea Beach Clean", Category="Multiple Subject",Eventname="Test1-Event",Eventdescription="Test-Description",
                                     Eventdate=DateTime.Now, Totalnoofvolunteers=15, Totaltravelhours=50,Overallvolunteeringhours=65,Livesimpacted=50,
                                     Activitytype=3, Status="Approved", Pocid=380816, Pocname="Vignesh",Poccontactnumber=96796146 }
            };

        _eventinformation =

            new TEventInformation()
            {
                Sno = 1,
                Eventid = "55",
                Baselocation = "Chennai",
                Beneficiaryname = "TestBaneficialy",
                Councilname = "TstCouncile",
                Eventname = "Test-Event",
                Eventdescription = "Test Description",
                Eventdate = DateTime.Now,
                Employeeid = 665665,
                Employeename = "Sribas",
                Volunteerhours = 8,
                Travelhours = 2,
                Livesimpacted = 10,
                Businessunit = "Healthcare",
                Status = "Approved",
                Iiepcategory = "NA",
            };
    }

    public async Task<TEventSummary> GetEvent(string eventID)
    {
        await Task.Run(() =>
        {

        });
        return _events.Find(x => x.Eventid == "55");
    }


    public async Task<IEnumerable<TEventSummary>> GetEvents()
    {
        await Task.Run(() =>
        {

        });
        return _events;
    }

    public async Task<TEventInformation> GetEventFromIDAndAssoID(string eventID, int associateID, int feedBackType)
    {
        await Task.Run(() =>
        {

        });
        return _eventinformation;
    }
}

