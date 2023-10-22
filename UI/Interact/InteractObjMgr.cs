using UnityEngine;
public class InteractObjMgr : MonoBehaviour
{
    public Vector3 objPos;
    public bool objIsOpened;
    public bool showUI;
    public bool interactable;
    public GameObject pickedObj;
    public string m_OpenUIKey;
    public string m_CloseUIKey;
    public KeyCode m_InteractInputKey;
    public bool key_fade;
    public bool flash_fade;
    public bool GameStop;
    public bool Coma;
    Camera mainCam;



    


    static InteractObjMgr inst;
    public static InteractObjMgr GetInst()
    {
        if (inst == null)
            inst = FindObjectOfType<InteractObjMgr>();
        return inst;
    }
}
