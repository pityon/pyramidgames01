using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    private const float Y_ANGLE_MIN = 30.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;
    public float distance = 5.0f;

    private float currentX = 0.0f;
    private float currentY = 45.0f;
    // private float sensitivityX = 20.0f;
    // private float sensitivityY = 20.0f;

    GameObject player1;

    private void Start()
    {
        camTransform = transform;
        player1 = GameObject.Find("Astronaut");
    }

    private void Update()
    {
        Vector3 playerRotation = player1.transform.eulerAngles;
        currentX = playerRotation.y;
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
