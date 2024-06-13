using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

[System.Serializable]
public class LobbyVRMap
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

public class LobbyCharacterController : MonoBehaviour
{
    public float turnSmoothness = 0.1f;
    public LobbyVRMap head;
    public LobbyVRMap leftHand;
    public LobbyVRMap rightHand;

    public Vector3 headbodyPositionOffset;
    //public float headBodyYawOffset;

    private void Start()
    {
        XROrigin origin = FindObjectOfType<XROrigin>();

        head.vrTarget = origin.transform.GetChild(0).GetChild(0);//XR Origin/Camera Offset/Main Camera
        leftHand.vrTarget = origin.transform.GetChild(0).GetChild(1); // XR Origin/ Camera Offset/ Left Controller
        rightHand.vrTarget = origin.transform.GetChild(0).GetChild(2); // XR Origin/ Camera Offset / Right Controller
    }

    void LateUpdate()
    {
        // 플레이어의 위치를 설정
        this.transform.position = new Vector3(head.ikTarget.position.x, 0f, head.ikTarget.position.z); 

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
