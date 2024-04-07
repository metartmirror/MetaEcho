using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Photon.Pun;
using UnityEngine;

public class LevelManager : MonoBehaviourPunCallbacks
{
    public GameObject playerPrefab;
    private PhotonPlayer _player;
    private int _index;

    private void Start()
    {
        if (!PhotonNetwork.IsConnected) return;
        if (playerPrefab == null)
        {
            Debug.LogError("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'",this);
        }
        else
        {
            _player = PhotonNetwork.Instantiate(this.playerPrefab.name, transform.position, Quaternion.identity, 0).GetComponent<PhotonPlayer>();
        }
    }
}
