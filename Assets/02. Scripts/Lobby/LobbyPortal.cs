using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LobbyPortal : MonoBehaviourPunCallbacks
{

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("In Game으로 들어갑니다");
            SceneManager.LoadScene("InGame");
        }
    }
}
