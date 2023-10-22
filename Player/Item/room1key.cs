using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class room1key : MonoBehaviour
{
    IsOpen isOpen;
    Interactable interactable;
    Outline outline;
    AudioSource AS;
    BoxCollider boxCollider;
    void Start()
    {
        outline = GetComponent<Outline>();
        isOpen = GetComponent<IsOpen>();
        interactable = GetComponent<Interactable>();
        AS = GetComponentInParent<AudioSource>();
        boxCollider = GetComponent<BoxCollider>();
    }


    void Update()
    {
        //if(!LockControl.padOpen)
        //{
        //    isOpen.value = false;
        //    interactable.value = false;
        //}

    }
}
