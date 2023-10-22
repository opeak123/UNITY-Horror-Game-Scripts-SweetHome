using System.Collections;
using UnityEngine;
using System;

public class WheelRotate : MonoBehaviour
{
    public static event Action<string, int> Rotated = delegate { };
    [SerializeField]PlayerCotroller ps;
    bool coroutineAllowed;
    int numberShown;

    private void Start()
    {
        ps = FindObjectOfType<PlayerCotroller>();
        coroutineAllowed = true;
        numberShown = 0;
    }

    private void OnMouseDown()
    {
        if (coroutineAllowed && !LockControl.padOpen)
            StartCoroutine(wheelRotate());
    }

    IEnumerator wheelRotate()
    {
        coroutineAllowed = false;

        for (int i = 0; i <= 11; i++)
        {
            transform.Rotate(-3f, 0, 0);
            yield return new WaitForSeconds(0.01f);
        }


        coroutineAllowed = true;
        numberShown += 1;

        if (!ps.AS3.isPlaying)
            ps.AS3.PlayOneShot(ps.SoundsClips[2]);

        if (numberShown > 9)
        {
            numberShown = 0;
        }

        Rotated(name,numberShown);
    }
}
