using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTrap : MonoBehaviour
{
    public GameObject[] lights;
    AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponentInParent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        lights[0].GetComponent<LightFlicker>().enabled = false;
        lights[1].gameObject.SetActive(true);
        lights[2].gameObject.SetActive(false);
        audioSource.PlayOneShot(audioSource.clip);
    }
    private void OnTriggerExit(Collider other)
    {
        this.gameObject.SetActive(false);
    }
}
