#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
public class DebugColliderMeshMenu
{
    [MenuItem("Custom/ShowColliderMesh")]
    public static void Show()
    {
        SetActive(true);
    }
    [MenuItem("Custom/HideColliderMesh")]
    public static void Hide()
    {
        SetActive(false);
    }
    public static void SetActive(bool bActive)
    {
        var arr = GameObject.FindObjectsOfType<DisableMeshRenderer>(true);
        foreach (var v in arr)
        {
            v.GetComponent<MeshRenderer>().enabled = bActive;
        }
    }
}
#endif