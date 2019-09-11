// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;

namespace NuGet.Protocol.Core.Types
{
    public abstract class ListResource : INuGetResource
    {
        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<IEnumerableAsync<IPackageSearchMetadata>> ListAsync(
            string searchTerm,
            bool prerelease,
            bool allVersions,
            bool includeDelisted,
            ILogger log,
            CancellationToken token)
        {
            return ListAsync(searchTerm, prerelease, allVersions, includeDelisted, log, NullProtocolDiagnostics.Instance, token);
        }

        public virtual Task<IEnumerableAsync<IPackageSearchMetadata>> ListAsync(
            string searchTerm,
            bool prerelease,
            bool allVersions,
            bool includeDelisted,
            ILogger log,
            IProtocolDiagnostics protocolDiagnostics,
            CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return ListAsync(searchTerm, prerelease, allVersions, includeDelisted, log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }

        public abstract string Source { get; }
    }
}
