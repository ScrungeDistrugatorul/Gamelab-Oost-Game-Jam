using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BallOrientation : MonoBehaviour
{
    public enum State
    {
        Grounded,
        Air,
        Null
    }

    public State state = State.Grounded;

    private PlayerMovementR player;

    [SerializeField] private GameObject CamOrientation;
    
    private void Awake()
    {
        player = transform.parent.GetComponent<PlayerMovementR>();
        transform.rotation = Quaternion.identity;
    }

    private void Update()
    {
        if (player.rb.velocity.magnitude > 0)
            transform.forward = player.rb.velocity;
    }
}
