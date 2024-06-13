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

        #region Photon Callbacks
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

            // RPC를 보내서 로컬의 코스튬 정보 전송
            ReQuestSyncCostume(RpcTarget.Others);
        }

        public override void OnJoinedRoom()
        {
            if (PhotonNetwork.IsConnectedAndReady)
            {
                Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
                PhotonNetwork.Instantiate("Character2", spawnPosition, Quaternion.identity);

                // 로컬 및 리모트 플레이어 코스튬 정보 전송
                ReQuestSyncCostume(RpcTarget.All);
            }
        }
        #endregion

        public NetworkCharacterController GetLocalPlayer()
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


        public void ReQuestSyncCostume(RpcTarget target)
        {
            NetworkCharacterController localPlayer = GetLocalPlayer();

            if (localPlayer != null)
            {
                int viewID = localPlayer.GetComponent<PhotonView>().ViewID;

                int count = DataManager.Instance.GetCostumeDatas().Count;
                int[] types = new int[count];
                int[] indexs = new int[count];
                for (int i = 0; i < count; i++)
                {
                    types[i] = i;
                    indexs[i] = DataManager.Instance.GetCostumeData((CostumeType)i);
                }

                photonView.RPC("SyncCostumeRPC", target, viewID, types, indexs);
            }
        }

        [PunRPC]
        public void SyncCostumeRPC(int viewID, int[] types, int[] indexs)
        {
            var datas = new Dictionary<CostumeType, int>();
            for (int i = 0; i < types.Length; i++)
            {
                datas[(CostumeType)i] = indexs[i];
            }

            var players = FindObjectsOfType<NetworkCharacterController>();

            foreach (var player in players)
            {
                if (player.GetComponent<PhotonView>().ViewID == viewID)
                {
                    CharacterAvatar avatar = player.GetComponent<CharacterAvatar>();

                    foreach (var data in datas)
                    {
                        avatar.SetCostume(data.Key, data.Value);
                    }

                    break;
                }
            }
        }
    }
}
