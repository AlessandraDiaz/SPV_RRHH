using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public class UserControlBase : System.Web.UI.UserControl
{
    public delegate void Transaction_ErrorDelegate(object sender, Exception ex);
    public event Transaction_ErrorDelegate Transaction_ErrorEvent;

    public delegate void Web_ErrorDelegate(object sender, Exception ex);
    public event Web_ErrorDelegate Web_ErrorEvent;

    public void onTransaction_ErrorEvent(object sender, Exception ex)
    {
        this.Transaction_ErrorEvent(sender, ex);
    }

    public void onWeb_ErrorEvent(object sender, Exception ex)
    {
        this.Web_ErrorEvent(sender, ex);
    }

    public UserControlBase()
    {
    }
}