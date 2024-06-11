using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePrefabManager : MonoBehaviour
{

    void Start()
    {

        if (PhotonNetwork.IsConnectedAndReady)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-1f, 1f), 1f, Random.Range(-1f, 1f));
            PhotonNetwork.Instantiate("Character", spawnPosition, Quaternion.identity);
        }
       
    }
}
