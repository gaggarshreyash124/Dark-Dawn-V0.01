using System;
using Unity.Cinemachine;
using UnityEngine;
using UnityEngine.Scripting;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private CinemachineCamera PlayerCamera;
    [SerializeField] private CharacterController PlayerController;
    [SerializeField,RequiredMember] private PlayerData PlayerData;
    //[SerializeField] private Animator PlayerAnimator;
    
    [SerializeField] private float MoveSpeed;
    [SerializeField] private float JumpForce;
    
    Vector3 CamForward()
    {
        Vector3 forward = PlayerCamera.transform.forward;
        forward.y = 0f;
        return forward.normalized;
    }
    
    Vector3 CamRight()
    {
        Vector3 right = PlayerCamera.transform.right;
        right.y = 0f;
        return right.normalized;
    }
    
    Vector3 moveDir => CamForward() * PlayerInputManger.Instance.MoveInput.y + CamRight() * PlayerInputManger.Instance.MoveInput.x;


    private void Awake()
    {
        PlayerController =  GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    public void Move()
    {
        PlayerController.Move(moveDir * MoveSpeed * Time.deltaTime);
    }
}
