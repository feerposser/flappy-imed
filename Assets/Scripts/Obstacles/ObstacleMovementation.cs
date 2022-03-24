using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMovementation : MonoBehaviour
{

    Rigidbody2D rig;
    public float velocity;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rig.velocity = Vector2.left * velocity;
    }
}
