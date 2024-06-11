using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingManager : MonoBehaviour
{
    public Transform leftHandIK;
    public Transform rightHandIK;

    public Transform leftHandController;
    public Transform rightHandController;

    // Scene에서의 월드와 실제 월드 간의 position 및 rotation이 안 맞는 경우가 있다. 
    // 따라서 offset을 약간 추가해주어야 한다. 
    // position과 rotation 둘 다 있어야 하기 때문에 배열로 설정했다.
    public Vector3[] leftOffset; // [0] : position [1] rotation이 앞으로 들어가게 될 것임.
    public Vector3[] rightOffset;

    private void LateUpdate()
    {
        MappingHandTransform(leftHandIK, leftHandController, true);
        MappingHandTransform(rightHandIK, rightHandController, false);
    }

    private void MappingHandTransform(Transform ik, Transform controller, bool isLeft)
    {
        // ik의 Transform = controller의 Transform 
        var offset = isLeft ? leftOffset : rightOffset; 
        ik.position = controller.TransformPoint(offset[0]);
        ik.rotation = controller.rotation * Quaternion.Euler(offset[1]);

    }
}
