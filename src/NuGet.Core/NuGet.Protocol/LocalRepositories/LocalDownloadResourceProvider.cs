// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    public class LocalDownloadResourceProvider : ResourceProvider
    {
        public LocalDownloadResourceProvider()
            : base(typeof(DownloadResource), nameof(LocalDownloadResourceProvider), NuGetResourceProviderPositions.Last)
        {
        }

        public override async Task<Tuple<bool, INuGetResource>> TryCreate(SourceRepository source, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
            DownloadResource downloadResource = null;

            var localResource = await source.GetResourceAsync<FindLocalPackagesResource>(protocolDiagnostics, token);

            if (localResource != null)
            {
                downloadResource = new LocalDownloadResource(localResource);
            }

            return new Tuple<bool, INuGetResource>(downloadResource != null, downloadResource);
        }
    }
}
