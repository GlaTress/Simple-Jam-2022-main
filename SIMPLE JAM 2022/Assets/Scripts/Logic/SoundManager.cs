using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private static AudioSource source1;
    private static AudioClip Crash, Drop,Pickup;
    // Start is called before the first frame update
    void Start()
    {
        source1 = GetComponent<AudioSource>();

        Crash = Resources.Load<AudioClip>("Crash");
        Drop = Resources.Load<AudioClip>("Drop");
        Pickup = Resources.Load<AudioClip>("Pickup");
    }

    public static void PlaySound(string name)
    {
        switch(name)
        {
            case"Crash":
            source1.PlayOneShot(Crash);
            break;
            case"Drop":
            source1.PlayOneShot(Drop);
            break;
            case"Pickup":
            source1.PlayOneShot(Pickup);
            break;
            default:
            break;

        }
    }
}
