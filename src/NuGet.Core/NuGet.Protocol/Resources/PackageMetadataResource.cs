// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Packaging.Core;

namespace NuGet.Protocol.Core.Types
{
    public abstract class PackageMetadataResource : INuGetResource
    {
        /// <summary>
        /// Returns all versions of a package
        /// </summary>

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<IEnumerable<IPackageSearchMetadata>> GetMetadataAsync(
            string packageId,
            bool includePrerelease,
            bool includeUnlisted,
            SourceCacheContext sourceCacheContext,
            Common.ILogger log,
            CancellationToken token)
        {
            return GetMetadataAsync(packageId, includePrerelease, includeUnlisted, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        /// <summary>
        /// Returns all versions of a package
        /// </summary>
        public virtual Task<IEnumerable<IPackageSearchMetadata>> GetMetadataAsync(
            string packageId,
            bool includePrerelease,
            bool includeUnlisted,
            SourceCacheContext sourceCacheContext,
            Common.ILogger log,
            IProtocolDiagnostics protocolDiagnostics,
            CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return GetMetadataAsync(packageId, includePrerelease, includeUnlisted, sourceCacheContext, log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }

        /// <summary>
        /// Return package metadata for the input PackageIdentity
        /// </summary>

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<IPackageSearchMetadata> GetMetadataAsync(
            PackageIdentity package,
            SourceCacheContext sourceCacheContext,
            Common.ILogger log,
            CancellationToken token)
        {
            return GetMetadataAsync(package, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        /// <summary>
        /// Return package metadata for the input PackageIdentity
        /// </summary>
        public virtual Task<IPackageSearchMetadata> GetMetadataAsync(
            PackageIdentity package,
            SourceCacheContext sourceCacheContext,
            Common.ILogger log,
            IProtocolDiagnostics protocolDiagnostics,
            CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return GetMetadataAsync(package, sourceCacheContext, log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }
    }
}
