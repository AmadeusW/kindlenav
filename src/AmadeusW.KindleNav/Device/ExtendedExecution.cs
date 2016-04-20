using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel.ExtendedExecution;

namespace AmadeusW.KindleNav.Device
{
    static class ExtendedExecution
    {
        static ExtendedExecutionSession _session;

        static ExtendedExecution()
        {
            _session = new ExtendedExecutionSession();
        }

        public static async Task<bool> Start()
        {
            _session.Reason = ExtendedExecutionReason.LocationTracking;
            _session.Description = "Serving requests";
            var result = await _session.RequestExtensionAsync();
            await Logger.Log($"Extended execution: {result}.");
            return (result == ExtendedExecutionResult.Allowed);
        }

        public static async Task<bool> Stop()
        {
            _session.Reason = ExtendedExecutionReason.Unspecified;
            _session.Description = String.Empty;
            var result = await _session.RequestExtensionAsync();
            await Logger.Log($"Extended execution: {result}.");
            return true;
        }
    }
}
