﻿#if WCF

using fiskaltrust.ifPOS.Tests.Helpers;
using fiskaltrust.ifPOS.Tests.Helpers.Wcf;
using System;
using System.ServiceModel;

namespace fiskaltrust.ifPOS.Tests.v0.IPOS
{
    public class WcfV0ServerAndV0ClientIPOSTests : IPOSTests
    {
        private string _url;
        private ServiceHost _serviceHost;

        public WcfV0ServerAndV0ClientIPOSTests()
        {
            _url = $"net.pipe://localhost/pos/{Guid.NewGuid()}";
        }

        ~WcfV0ServerAndV0ClientIPOSTests()
        {
            _serviceHost.Close();
            _serviceHost = null;
        }

        protected override ifPOS.v0.IPOS CreateClient() => WcfHelper.GetProxy<ifPOS.v0.IPOS>(_url);

        protected override void StartHost() => _serviceHost = WcfHelper.StartHost<ifPOS.v0.IPOS>(_url, new DummyPOS());

        protected override void StopHost() => _serviceHost.Close();
    }
}

#endif