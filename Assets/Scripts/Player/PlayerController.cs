using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header("Components")]
    public float jumpForce;

    Rigidbody2D rig;
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();   
    }

    // Update is called once per frame
    void Jump()
    {
        if(Input.GetAxis("Jump") > 0)
        {
            rig.velocity = Vector2.zero;
            rig.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }
    }

    enum JumpState
    {
        PrepareToJump,
        Jumping,
        Falling,
    }

}
