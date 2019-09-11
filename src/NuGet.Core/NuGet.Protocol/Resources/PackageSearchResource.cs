// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using NuGet.Common;

namespace NuGet.Protocol.Core.Types
{
    public abstract class PackageSearchResource : INuGetResource
    {
        /// <summary>
        /// Retrieves search results
        /// </summary>

        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        public virtual Task<IEnumerable<IPackageSearchMetadata>> SearchAsync(
            string searchTerm,
            SearchFilter filters,
            int skip,
            int take,
            Common.ILogger log,
            CancellationToken cancellationToken)
        {
            return SearchAsync(searchTerm, filters, skip, take, log, NullProtocolDiagnostics.Instance, cancellationToken);
        }

        /// <summary>
        /// Retrieves search results
        /// </summary>

        public virtual Task<IEnumerable<IPackageSearchMetadata>> SearchAsync(
            string searchTerm,
            SearchFilter filters,
            int skip,
            int take,
            Common.ILogger log,
            IProtocolDiagnostics protocolDiagnostics,
            CancellationToken cancellationToken)
        {
#pragma warning disable CS0618 // For backwards compatibility
            return SearchAsync(searchTerm, filters, skip, take, log, cancellationToken);
#pragma warning restore CS0618 // For backwards compatibility
        }
    }
}
