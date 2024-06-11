using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SetAnimationMovingAccordingToVR : MonoBehaviour
{
    public InputActionProperty moveAction; // XR 컨트롤러의 스틱 입력을 받기 위한 프로퍼티
    private Animator animator;
    private PhotonView pv;

    void Start()
    {
        pv = this.GetComponent<PhotonView>();
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        if (pv.IsMine)
        {
            Vector2 moveInput = moveAction.action.ReadValue<Vector2>(); // 스틱 입력 읽기

            animator.SetFloat("MoveX", moveInput.x);
            animator.SetFloat("MoveY", moveInput.y);            
        }
    }

}
