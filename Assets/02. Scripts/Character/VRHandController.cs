using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRHandController : MonoBehaviour
{
    public InputActionProperty leftGrip;
    public InputActionProperty rightGrip;

    private Animator animator;

    void Start()
    {
        animator = this.GetComponent<Animator>();
    }

    void Update()
    {
        float leftGripValue = leftGrip.action.ReadValue<float>();
        animator.SetFloat("Left Grip", leftGripValue);

        float rightGripValue = rightGrip.action.ReadValue<float>();
        animator.SetFloat("Right Grip", rightGripValue);
    }
}
