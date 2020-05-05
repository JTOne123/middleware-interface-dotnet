﻿using fiskaltrust.ifPOS.v1;
using fiskaltrust.Middleware.Interface.Client.Shared;

namespace fiskaltrust.Middleware.Interface.Client.Soap
{
    public class SoapPosFactory
    {

        public IPOS CreatePosAsync(PosOptions options)
        {
            var connectionhandler = new SoapProxyConnectionHandler<IPOS>(options);
            var retryPolicyHelper = new RetryPolicyHandler<IPOS>(options.RetryPolicyOptions, connectionhandler);
            return new PosRetryProxyClient(retryPolicyHelper);
        }
    }
}
