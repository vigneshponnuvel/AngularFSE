using Outreach_WebAPI.DataProvider;
using Outreach_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

public class FeedbackDataProviderServiceFake: IFeedbackDataProvider
{
    private readonly List<TTtrnFeedback> _feedback;

    public FeedbackDataProviderServiceFake()
    {
        _feedback = new List<TTtrnFeedback>()
            {
                new TTtrnFeedback() { Feedbackid = 1,
                    Eventid="45", Associateid=380816, Feedbackcategory = "RegAttended",Mainfeedback="good",Optionalfeedback1="NA",Optionalfeedback2="NA",Associatestatus="NA",Createddt=DateTime.Now },
                new TTtrnFeedback() { Feedbackid = 2,
                    Eventid="55", Associateid=665665, Feedbackcategory = "RegAttended",Mainfeedback="good",Optionalfeedback1="NA",Optionalfeedback2="NA",Associatestatus="NA",Createddt=DateTime.Now },

                new TTtrnFeedback() { Feedbackid = 3,
                    Eventid="65", Associateid=665666, Feedbackcategory = "RegAttended",Mainfeedback="good",Optionalfeedback1="NA",Optionalfeedback2="NA",Associatestatus="NA",Createddt=DateTime.Now },
            };
        
    }

    public async Task<IEnumerable<TTtrnFeedback>> GetAllFeedback()
    {
        await Task.Run(() =>
        {

        });
        return _feedback;
    }

    public async Task AddFeedback(TTtrnFeedback feedback)
    {
        await Task.Run(() =>
        {

        });

        feedback.Feedbackid =3;
        feedback.Eventid = "66";
        feedback.Associateid = 665669;
        feedback.Feedbackcategory = "test";
        feedback.Mainfeedback = "NA";
        feedback.Optionalfeedback1 = "option1";
        feedback.Optionalfeedback2 = "Optional2";
        feedback.Associatestatus = "NA";
        feedback.Createddt = DateTime.Now;
        _feedback.Add(feedback);
    }

    public async Task<TTtrnFeedback> GetFeedback(int Feedbackid)
    {     
        await Task.Run(() =>
        {
           
        });
        return _feedback.Find(x => x.Eventid == "45");
    }
   

}

