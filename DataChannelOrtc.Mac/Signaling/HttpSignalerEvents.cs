﻿using System;

namespace DataChannelOrtc.Mac.Signaling 
{
    public class HttpSignalerMessageEvent
    {
        public Peer Peer { get; set; }
        public string Message { get; set; }

        public HttpSignalerMessageEvent(Peer peer, string message)
        {
            Peer = peer;
            Message = message;
        }
    }

    public abstract class HttpSignalerEvents
    {
        // Connection events
        public event EventHandler SignedIn;
        public event EventHandler Disconnected;
        public event EventHandler ServerConnectionFailed;

        public event EventHandler<Peer> PeerConnected;
        public event EventHandler<Peer> PeerDisconnected;
        public event EventHandler<Peer> PeerHangup;
        public event EventHandler<HttpSignalerMessageEvent> MessageFromPeer;

        public abstract void SendToPeer(int id, string message);

        protected void OnSignedIn()
        {
            SignedIn?.Invoke(this, null);
        }
        protected void OnDisconnected()
        {
            Disconnected?.Invoke(this, null);
        }
        protected void OnPeerConnected(Peer peer)
        {
            PeerConnected?.Invoke(this, (peer));
        }
        protected void OnPeerDisconnected(Peer peer)
        {
            PeerDisconnected?.Invoke(this, peer);
        }
        protected void OnPeerHangup(Peer peer)
        {
            PeerHangup?.Invoke(this, peer);
        }
        protected void OnMessageFromPeer(Peer peer, string message)
        {
            MessageFromPeer?.Invoke(this, new HttpSignalerMessageEvent(peer, message));
        }
        protected void OnServerConnectionFailure()
        {
            ServerConnectionFailed?.Invoke(this, null);
        }
    }
}