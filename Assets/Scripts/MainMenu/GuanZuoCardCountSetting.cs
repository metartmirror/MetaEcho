using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class GuanZuoCardCountSetting : MonoBehaviourPunCallbacks
{
    public TextMeshProUGUI cardCountText;
    public int cardCount;
    
    
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        
        // 如果是新加入的玩家，请求最新的卡牌计数
        if (!PhotonNetwork.IsMasterClient)
        {
            photonView.RPC("RequestCardCountUpdate", RpcTarget.MasterClient);
        }
    }

    public void ModifyCardCount(int count)
    {
        // 只有 Master Client 可以修改卡牌计数
        if (PhotonNetwork.IsMasterClient)
        {
            cardCount += count;
            cardCountText.text = cardCount.ToString();
            photonView.RPC("SyncCardCount", RpcTarget.Others, cardCount);
        }
    }

    [PunRPC]
    private void SyncCardCount(int count)
    {
        // 同步卡牌计数并更新UI
        cardCount = count;
        cardCountText.text = cardCount.ToString();
    }
    
    [PunRPC]
    private void RequestCardCountUpdate()
    {
        // 回应新玩家请求最新的卡牌计数
        photonView.RPC("SyncCardCount", photonView.Owner, cardCount);
    }
}
