using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;

namespace Hongpil
{
    // ��Ʈ��ũ�� ����� ������ ��Ʈ��ũ ĳ���� (PhotonView)�� ���� XR Rig�� ��������ִ� �ڵ�
    public class CharacterController : MonoBehaviour
    {
        private PhotonView pv;
        //Player Avatar�� �Ӹ�, �޼�, ������
        public Transform head;
        public Transform leftHand;
        public Transform rightHand;

        //XR �������� �Ӹ�, �޼�, ������
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

            // ��Ʈ��ũ�� ������ �Ǹ� XR Rig, XR Rig�� ����� �޴� �ƹ�Ÿ, ��Ʈ��ũ ���� �ƹ�Ÿ �� 3���� �����ϰ� �ȴ�. 
            // ��Ʈ��ũ�� ������ ��, �� �ƹ�Ÿ�� �� ��Ʈ��ũ ĳ���Ͱ� ��ġ�� ��찡 ����µ� 
            // �� ��Ʈ��ũ ĳ������ ����� ���� ��. 
            // �׷��� ������ ���忡���� pv.isMine�� false�̱� ������ 
            // �� ��Ʈ��ũ ĳ������ ����� ������ �ʰ� ���δٴ� ���̴�. 

            // �� �ڵ�� XR Rig�� XR Rig�� ����� �޴� �ƹ�Ÿ�� ��Ʈ��ũ���� ����ϰ��� �� ������ ����ϴ� �ڵ��̴�.
            // ���� ��Ʈ��ũ ���� �ƹ�Ÿ�� ����ϰ��� �Ѵٸ� �� �̻� �� �ڵ�� �ʿ䰡 ��������. 
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

                Debug.Log("��Ʈ��ũ ĳ���Ϳ� VR Rig ���� ��ũ�� �� ���������� Ȯ��");
            }
        }

        private void SyncTransform(Transform targetTf, Transform rigTf)
        {
            targetTf.position = rigTf.position;
            targetTf.rotation = rigTf.rotation;
        }
    }

}