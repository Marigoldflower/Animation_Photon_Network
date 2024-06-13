using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SCI
{
    public class InGameManager : MonoBehaviourPunCallbacks
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

            // RPC�� ������ �ڽ��� �ڽ�Ƭ ������ ����
            var player = GetLocalPlayer();
            if (player != null)
            {
                var avatar = player.GetComponent<CharacterAvatar>();
                photonView.RPC("SyncCostume", RpcTarget.Others, avatar, DataManager.Instance.playerData.costumeDatas);
            }
            //////////////////////////////
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.IsConnectedAndReady)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
                PhotonNetwork.Instantiate("Character2", spawnPosition, Quaternion.identity);

                // ���� �÷��̾� �ڽ�Ƭ ����
                var player = GetLocalPlayer();
                if (player != null)
                {
                    var avatar = player.GetComponent<CharacterAvatar>();
                    SyncCostume(avatar, DataManager.Instance.playerData.costumeDatas);
                }
                //////////////////////////////
            }
        }

        private NetworkCharacterController GetLocalPlayer()
        {
            var players = FindObjectsOfType<NetworkCharacterController>();

            if (players == null)
                return null;

            foreach (var player in players)
            {
                if (player.GetComponent<PhotonView>().IsMine)
                {
                    return player;
                }
            }

            return null;
        }

        [PunRPC]
        public void SyncCostume(CharacterAvatar avatar, Dictionary<CostumeType, int> datas)
        {
            foreach (var data in datas)
            {
                avatar.SetCostume(data.Key, data.Value);
            }
        }
    }
}
