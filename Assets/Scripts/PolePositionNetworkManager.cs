using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Mirror.Examples.Chat
{
    [AddComponentMenu("")]
    public class PolePositionNetworkManager : NetworkManager
    {
        public string Name { get; set; }

        public void SetHostname(string hostname)
        {
            networkAddress = hostname;
        }

        public ChatWindow chatWindow;

        public class CreatePlayerMessage : MessageBase
        {
            public string name;
        }

        public override void OnStartServer()
        {
            base.OnStartServer();
            NetworkServer.RegisterHandler<CreatePlayerMessage>(OnCreatePlayer);
        }

        public override void OnClientConnect(NetworkConnection conn)
        {
            base.OnClientConnect(conn);

            // tell the server to create a player with this name
            conn.Send(new CreatePlayerMessage { name = Name });
        }

        private void OnCreatePlayer(NetworkConnection connection, CreatePlayerMessage createPlayerMessage)
        {
            // create a gameobject using the name supplied by client
            GameObject playergo = Instantiate(playerPrefab);
            playergo.GetComponent<PlayerInfo>().Name = createPlayerMessage.name;

            // set it as the player
            NetworkServer.AddPlayerForConnection(connection, playergo);

            chatWindow.gameObject.SetActive(true);
        }
    }
}
