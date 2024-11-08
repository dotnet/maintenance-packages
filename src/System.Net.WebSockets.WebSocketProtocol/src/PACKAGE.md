## About

Provides the `WebSocketProtocol` class, which allows creating a `WebSocket` from a connected stream using `WebSocketsProtocol.CreateFromConnectedStream`.

**NOTE:** This package was designed as a *temporary solution* for internal use (building ASP.NET targeting .NET Standard 2.0), and is now considered *obsolete*. If targeting .NET Standard 2.1 or .NET 5+, use [`WebSocket.CreateFromStream`](https://learn.microsoft.com/en-us/dotnet/api/system.net.websockets.websocket.createfromstream?view=netstandard-2.1) instead.

## Key Features

- Creates a new `WebSocket` instance that operates on the specified transport stream. The `WebSocket` class allows applications to send and receive data after the `WebSocket` upgrade has completed.
- The API can be used to create both client-side and server-side `WebSocket` instances.

## How to Use

To create a `WebSocket` using `WebSocketProtocol`, as a prerequisite, you need to prepare the opaque transport stream for the WebSocket, for example, create or accept a TCP socket connection as a `Stream` and perform a WebSocket opening handshake (upgrade) over it. Then you can use the transport stream and the negotiated subprotocol to call `WebSocketProtocol.CreateFromStream`.

```c#
Stream opaqueTransport = /* ... */; // complete WebSocket opening handshake over the transport connection
WebSocket ws = WebSocketProtocol.CreateFromStream(opaqueTransport, isServer: true, subProtocol, keepAliveInterval);
```

### Remarks

The API is considered *obsolete* and is not recommented for use.

On **.NET Framework** or **.NET Standard 2.0**:

- To create a *client* `WebSocket` from a *stream*, use [`WebSocket.CreateClientWebSocket`](https://learn.microsoft.com/en-us/dotnet/api/system.net.websockets.websocket.createclientwebsocket?view=netstandard-2.0).
    - Alternatively, consider using a `ClientWebSocket` class.
- Creating a *server* `WebSocket` from a *stream* is not available on the API surface, consider using `HttpListener` or ASP.NET `HttpContext` to accept server WebSocket connections.
    - [`HttpListenerContext.AcceptWebSocketAsync`](https://learn.microsoft.com/en-us/dotnet/api/system.net.httplistenercontext.acceptwebsocketasync?view=netframework-4.8.1)
    - [`HttpContext.AcceptWebSocketRequest`](https://learn.microsoft.com/en-us/dotnet/api/system.web.httpcontext.acceptwebsocketrequest?view=netframework-4.8.1)

On **.NET Core 2.1+**, **.NET 5+** or **.NET Standard 2.1**:

- To create a *client* or *server* `WebSocket` from a *stream*, use [`WebSocket.CreateFromStream`](https://learn.microsoft.com/en-us/dotnet/api/system.net.websockets.websocket.createfromstream?view=netstandard-2.1)

## Main Types

The main types provided by this library are:

- System.Net.WebSockets.WebSocketProtocol

## Additional Documentation

- API reference can be found in: https://learn.microsoft.com/en-us/dotnet/api/system.net.websockets.websocketprotocol
- Additional APIs mentioned:
    - WebSocket static methods: https://learn.microsoft.com/en-us/dotnet/api/system.net.websockets.websocket
    - ClientWebSocket: https://learn.microsoft.com/en-us/dotnet/api/system.net.websockets.clientwebsocket
    - HttpListener context: https://learn.microsoft.com/en-us/dotnet/api/system.net.httplistenercontext
    - ASP.NET HttpContext: https://learn.microsoft.com/en-us/dotnet/api/system.web.httpcontext

## License

System.Net.WebSockets.WebSocketProtocol is released as open source under the [MIT license](https://licenses.nuget.org/MIT).
