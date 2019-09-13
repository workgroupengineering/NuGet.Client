// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using NuGet.Common;

namespace NuGet.Commands
{
    public interface ITrustedSignersCommandRunner
    {
        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        Task<int> ExecuteCommandAsync(TrustedSignersArgs trustedSignersArgs);

        Task<int> ExecuteCommandAsync(TrustedSignersArgs trustedSignersArgs, IProtocolDiagnostics protocolDiagnostics);
    }
}
