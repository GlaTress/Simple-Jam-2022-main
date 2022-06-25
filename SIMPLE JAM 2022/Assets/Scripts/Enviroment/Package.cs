using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public delegate void onPackageDelivered();
    public static onPackageDelivered onDelivered;
    public Transform shipPosition;
    Collider col;

    public GameObject particleObject;
    private bool picked = false;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        col = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(picked)
        {
            transform.position = shipPosition.position;
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(shipPosition.rotation.x - 90,shipPosition.rotation.y,shipPosition.rotation.z),8 * Time.deltaTime);

            if(Input.GetKeyDown(KeyCode.Space))
            {
                picked = false;
                col.enabled = false;
                rb.isKinematic = false;
                rb.velocity = Vector3.zero;
                StartCoroutine("reactivateCollider");
            }
        }
    }

    private IEnumerator reactivateCollider()
    {
        yield return new WaitForSeconds(0.2f);
        col.enabled = true;

    }
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            picked = true;
        }
        if(other.CompareTag("Finish"))
        {
            onDelivered?.Invoke();
        }
    }

}
