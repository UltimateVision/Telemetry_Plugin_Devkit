using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using TelemetryPlugin;

namespace TelemetryPluginDevkit
{
    public class DevKit_WebLogSample : IWebLogPlugin
    {
        public string url
        {
            get { return @"http://localhost:8080/index.php/ltcontroller/updatedata"; }
        }

        public string dataFormat
        {
            get
            {
                StringBuilder sb = new StringBuilder(_dataFormat);
                sb.Replace("[USER]", _username);
                sb.Replace("[PASS]", _password);
                return sb.ToString();
            }
        }

        private string _dataFormat = "data=[DATA]&user=[USER]&pass=[PASS]";
        private string _username;
        private string _password;

        public bool usePOST
        {
            get { return true; }
        }

        public PluginType type
        {
            get { return PluginType.WebLogHelper; }
        }

        public string name
        {
            get { return "Plugin handling custom log-in form for external WWW service"; }
        }

        public string author
        {
            get { return "Mateusz"; }
        }

        public bool isActive
        {
            get
            {
                return _isActive;
            }
            set
            {
                _isActive = value;
            }
        }

        public bool _isActive = false;

        public ActionResult Initialize()
        {
            LogInForm lif = new LogInForm();
            if (lif.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _username = lif.username;
                _password = lif.password;
                return ActionResult.Success;
            }
            return ActionResult.Failure;
        }

        public ActionResult Dispose()
        {
            return ActionResult.Success;
        }
    }
}
