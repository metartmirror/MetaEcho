using System.Linq;
using System.Text.RegularExpressions;
using ExitGames.Client.Photon;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine;

namespace Networks
{
    public class Launcher : MonoBehaviourPunCallbacks
    {
        public TextMeshProUGUI connectingMessageText;

        #region Private Fields

        /// <summary>
        /// This client's version number. Users are separated from each other by gameVersion (which allows you to make breaking changes).
        /// </summary>
        private string gameVersion = "1";

        #endregion

        #region MonoBehaviour CallBacks

        private void Awake()
        {
            // #Critical
            // this makes sure we can use PhotonNetwork.LoadLevel() on the master client and all clients in the same room sync their level automatically
            PhotonNetwork.AutomaticallySyncScene = true;
        }

        #endregion


        #region Public Methods
        public void Connect()
        {
            if (PhotonNetwork.IsConnected)
            {
                Disconnect();
                return;
            }

            connectingMessageText.text = "Connecting...\n";
            LoginPanel.instance.MainPanelRightUpEnable = true;
            PhotonNetwork.GameVersion = gameVersion;
            PhotonNetwork.ConnectUsingSettings();
        }

        public void Disconnect()
        {
            LoginPanel.instance.MainPanelRightUpEnable = false;
            PhotonNetwork.Disconnect();
        }
        
        #region MonoBehaviourPunCallbacks Callbacks

        public override void OnRegionListReceived(RegionHandler regionHandler)
        {
            base.OnRegionListReceived(regionHandler);
            var ping = ParseStringToInt(Regex.Replace(PhotonNetwork.BestRegionSummaryInPreferences, "[^0-9]", ""));
            connectingMessageText.text += $"Connected to: {PhotonNetwork.NetworkingClient.RegionHandler.BestRegion.Code}, Ping: {GetColorCodedPing(ping, 0, 1000)}\n";
        }

        public override void OnDisconnected(DisconnectCause cause)
        {
            Debug.LogWarningFormat("PUN Basics Tutorial/Launcher: OnDisconnected() was called by PUN with reason {0}", cause);
            connectingMessageText.text = "Disconnected from the master.";
        }
        
        public override void OnJoinRandomFailed(short returnCode, string message)
        {
            Debug.Log("PUN Basics Tutorial/Launcher:OnJoinRandomFailed() was called by PUN. No random room available, so we create one.\nCalling: PhotonNetwork.CreateRoom");
            connectingMessageText.text += "No game found.\nCreating a new game...\n";
            connectingMessageText.text += message + ".\n";
            
            // #Critical: we failed to join a random room, maybe none exists or they are all full. No worries, we create a new room.
            PhotonNetwork.CreateRoom(null, new RoomOptions());
        }

        public override void OnJoinedRoom()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnJoinedRoom() called by PUN. Now this client is in a room.");
            connectingMessageText.text += "Joined a game.\n";
            Invoke(nameof(EnterRoom), 0.5f);
        }

        #endregion

        private void EnterRoom()
        {
            LoginPanel.instance.MainPanelRightUpEnable = false;
            LoginPanel.instance.RoomPanelEnable = true;
        }

        public override void OnConnectedToMaster()
        {
            Debug.Log("PUN Basics Tutorial/Launcher: OnConnectedToMaster() was called by PUN");
            connectingMessageText.text += "Connected to the master...\n";
            PhotonNetwork.JoinRandomRoom();
        }
        
        private void OnRegionPingCompleted(RegionHandler handler)
        {
            // Define min and max ping values for color interpolation
            int minPing = 0;   // Minimum (good) ping value
            int maxPing = 800; // Maximum (bad) ping value
            
            // Print pings for all regions
            foreach (Region region in handler.EnabledRegions)
            {
                connectingMessageText.text += $"Region: {region.Code}, Ping: {GetColorCodedPing(region.Ping, minPing, maxPing)}\n";
            }

            // Find and print the best region
            Region bestRegion = handler.BestRegion;
            connectingMessageText.text += $"Best Region: {bestRegion.Code}, Ping: {GetColorCodedPing(bestRegion.Ping, minPing, maxPing)}\n";
        }

        private string GetColorCodedPing(int ping, int minPing, int maxPing)
        {
            // Clamp ping value to be within the defined range
            ping = Mathf.Clamp(ping, minPing, maxPing);

            // Calculate interpolation factor (0 to 1)
            float factor = (float)(ping - minPing) / (maxPing - minPing);

            // Interpolate between green (0, 1, 0) and red (1, 0, 0)
            Color color = Color.Lerp(Color.green, Color.red, factor);
    
            // Convert color to hex format
            string colorHex = ColorUtility.ToHtmlStringRGB(color);

            return $"<color=#{colorHex}>{ping}ms</color>";
        }
        
        private int ParseStringToInt(string input)
        {
            var success = int.TryParse(input, out var result);
            if (!success)
                result = -1;
            return result;
        }

        public void QuitGame()
        {
            Application.Quit();
        }
        #endregion
    }
}