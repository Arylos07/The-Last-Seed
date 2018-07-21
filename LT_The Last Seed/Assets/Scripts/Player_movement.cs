using UnityEngine;
using System.Collections;

public class Player_movement : MonoBehaviour
{
    public float CurrentSpeed;
    public float WalkSpeed;
    public float RunSpeed;
    public float JumpSpeed;
    public float Gravity;
    public bool CanRun;

    public bool bDoubleJump = false;
    private Vector3 v3_moveDirection = Vector3.zero;
    private CharacterController controller;

    void Awake()
    {
        CurrentSpeed = WalkSpeed;
        controller = gameObject.GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetButtonDown("Sprint") && CanRun)
            CurrentSpeed = RunSpeed;
        else if (Input.GetButtonUp("Sprint") && CanRun)
            CurrentSpeed = WalkSpeed;

        if (controller.transform.position.z >= 0.5f || controller.transform.position.z <= -0.5f)
            controller.transform.position = new Vector3(controller.transform.position.x, controller.transform.position.y ,0);

        if (controller.isGrounded)
        {
            bDoubleJump = false;
            v3_moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            v3_moveDirection *= CurrentSpeed;
        }
        else if (!controller.isGrounded)
        {
            v3_moveDirection.x = Input.GetAxis("Horizontal") * WalkSpeed;
        }

        if (Input.GetButtonDown("Jump"))
        {
            if (controller.isGrounded)
            {
                v3_moveDirection.y = JumpSpeed;
                bDoubleJump = true;
            }
            else if (bDoubleJump)
            {
                bDoubleJump = false;
                v3_moveDirection.y = JumpSpeed;
            }
        }

        v3_moveDirection.y -= Gravity * Time.deltaTime;
        controller.Move(v3_moveDirection * Time.deltaTime);
    }

}