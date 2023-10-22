using UnityEngine;
public class NullException : MonoBehaviour
{
    void Start()
    {
        GameObject go = GameObject.Find("wibble");
        if (go)
            Debug.Log(go.name);
        
        else
            Debug.Log("No game object called wibble found");
    }
}