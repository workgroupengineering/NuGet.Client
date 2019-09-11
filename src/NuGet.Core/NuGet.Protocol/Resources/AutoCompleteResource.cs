// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Versioning;

namespace NuGet.Protocol.Core.Types
{
    public abstract class AutoCompleteResource : INuGetResource
    {

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<IEnumerable<string>> IdStartsWith(
            string packageIdPrefix,
            bool includePrerelease,
            Common.ILogger log,
            CancellationToken token)
        {
            return IdStartsWith(packageIdPrefix, includePrerelease, log, NullProtocolDiagnostics.Instance, token);
        }

        public virtual Task<IEnumerable<string>> IdStartsWith(
            string packageIdPrefix,
            bool includePrerelease,
            Common.ILogger log,
            IProtocolDiagnostics protocolDiagnostics,
            CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return IdStartsWith(packageIdPrefix, includePrerelease, log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }


        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<IEnumerable<NuGetVersion>> VersionStartsWith(
            string packageId,
            string versionPrefix,
            bool includePrerelease,
            SourceCacheContext sourceCacheContext,
            Common.ILogger log,
            CancellationToken token)
        {
            return VersionStartsWith(packageId, versionPrefix, includePrerelease, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        public virtual Task<IEnumerable<NuGetVersion>> VersionStartsWith(
            string packageId,
            string versionPrefix,
            bool includePrerelease,
            SourceCacheContext sourceCacheContext,
            Common.ILogger log,
            IProtocolDiagnostics protocolDiagnostics,
            CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return VersionStartsWith(packageId, versionPrefix, includePrerelease, sourceCacheContext, log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }
    }
}
