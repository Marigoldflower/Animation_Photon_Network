using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using static UnityEngine.UI.Image;

[System.Serializable]
public class VRMap
{
    public Transform vrTarget;
    public Transform ikTarget;
    public Vector3 trackingPositionOffset;
    public Vector3 trackingRotationOffset;

    public void Map()
    {
        ikTarget.position = vrTarget.TransformPoint(trackingPositionOffset);
        ikTarget.rotation = vrTarget.rotation * Quaternion.Euler(trackingRotationOffset);
    }
}

public class SetupAnimationRigWithVR : MonoBehaviour
{
    public float turnSmoothness = 0.1f;
    public VRMap head;
    public VRMap leftHand;
    public VRMap rightHand;

    public Vector3 headbodyPositionOffset;
    //public float headBodyYawOffset;

    // XR Rig라고 생각하면 된다.
    XROrigin origin;

    private PhotonView pv;
    public float characterHeight = 0.11f;

    private void Start()
    {
        pv = this.GetComponent<PhotonView>();

        origin = FindObjectOfType<XROrigin>();

        //this.transform.SetParent(origin.transform);
        //this.transform.SetPositionAndRotation(Vector3.zero, Quaternion.identity);

        head.vrTarget = origin.transform.GetChild(0).GetChild(0);//XR Origin/Camera Offset/Main Camera
        leftHand.vrTarget = origin.transform.GetChild(0).GetChild(1); // XR Origin/ Camera Offset/ Left Controller
        rightHand.vrTarget = origin.transform.GetChild(0).GetChild(2); // XR Origin/ Camera Offset / Right Controller
    }

    void FixedUpdate()
    {
        if (pv.IsMine)
        {
            origin.GetComponent<Rigidbody>().velocity = Vector3.zero;
            origin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }

    }

    void LateUpdate()
    {
        if (pv.IsMine)
        {
            // 플레이어의 위치를 설정
            this.transform.position = new Vector3(head.ikTarget.position.x, characterHeight, head.ikTarget.position.z);

            // 플레이어의 각도를 설정
            float yaw = head.vrTarget.eulerAngles.y;
            this.transform.rotation = Quaternion.Lerp(this.transform.rotation
                                    , Quaternion.Euler(this.transform.eulerAngles.x, yaw, this.transform.eulerAngles.z)
                                    , turnSmoothness);

            // 머리, 손의 위치와 각도를 설정
            head.Map();
            leftHand.Map();
            rightHand.Map();
        }
    }
}
