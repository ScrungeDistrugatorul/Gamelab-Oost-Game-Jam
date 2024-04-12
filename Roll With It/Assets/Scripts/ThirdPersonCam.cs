using System;
using Cinemachine;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public float rotationSpeed;
    public CinemachineFreeLook cinemachine;

    private void Start()
    {
        cinemachine.m_XAxis.m_MaxSpeed *= PlayerPrefs.GetFloat("sens");
        cinemachine.m_YAxis.m_MaxSpeed *= PlayerPrefs.GetFloat("sens");
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = viewDir.normalized;
        
    //     // //rotate player (change whats needed)
    //     float horizontalInput = Input.GetAxis("Horizontal");
    //     float verticalInput = Input.GetAxis("Vertical");
    //     Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;
    //     
    //     if (inputDir != Vector3.zero)
    //     {
    //         playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
    //     }
    }
}
