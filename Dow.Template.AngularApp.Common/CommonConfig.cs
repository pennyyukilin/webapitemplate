using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dow.Template.AngularApp.Common
{
    public static class CommonConfig
    {
        #region Private Fields
        private static string dbConnectionSecretUri = ConfigurationManager.AppSettings["dbConnectionSecretUri"];
        private static string pbiSecretUri = ConfigurationManager.AppSettings["pbi:secretUri"];
        private static string pbiAuthorityUrl = ConfigurationManager.AppSettings["pbi:authorityUrl"];
        private static string pbiResourceUrl = ConfigurationManager.AppSettings["pbi:resourceUrl"];
        private static string pbiClientIDUrl = ConfigurationManager.AppSettings["pbi:clientID"];
        private static string pbiApiUrl = ConfigurationManager.AppSettings["pbi:apiUrl"];

        private static string clientID = ConfigurationManager.AppSettings["ida:ClientId"];
        private static string tenant = ConfigurationManager.AppSettings["ida:Tenant"];
        private static string instrumentationKey = ConfigurationManager.AppSettings["instrumentationKey"];

        #endregion

        #region Public Fields
        public static string DBConnectionSecretUri { get { return dbConnectionSecretUri; } }

        public static string PbiSecretUri { get { return pbiSecretUri; } }

        public static string PbiAuthorityUrl { get { return pbiAuthorityUrl; } }

        public static string PbiResourceUrl { get { return pbiResourceUrl; } }

        public static string PbiClientIDUrl { get { return pbiClientIDUrl; } }

        public static string PbiApiUrl{ get { return pbiApiUrl; } }

        public static string ClientID { get { return clientID; } }

        public static string Tenant { get { return tenant; } }

        public static string InstrumentationKey { get { return instrumentationKey; } }

        #endregion
    }
}
