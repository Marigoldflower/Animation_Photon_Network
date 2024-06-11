using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetRender : MonoBehaviour
{
    private PhotonView pv;
    public GameObject[] bodys;
    public GameObject[] hands;
    public GameObject[] weapons;

    void Start()
    {
        pv = this.GetComponent<PhotonView>();

        int playerMask = 1 << LayerMask.NameToLayer("Player");
        int enemyMask = 1 << LayerMask.NameToLayer("Enemy");
        int handMask = 1 << LayerMask.NameToLayer("Hand");
        int weaponMask = 1 << LayerMask.NameToLayer("Weapon");

        hands[0].layer = handMask;
        hands[1].layer = handMask;

        foreach (var weapon in weapons)
        {
            Renderer[] renderers = weapon.GetComponentsInChildren<Renderer>();
            for (int i = 0; i < renderers.Length; i++)
            {
                renderers[i].gameObject.layer = weaponMask;
            }
        }

        if (pv.IsMine)
        {
            foreach (var body in bodys)
            {
                Renderer[] renderers = body.GetComponentsInChildren<Renderer>();
                for (int i = 0; i < renderers.Length; i++)
                {
                    renderers[i].gameObject.layer = playerMask;
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
                    renderers[i].gameObject.layer = enemyMask;
                }
            }
        }
    }
}
