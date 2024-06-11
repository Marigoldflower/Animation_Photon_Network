using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RiggingManager : MonoBehaviour
{
    public Transform leftHandIK;
    public Transform rightHandIK;

    public Transform leftHandController;
    public Transform rightHandController;

    // Scene������ ����� ���� ���� ���� position �� rotation�� �� �´� ��찡 �ִ�. 
    // ���� offset�� �ణ �߰����־�� �Ѵ�. 
    // position�� rotation �� �� �־�� �ϱ� ������ �迭�� �����ߴ�.
    public Vector3[] leftOffset; // [0] : position [1] rotation�� ������ ���� �� ����.
    public Vector3[] rightOffset;

    private void LateUpdate()
    {
        MappingHandTransform(leftHandIK, leftHandController, true);
        MappingHandTransform(rightHandIK, rightHandController, false);
    }

    private void MappingHandTransform(Transform ik, Transform controller, bool isLeft)
    {
        // ik�� Transform = controller�� Transform 
        var offset = isLeft ? leftOffset : rightOffset; 
        ik.position = controller.TransformPoint(offset[0]);
        ik.rotation = controller.rotation * Quaternion.Euler(offset[1]);

    }
}
