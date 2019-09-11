// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Protocol.Core.Types;

namespace NuGet.Protocol
{
    public class PackageMetadataResourceV2FeedProvider : ResourceProvider
    {
        public PackageMetadataResourceV2FeedProvider()
            : base(typeof(PackageMetadataResource),
                  nameof(PackageMetadataResourceV2FeedProvider),
                  "PackageMetadataResourceLocalProvider")
        {
        }

        public override async Task<Tuple<bool, INuGetResource>> TryCreate(SourceRepository source, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
            PackageMetadataResourceV2Feed resource = null;

            if (await source.GetFeedType(protocolDiagnostics, token) == FeedType.HttpV2)
            {
                var httpSourceResource = await source.GetResourceAsync<HttpSourceResource>(protocolDiagnostics, token);

                var serviceDocument = await source.GetResourceAsync<ODataServiceDocumentResourceV2>(protocolDiagnostics, token);

                resource = new PackageMetadataResourceV2Feed(httpSourceResource, serviceDocument.BaseAddress, source.PackageSource);
            }

            return new Tuple<bool, INuGetResource>(resource != null, resource);
        }
    }
}
