using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingController : MonoBehaviour
{

    public enum RotationAxes
    {
        MouseXAndY = 0,
        MouseX = 1,
        MouseY = 2
    }
    public float speed = 5;
    public float velocityOffset = 1.0f;

    public float minimumVert = -90.0f;
    public float maximumVert = 90.0f;

    private float verticalRot = 0;
    public FixedJoystick joystick;

    void Start()
    {

        //Cursor.lockState = CursorLockMode.Locked;
        // Make the rigid body not change rotation
        Rigidbody body = GetComponent<Rigidbody>();
        if (body != null)
        {
            body.freezeRotation = true;
        }
        joystick = FindObjectOfType<FixedJoystick>();
    }

    void Update()
    {
        verticalRot -= -joystick.Vertical;
        verticalRot = Mathf.Clamp(verticalRot, minimumVert, maximumVert);

        float delta = joystick.Horizontal;
        float horizontalRot = transform.localEulerAngles.y + delta;
        float randomOffset = Random.Range(-velocityOffset, velocityOffset);
        transform.localEulerAngles = new Vector3(verticalRot, horizontalRot, 0);
        gameObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * speed;


    }
}
