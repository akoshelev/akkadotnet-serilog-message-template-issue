using Akka.Actor;
using Akka.Event;

namespace SerilogMessageTemplateIssueDemo
{
    public class SimpleActor : ReceiveActor
    {
        private ILoggingAdapter _logger = Context.GetLogger();

        public SimpleActor()
        {
            // output will be [Information][{LogSource}][Thread {Thread}] "Actor is up and running."
            // while expected [Information][<actor path>][Thread <thread id>] "Actor is up and running."
            _logger.Info("Actor is up and running.");
        }

    }
}