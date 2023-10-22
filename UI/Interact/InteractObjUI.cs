using UnityEngine;
public class InteractObjUI : MonoBehaviour
{
    public bool isOpenUI;
    Canvas canvas;
    Transform tf;
    Camera mainCam;
    void Start()
    {
        mainCam = Camera.main;
        tf = transform;
        canvas = GetComponent<Canvas>();
    }
    void Update()
    {
        if (InteractObjMgr.GetInst().showUI)
        {
            if (!InteractObjMgr.GetInst().Coma & isOpenUI)
            {
                if (InteractObjMgr.GetInst().m_OpenUIKey.CompareTo(gameObject.name) == 0 
                    && !Examine.exMode & !LockControl.zoom)
                {
                    if (InteractObjMgr.GetInst().objIsOpened)
                        canvas.enabled = false;
                    else
                    {
                        canvas.enabled = true;
                    }
                }
                else
                    canvas.enabled = false;
            }
            else
            {
                if (InteractObjMgr.GetInst().m_CloseUIKey.CompareTo(gameObject.name) == 0)
                {
                    if (InteractObjMgr.GetInst().objIsOpened)
                        canvas.enabled = true;
                    else
                        canvas.enabled = false;
                }
                else
                    canvas.enabled = false;
            }
            tf.position = mainCam.WorldToScreenPoint(InteractObjMgr.GetInst().objPos);
        }
        else
            canvas.enabled = false;

    }
}
