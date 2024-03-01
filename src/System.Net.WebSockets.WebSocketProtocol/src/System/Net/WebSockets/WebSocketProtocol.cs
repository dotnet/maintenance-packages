// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System.IO;
using System.Threading;

namespace System.Net.WebSockets
{
    public static class WebSocketProtocol
    {
        public static WebSocket CreateFromStream(
            Stream renamedStream,
            bool isServer,
            string? subProtocol,
            TimeSpan keepAliveInterval)
        {
            if (renamedStream == null)
            {
                throw new ArgumentNullException(nameof(renamedStream));
            }

            if (!renamedStream.CanRead || !renamedStream.CanWrite)
            {
                throw new ArgumentException(!renamedStream.CanRead ? SR.NotReadableStream : SR.NotWriteableStream, nameof(renamedStream));
            }

            if (subProtocol != null)
            {
                WebSocketValidate.ValidateSubprotocol(subProtocol);
            }

            if (keepAliveInterval != Timeout.InfiniteTimeSpan && keepAliveInterval < TimeSpan.Zero)
            {
                throw new ArgumentOutOfRangeException(nameof(keepAliveInterval), keepAliveInterval,
                    SR.Format(SR.net_WebSockets_ArgumentOutOfRange_TooSmall,
                    0));
            }

            return ManagedWebSocket.CreateFromConnectedStream(renamedStream, isServer, subProtocol, keepAliveInterval);
        }
    }
}
