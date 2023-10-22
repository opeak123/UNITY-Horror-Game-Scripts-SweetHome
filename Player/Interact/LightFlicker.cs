using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public GameObject LightOn;
    public GameObject LightOff;
    private float Index;

    void Update()
    {
        StartCoroutine(LightActive());
    }

    IEnumerator LightActive()
    {
        LightOn.SetActive(true);
        Index = Random.Range(0f, 6f);

        if (Index <= 0.3f)
            LightOn.SetActive(false);
        else
            LightOff.SetActive(true);
        
        LightOff.SetActive(false);
        yield return new WaitForSeconds(10);
    }
}
