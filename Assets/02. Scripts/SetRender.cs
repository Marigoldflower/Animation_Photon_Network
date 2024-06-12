using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRender : MonoBehaviour
{
    private PhotonView pv;
    public GameObject[] bodys;
    public GameObject[] hands;
    //public GameObject[] weapons;

    void Start()
    {
        pv = this.GetComponent<PhotonView>();

        hands[0].layer = 9;
        hands[1].layer = 9;

        //foreach (var weapon in weapons)
        //{
        //    Renderer[] renderers = weapon.GetComponentsInChildren<Renderer>();
        //    for (int i = 0; i < renderers.Length; i++)
        //    {
        //        renderers[i].gameObject.layer = 8;
        //    }
        //}

        if (pv.IsMine)
        {
            foreach (var body in bodys)
            {
                Renderer[] renderers = body.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].gameObject.layer = 6;
                }
            }
        }
        else
        {
            foreach (var body in bodys)
            {
                Renderer[] renderers = body.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].gameObject.layer = 7;
                }
            }
        }
    }
}
