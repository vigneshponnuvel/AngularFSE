using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Outreach_WebAPI.Models;

namespace Outreach_WebAPI.DataProvider
{
    public interface IEventsDataProvider
    {
        Task<IEnumerable<TEventSummary>> GetEvents();

        Task<TEventSummary> GetEvent(string eventID);

        Task<TEventInformation> GetEventFromIDAndAssoID(string eventID, int associateID, int feedBackType);
    }
}
