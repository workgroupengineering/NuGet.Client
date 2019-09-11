// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;
using NuGet.Packaging.Core;
using NuGet.Versioning;

namespace NuGet.Protocol.Core.Types
{
    /// <summary>
    /// Basic metadata
    /// </summary>
    public abstract class MetadataResource : INuGetResource
    {
        /// <summary>
        /// Get all versions of a package
        /// </summary>
        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public Task<IEnumerable<NuGetVersion>> GetVersions(string packageId, SourceCacheContext sourceCacheContext, Common.ILogger log, CancellationToken token)
        {
            return GetVersions(packageId, true, false, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        /// <summary>
        /// Get all versions of a package
        /// </summary>
        public async Task<IEnumerable<NuGetVersion>> GetVersions(string packageId, SourceCacheContext sourceCacheContext, Common.ILogger log, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
            return await GetVersions(packageId, true, false, sourceCacheContext, log, protocolDiagnostics, token);
        }

        /// <summary>
        /// Get all versions of a package
        /// </summary>
        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<IEnumerable<NuGetVersion>> GetVersions(string packageId, bool includePrerelease, bool includeUnlisted, SourceCacheContext sourceCacheContext, Common.ILogger log, CancellationToken token)
        {
            return GetVersions(packageId, includePrerelease, includeUnlisted, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        /// <summary>
        /// Get all versions of a package
        /// </summary>
        public virtual Task<IEnumerable<NuGetVersion>> GetVersions(
            string packageId,
            bool includePrerelease,
            bool includeUnlisted,
            SourceCacheContext sourceCacheContext,
            Common.ILogger log,
            IProtocolDiagnostics protocolDiagnostics,
            CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return GetVersions(packageId, includePrerelease, includeUnlisted, sourceCacheContext, log, token);
#pragma warning restore CS0618 // For backwards comparibility
        }

        /// <summary>
        /// True if the package exists in the source
        /// Includes unlisted.
        /// </summary>
        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public async Task<bool> Exists(PackageIdentity identity, SourceCacheContext sourceCacheContext, Common.ILogger log, CancellationToken token)
        {
            return await Exists(identity, true, sourceCacheContext, log, token);
        }

        /// <summary>
        /// True if the package exists in the source
        /// Includes unlisted.
        /// </summary>
        public async Task<bool> Exists(PackageIdentity identity, SourceCacheContext sourceCacheContext, Common.ILogger log, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
            return await Exists(identity, true, sourceCacheContext, log, protocolDiagnostics, token);
        }

        /// <summary>
        /// True if the package exists in the source
        /// </summary>
        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<bool> Exists(PackageIdentity identity, bool includeUnlisted, SourceCacheContext sourceCacheContext, Common.ILogger log, CancellationToken token)
        {
            return Exists(identity, includeUnlisted, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        /// <summary>
        /// True if the package exists in the source
        /// </summary>
        public virtual Task<bool> Exists(PackageIdentity identity, bool includeUnlisted, SourceCacheContext sourceCacheContext, Common.ILogger log, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return Exists(identity, includeUnlisted, sourceCacheContext, log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public async Task<bool> Exists(string packageId, SourceCacheContext sourceCacheContext, Common.ILogger log, CancellationToken token)
        {
            return await Exists(packageId, true, false, sourceCacheContext, log, token);
        }

        public async Task<bool> Exists(string packageId, SourceCacheContext sourceCacheContext, Common.ILogger log, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
            return await Exists(packageId, true, false, sourceCacheContext, log, protocolDiagnostics, token);
        }

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<bool> Exists(string packageId, bool includePrerelease, bool includeUnlisted, SourceCacheContext sourceCacheContext, Common.ILogger log, CancellationToken token)
        {
            return Exists(packageId, includePrerelease, includeUnlisted, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        public virtual Task<bool> Exists(string packageId, bool includePrerelease, bool includeUnlisted, SourceCacheContext sourceCacheContext, Common.ILogger log, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return Exists(packageId, includePrerelease, includeUnlisted, sourceCacheContext, log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<IEnumerable<KeyValuePair<string, NuGetVersion>>> GetLatestVersions(IEnumerable<string> packageIds, bool includePrerelease, bool includeUnlisted, SourceCacheContext sourceCacheContext, Common.ILogger log, CancellationToken token)
        {
            return GetLatestVersions(packageIds, includePrerelease, includeUnlisted, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        public virtual Task<IEnumerable<KeyValuePair<string, NuGetVersion>>> GetLatestVersions(IEnumerable<string> packageIds,
            bool includePrerelease,
            bool includeUnlisted,
            SourceCacheContext sourceCacheContext,
            Common.ILogger log,
            IProtocolDiagnostics protocolDiagnostics,
            CancellationToken token)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return GetLatestVersions(packageIds, includePrerelease, includeUnlisted, sourceCacheContext, log, token);
#pragma warning restore CS0618 // For backwards compatibility
        }

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public Task<NuGetVersion> GetLatestVersion(string packageId, bool includePrerelease, bool includeUnlisted, SourceCacheContext sourceCacheContext, Common.ILogger log, CancellationToken token)
        {
            return GetLatestVersion(packageId, includePrerelease, includeUnlisted, sourceCacheContext, log, NullProtocolDiagnostics.Instance, token);
        }

        public async Task<NuGetVersion> GetLatestVersion(string packageId, bool includePrerelease, bool includeUnlisted, SourceCacheContext sourceCacheContext, Common.ILogger log, IProtocolDiagnostics protocolDiagnostics, CancellationToken token)
        {
            var results = await GetLatestVersions(new string[] { packageId }, includePrerelease, includeUnlisted, sourceCacheContext, log, protocolDiagnostics, token);
            var result = results.SingleOrDefault();

            if (!result.Equals(default(KeyValuePair<string, bool>)))
            {
                return result.Value;
            }

            return null;
        }
    }
}
