﻿#if WCF

using fiskaltrust.ifPOS.Tests.Helpers;
using fiskaltrust.ifPOS.Tests.Helpers.Wcf;
using System;
using System.ServiceModel;

namespace fiskaltrust.ifPOS.Tests.v0.IPOS
{
    public class WcfV1ServerAndV0ClientIPOSTests : IPOSTests
    {
        private string _url;
        private ServiceHost _serviceHost;

        public WcfV1ServerAndV0ClientIPOSTests()
        {
            _url = $"net.pipe://localhost/pos/{Guid.NewGuid()}";
        }

        ~WcfV1ServerAndV0ClientIPOSTests()
        {
            _serviceHost.Close();
            _serviceHost = null;
        }

        protected override ifPOS.v0.IPOS CreateClient() => WcfHelper.GetProxy<ifPOS.v0.IPOS>(_url);

        protected override void StartHost() => _serviceHost = WcfHelper.StartHost<ifPOS.v0.IPOS>(_url, new DummyPOSV1());

        protected override void StopHost() => _serviceHost.Close();
    }
}

#endif