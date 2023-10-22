using UnityEngine;
public class DisableMeshRenderer : MonoBehaviour
{
    void Awake()
    {
        GetComponent<MeshRenderer>().enabled = false;
    }
}
