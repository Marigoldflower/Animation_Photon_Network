using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetAnimationMovingAccordingToVR : MonoBehaviour
{
    public InputActionProperty moveAction; // XR ��Ʈ�ѷ��� ��ƽ �Է��� �ޱ� ���� ������Ƽ

    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        Vector2 moveInput = moveAction.action.ReadValue<Vector2>(); // ��ƽ �Է� �б�

        animator.SetFloat("MoveX", moveInput.x);
        animator.SetFloat("MoveY", moveInput.y);

    }

}
