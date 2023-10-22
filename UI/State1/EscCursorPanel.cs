using UnityEngine;
public class EscCursorPanel : MonoBehaviour
{
    Transform m_Tf;
    Canvas m_ParentCanvas;
    void Start()
    {
        m_ParentCanvas = transform.parent.GetComponent<Canvas>();
        m_Tf = transform;
    }
    void Update()
    {
        if(m_ParentCanvas.enabled)
            m_Tf.position = Input.mousePosition;
    }
}
