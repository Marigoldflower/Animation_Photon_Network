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

            // RPC를 보내서 플레이어 코스튬 갱신
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
