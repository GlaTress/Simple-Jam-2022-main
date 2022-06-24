using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroids : MonoBehaviour
{
    public Transform asteroids;
    public int Radius = 100;
    public int count = 500;
    void Start()
    {
        for (int loop=0; loop < count; loop++)
        {

            Transform temp = Instantiate(asteroids, Random.insideUnitSphere * Radius, Random.rotation);
            temp.localScale = temp.localScale * Random.Range(0.5f, 5);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
