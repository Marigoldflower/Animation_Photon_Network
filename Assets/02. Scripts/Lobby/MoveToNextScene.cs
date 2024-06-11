using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveToNextScene : MonoBehaviourPunCallbacks
{
    public GameObject player;
    public GameObject portal;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("In Game으로 들어갑니다");
            JoinOrCreateRoom();
        }
    }

    void JoinOrCreateRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            PhotonNetwork.LoadLevel("InGame");
        }
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a Room");
    }
}
