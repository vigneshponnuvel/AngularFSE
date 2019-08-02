using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Outreach_WebAPI.Models;

namespace Outreach_WebAPI.DataProvider
{
    public interface IFeedbackDataProvider
    {
        Task AddFeedback(TTtrnFeedback feedback);

        Task<TTtrnFeedback> GetFeedback(int Feedbackid);

        Task<IEnumerable<TTtrnFeedback>> GetAllFeedback();
    }
}
