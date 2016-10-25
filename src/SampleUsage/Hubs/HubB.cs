using GeniusSports.Signalr.Hubs.TypeScriptGenerator.SampleUsage.DataContracts;
using Microsoft.AspNet.SignalR;

namespace GeniusSports.Signalr.Hubs.TypeScriptGenerator.SampleUsage.Hubs
{
    public interface IHubBClient
    {
        void TakeOtherThis(OtherSomethingDto otherSomethingDto);
    }

    public class HubB : Hub<IHubBClient>
    {
        public OtherSomethingDto GetOtherSomething()
        {
            return new OtherSomethingDto();
        }

        public void DoOtherSomethingElse()
        {
        }
    }
}