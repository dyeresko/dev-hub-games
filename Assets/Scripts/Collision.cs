using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Collision : MonoBehaviour
{
    public Jooystick joystick;
    public WindButton windButton;
    public FIreButton fireButton;
    public IceButton iceButton;
    public DoneButton doneButton;
    public ShootButton shootButton;
    private Collider[] hitColliders;
    private FlyingController flyingController;
    private int pieces;
    public float blastRadius;
    public float explosionPower;
    private Arms arms;
    private Player player;
    private MouseLook mouseLook;
    private FPSInput fpsInput;
    public LayerMask explosionLayers;
    private Camera mainCamera;
    public Vector3 armsPosition;
    private GameManager gameManager;
    public int hp = 1000;
    public Healthbar healthBar;
    private Shoot shoot;
    private MouseLook mouseLookY;


    private void Start()
    {
        mainCamera = GetComponentInChildren<Camera>();
        arms = FindObjectOfType<Arms>();
        flyingController = GetComponent<FlyingController>();
        player = FindObjectOfType<Player>();
        mouseLook = player.GetComponent<MouseLook>();
        fpsInput = player.GetComponent<FPSInput>();
        gameManager = FindObjectOfType<GameManager>();
        pieces = gameManager.maxPieces;
        healthBar = FindObjectOfType<Healthbar>();
        shoot = player.GetComponent<Shoot>();
        mouseLookY = mainCamera.GetComponent<MouseLook>();


    }
    private void OnCollisionEnter(UnityEngine.Collision col)
    {


        flyingController.enabled = false;
        mainCamera.transform.parent = player.gameObject.transform;
        mainCamera.transform.localPosition = Vector3.zero;
        mainCamera.transform.localEulerAngles = Vector3.zero;

        armsPosition = arms.transform.localPosition;
        arms.transform.parent = mainCamera.transform;
        arms.transform.localPosition = armsPosition;

        mainCamera.transform.localEulerAngles = Vector3.zero;

        fpsInput.enabled = true;
        mouseLook.enabled = true;
        mouseLookY.enabled = true;


        shoot.windButton.gameObject.SetActive(true);
        shoot.fireButton.gameObject.SetActive(true);
        shoot.iceButton.gameObject.SetActive(true);
        shoot.doneButton.gameObject.SetActive(true);
        shoot.joystick.gameObject.SetActive(true);
        shoot.shootButton.gameObject.SetActive(true);

        DestroyPoint(col.contacts[0].point);
        Destroy(this.gameObject);
        gameManager.CountHP();
        healthBar.UpdHealthBar(hp, gameManager.hpRemaining);



    }

    void DestroyPoint(Vector3 explosionPoint)
    {
        hitColliders = Physics.OverlapSphere(explosionPoint, blastRadius, explosionLayers);
        foreach (Collider hitCol in hitColliders)
        {
            if (hitCol.GetComponent<Rigidbody>() == null)
            {
                hitCol.GetComponent<MeshRenderer>().enabled = true;
                hitCol.gameObject.AddComponent<Rigidbody>();

                hitCol.GetComponent<Rigidbody>().mass = 500;
                hitCol.GetComponent<Rigidbody>().isKinematic = false;
                hitCol.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 5;
                hitCol.GetComponent<Rigidbody>().AddExplosionForce(explosionPower, explosionPoint, blastRadius, 1, ForceMode.Impulse);

                Destroy(this.gameObject);
                gameManager.pieces--;

            }
        }
    }
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {

    }
}
