using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Package : MonoBehaviour
{
    public Transform shipPosition;

    public GameObject particleObject;
    private bool picked = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(picked)
        {
            transform.position = shipPosition.position;
            transform.rotation = Quaternion.Lerp(transform.rotation,Quaternion.Euler(shipPosition.rotation.x - 90,shipPosition.rotation.y,shipPosition.rotation.z),8 * Time.deltaTime);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            picked = true;
        }
    }
}
