using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Hongpil
{
    // 네트워크로 연결시 생성된 네트워크 캐릭터 (PhotonView)와 실제 XR Rig를 연결시켜주는 코드
    public class CharacterController : MonoBehaviour
    {
        private PhotonView pv;
        //Player Avatar의 머리, 왼손, 오른손
        public Transform head;
        public Transform leftHand;
        public Transform rightHand;

        //XR 오리진의 머리, 왼손, 오른손
        public Transform headRig;
        public Transform leftHandRig;
        public Transform rightHandRig;

        XROrigin origin;

        void Start()
        {
            pv = this.GetComponent<PhotonView>();

            origin = FindObjectOfType<XROrigin>();

            headRig = origin.transform.GetChild(0).GetChild(0);//XR Origin/Camera Offset/Main Camera
            leftHandRig = origin.transform.GetChild(0).GetChild(1); // XR Origin/ Camera Offset/ Left Controller
            rightHandRig = origin.transform.GetChild(0).GetChild(2); // XR Origin/ Camera Offset / Right Controller

            // 네트워크에 들어오게 되면 XR Rig, XR Rig의 명령을 받는 아바타, 네트워크 상의 아바타 총 3개가 존재하게 된다. 
            // 네트워크로 들어왔을 때, 내 아바타와 내 네트워크 캐릭터가 겹치는 경우가 생기는데 
            // 내 네트워크 캐릭터의 모습만 끄는 것. 
            // 그런데 상대방의 입장에서는 pv.isMine이 false이기 때문에 
            // 내 네트워크 캐릭터의 모습이 꺼지지 않고 보인다는 뜻이다. 

            // 이 코드는 XR Rig와 XR Rig의 명령을 받는 아바타를 네트워크에서 사용하고자 할 때에만 사용하는 코드이다.
            // 만일 네트워크 상의 아바타를 사용하고자 한다면 더 이상 이 코드는 필요가 없어진다. 
            //if (pv.IsMine)
            //{
            //    Renderer[] renderers = this.GetComponentsInChildren<Renderer>();
            //    foreach (var renderer in renderers)
            //    {
            //        renderer.enabled = false;
            //    }
            //}
        }

        void FixedUpdate()
        {
            origin.GetComponent<Rigidbody>().velocity = Vector3.zero;
            origin.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

        }

        private void Update()
        {
            if (pv.IsMine)
            {
                SyncTransform(head, headRig);
                SyncTransform(leftHand, leftHandRig);
                SyncTransform(rightHand, rightHandRig);

                Debug.Log("네트워크 캐릭터와 VR Rig 간의 싱크가 잘 맞춰졌는지 확인");
            }
        }

        private void SyncTransform(Transform targetTf, Transform rigTf)
        {
            targetTf.position = rigTf.position;
            targetTf.rotation = rigTf.rotation;
        }
    }

}