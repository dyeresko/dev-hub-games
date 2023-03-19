using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    private FPSInput fpsInput;
    private MouseLook mouseLook;
    private MouseLook mouseLookY;
    private Vector3 cameraPositionToMove;
    public Camera mainCamera;

    public JoystickScript joystick;
    public WindButton windButton;
    public FireButton fireButton;
    public IceButton iceButton;
    public ShootButton shootButton;
    private Arms arms;
    public GameObject projectile;
    public Transform point;
    private Animator animator;
    public bool isAvailable = true;
    public float CooldownDuration = 1.0f;
    public Vector3 armsPosition;


    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        arms = GetComponentInChildren<Arms>();
        fpsInput = GetComponent<FPSInput>();
        mouseLook = GetComponent<MouseLook>();
        mouseLookY = mainCamera.GetComponent<MouseLook>();

    }
    public void ShootP()
    {
        if (isAvailable)
        {
            animator.SetBool("IsFired", true);
            Invoke(nameof(ShootProjectile), 2);

        }
    }
    void ShootProjectile()
    {
        if (isAvailable == false)
        {
            return;
        }
        GameObject ball = (GameObject)Instantiate(projectile, point.transform.position, Quaternion.identity);


        mainCamera.transform.parent = ball.transform;
        cameraPositionToMove = new Vector3(mainCamera.transform.position.x, mainCamera.transform.position.y, mainCamera.transform.position.z);

        cameraPositionToMove -= 5 * transform.forward;
        mainCamera.transform.position = cameraPositionToMove;

        armsPosition = arms.transform.localPosition;
        arms.transform.parent = this.transform;
        arms.transform.localPosition = armsPosition;
        arms.transform.localEulerAngles = Vector3.zero;

        fpsInput.enabled = false;
        mouseLook.enabled = false;
        mouseLookY.enabled = false;

        windButton.gameObject.SetActive(false);
        fireButton.gameObject.SetActive(false);
        iceButton.gameObject.SetActive(false);
        joystick.gameObject.SetActive(false);
        shootButton.gameObject.SetActive(false);


        StartCoroutine(StartCooldown());
    }


    public IEnumerator StartCooldown()
    {
        isAvailable = false;
        yield return new WaitForSeconds(CooldownDuration);
        animator.SetBool("IsFired", false);
        isAvailable = true;

    }
    public void ChangeProjectile(GameObject newProjectile)
    {
        projectile = newProjectile;
    }
}
