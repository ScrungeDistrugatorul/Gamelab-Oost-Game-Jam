using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallOrientation : MonoBehaviour
{
    public enum State
    {
        Grounded,
        Air,
        Null
    }

    public State state;

    private void Update()
    {
        switch (state)
        {
            case(State.Grounded):
                transform.rotation = Quaternion.identity;
                break;
            case(State.Air):
                Vector3 pos =  transform.position;
                transform.rotation = transform.parent.rotation;
                transform.localPosition = pos;
                state = State.Null;
                break;
            default:
                break;
        }
    }
}
