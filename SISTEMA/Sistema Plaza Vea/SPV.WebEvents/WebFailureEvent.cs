using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Management;

namespace SPV.WebEvents
{
    public class WebFailureEvent : WebFailureAuditEvent
    {
        string customMessage;

        public WebFailureEvent(object sender, String usuarioID, String message)
            : base(String.Format("Usuario: {0}. - Message: {1};", usuarioID, message), sender, WebEventCodes.WebExtendedBase)
        {
            this.customMessage = String.Format("Usuario: {0}. - Message: {1};", usuarioID, message);
        }
        public override void FormatCustomEventDetails(WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);
            formatter.AppendLine(this.customMessage);
        }
    }
}