// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;

namespace NuGet.Protocol.Core.Types
{
    /// <summary>
    /// A resource for detecting the capabilities of a V2 feed.
    /// </summary>
    public abstract class LegacyFeedCapabilityResource : INuGetResource, ILegacyFeedCapabilityResource
    {

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<bool> SupportsSearchAsync(ILogger log, CancellationToken token)
        {
            return SupportsSearchAsync(log, NullProtocolDiagnostics.Instance, token);
        }

        public virtual Task<bool> SupportsSearchAsync(ILogger log, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return SupportsSearchAsync(log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<bool> SupportsIsAbsoluteLatestVersionAsync(ILogger log, CancellationToken token)
        {
            return SupportsIsAbsoluteLatestVersionAsync(log, NullProtocolDiagnostics.Instance, token);
        }

        public virtual Task<bool> SupportsIsAbsoluteLatestVersionAsync(ILogger log, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return SupportsIsAbsoluteLatestVersionAsync(log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }
    }
}
