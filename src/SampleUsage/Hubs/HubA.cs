using GeniusSports.Signalr.Hubs.TypeScriptGenerator.SampleUsage.DataContracts;
using Microsoft.AspNet.SignalR;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.SampleUsage.Hubs
{
    public interface IHubAClient
    {
        void Pong();
        void TakeThis(SomethingDto somethingDto);
    }

    public class HubA : Hub<IHubAClient>
    {
        public SomethingDto GetSomething()
        {
            return new SomethingDto();
        }

        public InheritedSomethingDto GetInheritedSomething()
        {
            return new InheritedSomethingDto();
        }

        public void Ping()
        {
        }
    }
}