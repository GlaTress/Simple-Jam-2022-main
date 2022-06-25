using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Ship_Control : MonoBehaviour
{   
    public delegate void onPackageDelivered();
    public static onPackageDelivered onDelivered;

    public delegate void onExitSafeZone();
    public static onExitSafeZone leftZone;

    public delegate void onReturnSafeZone();
    public static event onReturnSafeZone onReturned;
    private Rigidbody rb;
    private bool clicked = false;

    [SerializeField]
    private float maxSpeed = 10;
    [SerializeField]
    private float xSensitivity,ySensitivity;

    Vector3 nextRotation;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            clicked = true;
        }
        if(Input.GetMouseButtonUp(0))
        {
            clicked = false;
        }

        if(rb.velocity.magnitude > maxSpeed)
        {
            rb.velocity =Vector3.ClampMagnitude(rb.velocity,maxSpeed);
            
        }
        RotateShip();

        

    }

    void FixedUpdate()
    {
        if(clicked)
        {
            GoForward();
        }
    }

    private void GoForward()
    {
        rb.AddForce(transform.forward * 10);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void RotateShip()
    {
        if(Input.GetKey(KeyCode.W))
        {
            nextRotation.x += xSensitivity * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            nextRotation.x -= xSensitivity * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A))
        {
            nextRotation.y -= xSensitivity * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D))
        {
            nextRotation.y += xSensitivity * Time.deltaTime;
        }
        nextRotation.x = Mathf.Clamp(nextRotation.x,-90,90);
        transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.Euler(nextRotation),5 * Time.deltaTime);

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Package"))
        {
            onDelivered?.Invoke();
        }

        if(other.CompareTag("Zone"))
        {
            onReturned?.Invoke();
        }
    }

    void OnTriggerExit(Collider other)
    {
        if(other.CompareTag("Zone"))
        {
            leftZone?.Invoke();
            Debug.Log("Exit UWU");
        }
    }
}
