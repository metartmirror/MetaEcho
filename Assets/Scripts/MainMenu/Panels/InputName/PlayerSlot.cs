using System;
using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerSlot : MonoBehaviourPun
{
    public TextMeshProUGUI playerNameText;
    public GameObject readyMark, masterMark;
    public bool isReady { get; private set; }

    private void Start()
    {
        transform.localScale = Vector3.one;
        GetComponent<RectTransform>().localPosition = Vector3.zero;
    }

    public void SetName(string name)
    {
        playerNameText.text = name;
    }

    [PunRPC]
    private void SetupPlayerSlot(int slotId)
    {
        var targetView = PhotonView.Find(slotId);
        if (targetView == null) return;
        targetView.transform.SetParent(LoginPanel.instance.playerSlotParent);
        var playerSlot = targetView.GetComponent<PlayerSlot>();
        playerSlot.SetName(playerSlot.photonView.IsMine? PhotonNetwork.NickName + " (You)" : playerSlot.photonView.Owner.NickName);
        if(playerSlot.photonView.Owner.IsMasterClient) masterMark.SetActive(true);
    }

    [PunRPC]
    private void IsReady(bool ready)
    {
        readyMark.SetActive(ready);
        isReady = ready;
    }
    
}
