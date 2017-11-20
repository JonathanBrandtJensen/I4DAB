using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using HandIn2._2;
using HandIn2._2.Collections.AddressCollection;
using HandIn2._2.Collections.ContactCollection;
using HandIn2._2.CRUD;
using HandIn2._2.Repositories;

namespace Handin33
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        public static IContactRepo ContactRepo;
        public static IAddressRepo AddressRepo;
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            ContactRepo = new ContactRepo(new CRUD<Contact>(CosmosConnection.databaseName, CosmosConnection.contactCollection));
            AddressRepo = new AddressRepo(new CRUD<Address>(CosmosConnection.databaseName, CosmosConnection.addressCollection));
        }
    }
}
