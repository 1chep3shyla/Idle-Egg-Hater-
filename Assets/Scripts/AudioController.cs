using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public AudioSource hitFx;
    public AudioClip hitFxClip;

    public void hit()
    {
        float random = Random.Range(1.15f, 1.2f);
        hitFx.pitch = random;
        hitFx.PlayOneShot(hitFxClip);
    }
}
