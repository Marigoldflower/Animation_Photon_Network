using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnectionManager : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        // 스크린의 사이즈 조정 
        Screen.SetResolution(1080, 720, false);

        // 높을 수록 네트워크 전송 속도가 빠르다. 대신 과부하가 걸릴 확률이 높음
        PhotonNetwork.SendRate = 60;
        PhotonNetwork.SerializationRate = 30;
        PhotonNetwork.GameVersion = "1";
    }

    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("네트워크 마스터에 접속");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2; // 최대 플레이어 수를 2로 설정
        PhotonNetwork.JoinOrCreateRoom("GameRoom", roomOptions, null);
        Debug.Log("2명이 들어갈 수 있는 방을 생성");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("New Player Come In");
    }
}

