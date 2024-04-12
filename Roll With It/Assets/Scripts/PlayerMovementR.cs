using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementR : MonoBehaviour
{
    //Movement elements:
    [SerializeField] private float speed;
    [SerializeField] private float jumpStrength;
    private float HorizontalSpeed;
    private float VerticalSpeed;
    [NonSerialized] public Vector3 move;
    
    [NonSerialized] public Rigidbody rb;
    [NonSerialized] public Vector3 floorNormal;

    [SerializeField] private float groundDrag;
    [SerializeField] private float airDrag;
    [SerializeField] private LayerMask IsGround;
    [SerializeField] private float GroundCheckRad;

    public int trashAmount = 0;

    public Camera camera;

    private BallOrientation orientation;

    private void Awake()
    {
        orientation = GetComponentInChildren<BallOrientation>();
    }

    private void Start()
    {
        rb = transform.GetComponent<Rigidbody>();
    }

    private void Update()
    {      
        HorizontalSpeed = Input.GetAxisRaw("Horizontal");
        VerticalSpeed = Input.GetAxisRaw("Vertical");
        move = new Vector3(HorizontalSpeed, 0, VerticalSpeed);

        if (Input.GetKeyDown(KeyCode.Space) && OnGround())
        {
            Vector3 forward = Vector3.Cross(camera.transform.right, floorNormal);
            rb.AddForce(floorNormal * jumpStrength);
        }

        // if (Input.GetKeyDown("r"))
        // {
        //     DebugReset();
        // }
        //
        // if (Input.GetKeyDown("1"))
        // {
        //     DebugScale(0.2f);
        // }
        // if (Input.GetKeyDown("2"))
        // {
        //     DebugScale(-0.2f);
        // }


    }

    private void FixedUpdate()
    {
        // rb.AddForce(move.normalized * speed, ForceMode.Acceleration);
        rb.drag = OnGround() ? groundDrag : airDrag;
        SMBMove(camera.transform.right);
    }

    private void SMBMove(Vector3 pRight)
    //TODO: Make player move faster down slope
    {
        if (!OnGround()) return;
        
        CalculateFloorNormal();

        // if (move.magnitude == 0 && rb.velocity.magnitude > 0)
        // {
        //     // rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, speed * -1.2f * Time.deltaTime);
        // }
        // else
        if (move.magnitude != 0)
        {
            Vector3 forward = Vector3.Cross(pRight, floorNormal);

            Vector3 forwardForce = speed * move.z * forward;
            Vector3 rightForce = speed * move.x * pRight;
            Vector3 forceVec = forwardForce + rightForce;
            
            rb.AddForce(forceVec);
        }
    }

    public bool OnGround()
    {
        return Physics.CheckSphere(transform.position - (Vector3.up * 0.5f), GroundCheckRad, IsGround);
    }

    private void CalculateFloorNormal()
    {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.down, out hit, Mathf.Infinity, IsGround))
        {
            floorNormal = hit.normal;
        }
    }

    private void DebugReset()
    {
        transform.position = Vector3.zero;
    }

    public void DebugScale(float scaleChange)
    {
        transform.localScale += Vector3.one * scaleChange;
    }

    public void ResetScale()
    {
        transform.localScale = Vector3.one;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Respawn"))
            DebugReset();
    }
}
