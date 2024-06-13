using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DB : MonoBehaviour, IPunObservable
{
    private PhotonView pv;

    public string leftWeapon;
    public string rightWeapon;

    public string getLeftWeapon;
    public string getRightWeapon;

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        pv = this.GetComponent<PhotonView>();
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(leftWeapon);
            stream.SendNext(rightWeapon);
        }
        else if (stream.IsReading)
        {
            getLeftWeapon = (string)stream.ReceiveNext();
            getRightWeapon = (string)stream.ReceiveNext();
        }
    }
}
