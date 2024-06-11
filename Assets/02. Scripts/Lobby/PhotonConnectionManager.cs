using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhotonConnectionManager : MonoBehaviourPunCallbacks
{
    void Awake()
    {
        // ��ũ���� ������ ���� 
        Screen.SetResolution(1080, 720, false);

        // ���� ���� ��Ʈ��ũ ���� �ӵ��� ������. ��� �����ϰ� �ɸ� Ȯ���� ����
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
        Debug.Log("��Ʈ��ũ �����Ϳ� ����");
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2; // �ִ� �÷��̾� ���� 2�� ����
        PhotonNetwork.JoinOrCreateRoom("GameRoom", roomOptions, null);
        Debug.Log("2���� �� �� �ִ� ���� ����");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("New Player Come In");
    }
}

