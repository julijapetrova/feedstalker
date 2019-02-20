using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Security;
using System.ServiceModel;
using System.ServiceModel.Web;

using System.Text;
using System.ServiceModel.Syndication;

namespace Feed_Stalker.Services
{


    [ServiceContract]
    public interface FeedReaderService
    {

        [OperationContract]
        [WebGet]
        SyndicationFeed GetFeed(string secretkey);
    }
}
