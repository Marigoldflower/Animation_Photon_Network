using Photon.Pun;
using Photon.Realtime;
using SCI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameNetworkManager : MonoBehaviourPunCallbacks
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
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        base.OnPlayerEnteredRoom(newPlayer);
        Debug.Log("New Player Come In");
    }

    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.IsConnectedAndReady)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
            PhotonNetwork.Instantiate("Character2", spawnPosition, Quaternion.identity);

            // isMine �÷��̾ ���Ͽ� �ƹ�Ÿ ����ȭ
            var players = FindObjectsOfType<NetworkCharacterController>();
            foreach (var player in players)
            {
                if (player.GetComponent<PhotonView>().IsMine)
                {
                    player.GetComponent<CharacterAvatar>().Initialize();
                    break;
                }
            }
            /////////////////////////
        }
    }

    //void Start()
    //{

    //    if (PhotonNetwork.IsConnectedAndReady)
    //    {
    //        Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
    //        PhotonNetwork.Instantiate("Character", spawnPosition, Quaternion.identity);
    //    }

    //}
}
