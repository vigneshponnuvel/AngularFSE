using NUnit.Framework;
using Outreach_WebAPI.Controllers;
using Outreach_WebAPI.DataProvider;

namespace Tests
{

    public class Tests
    {
        FeedbackController _controllerFeedback;
        IFeedbackDataProvider _serviceFeedback;
        EventsController _controllerEvent;
        IEventsDataProvider _serviceEvent;

        public Tests()
        {

        }

        [SetUp]
        public void Setup()
        {
            _serviceFeedback = new FeedbackDataProviderServiceFake();
            _controllerFeedback = new FeedbackController(_serviceFeedback);
            _serviceEvent = new EventDataProviderServiceFake();
            _controllerEvent = new EventsController(_serviceEvent);
        }

        [Test]
        public void TestGetFeedbackByEventId()
        {
            var result = _controllerFeedback.Get(55);
            //var okResult = _controller.Get().Result as OkObjectResult;

            Assert.That(result.Result.Associateid, Is.EqualTo(380816));
            Assert.Pass();
        }

        [Test]
        public void TestGetEventByEventId()
        {
            var result = _controllerEvent.Get("55");


            Assert.That(result.Result.Eventname, Is.EqualTo("Test-Event"));
            Assert.Pass();
        }

        [Test]
        public void GetEventFromIDAndAssoID()
        {
            var result = _controllerEvent.Get("55", 665665, 1);

            Assert.That(result.Result.Volunteerhours, Is.EqualTo(8));
            Assert.Pass();
        }
    }
}