using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace MyOnlinePetStoreClient.Helpers {
    public static class ExtensionMethods {

        public static NameValueCollection QueryString(this NavigationManager navigationManager) {
            return HttpUtility.ParseQueryString(new Uri(navigationManager.Uri).Query);
        }

        public static string QueryString(this NavigationManager navigationManager, string key) {
            return navigationManager.QueryString()[key];
        }

        public static string QueryString(string uri, string key) {
            return HttpUtility.ParseQueryString(new Uri(uri).Query)[key];
        }
    }
}
