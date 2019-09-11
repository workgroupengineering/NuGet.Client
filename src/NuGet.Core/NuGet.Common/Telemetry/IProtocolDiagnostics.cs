// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace NuGet.Common
{
    public interface IProtocolDiagnostics
    {
        void OnEvent(string source, string url, TimeSpan? headerDuration, TimeSpan requestDuration, bool isSuccess, bool isRetry, bool isCancelled);
    }
}
