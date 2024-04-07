using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using Sirenix.Utilities;
using UnityEngine;

public class PlayerRoom : MonoBehaviourPunCallbacks
{
    public Transform playerSlotPrefab;
    public GameObject startButton, readyButton;
    private PlayerSlot _localSlot;
    private bool _isReady;

    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
        var playerSlot = PhotonNetwork.Instantiate(playerSlotPrefab.name, Vector3.zero, Quaternion.identity, 0).GetComponent<PlayerSlot>();
        InitializePlayerSlot(playerSlot);
        
        if(PhotonNetwork.IsMasterClient)
            startButton.SetActive(true);
        else
            readyButton.SetActive(true);
    }

    public override void OnPlayerEnteredRoom(Photon.Realtime.Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        
        if(_localSlot == null) return;
        if(!_isReady) return;
        _localSlot.photonView.RPC("IsReady", RpcTarget.OthersBuffered, _isReady);
    }

    private void InitializePlayerSlot(PlayerSlot slot)
    {
        slot.photonView.RPC("SetupPlayerSlot", RpcTarget.AllBuffered, slot.photonView.ViewID);
        if(slot.photonView.IsMine) _localSlot = slot;
    }
    
    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }

    public void ReadyGame()
    {
        _isReady = !_isReady;
        _localSlot.photonView.RPC("IsReady", RpcTarget.AllBuffered, _isReady);
    }
}
