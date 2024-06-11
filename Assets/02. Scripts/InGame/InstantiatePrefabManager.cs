using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabManager : MonoBehaviour
{
    private void Awake()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2; // 최대 플레이어 수를 2로 설정
        PhotonNetwork.JoinOrCreateRoom("GameRoom", roomOptions, null);
    }

    void Start()
    {

        if (PhotonNetwork.IsConnectedAndReady)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
            PhotonNetwork.Instantiate("Character", spawnPosition, Quaternion.identity);
        }
       
    }
}
