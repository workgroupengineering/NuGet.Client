// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Threading.Tasks;
using NuGet.Common;

namespace NuGet.Commands
{
    public interface IListCommandRunner
    {
        [Obsolete("Use the overload with " + nameof(IProtocolDiagnostics) + ". Use " + nameof(NullProtocolDiagnostics) + " if no diagnostics are needed")]
        Task ExecuteCommand(ListArgs listArgs);

        Task ExecuteCommand(ListArgs listArgs, IProtocolDiagnostics protocolDiagnostics);
    }
}
