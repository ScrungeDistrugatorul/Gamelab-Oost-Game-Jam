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
        switch (state)
        {
        case(State.Grounded):
        //         transform.LookAt(new Vector3(-CamOrientation.transform.position.x, 0, -CamOrientation.transform.position.z), player.floorNormal);
                // transform.rotation = Quaternion.Euler(player.rb.velocity.x, player.floorNormal.y, player.rb.velocity.z);
                transform.forward = player.rb.velocity;
                // transform.rotation = quaternion.Euler( new Vector3(0,0,player.floorNormal.z));
                //transform.right = player.floorNormal;
            break;
            // case(State.Air):
            //     Vector3 pos = transform.position;
            //     transform.rotation = transform.parent.rotation;
            //     transform.localPosition = pos;
            //     state = State.Null;
            //     break;
            // default:
            //     break;
        }
    }
}
