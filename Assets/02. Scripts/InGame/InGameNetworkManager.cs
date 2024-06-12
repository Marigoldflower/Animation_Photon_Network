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

            // RPC�� ������ �÷��̾� �ڽ�Ƭ ����
            var players = FindObjectsOfType<NetworkCharacterController>();
            CharacterAvatar avatar = null;

            foreach (var player in players)
            {
                if (player.GetComponent<PhotonView>().IsMine)
                {
                    avatar = player.GetComponent<CharacterAvatar>();
                    break;
                }
            }

            if (avatar != null)
            {
                avatar.Initialize();

                if (PhotonNetwork.PlayerListOthers.Length > 0)
                {
                    photonView.RPC("AvatarChange", RpcTarget.Others, avatar);
                }
            }
            //////////////////////////////
        }
    }

    [PunRPC]
    public void AvatarChange(CharacterAvatar avatar)
    {
        avatar.Initialize();
    }
}
