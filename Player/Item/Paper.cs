using UnityEngine;
public class Paper : MonoBehaviour
{
    [HideInInspector] public Canvas m_read;
    [HideInInspector] public Canvas m_ui;
    [HideInInspector] public Canvas paper;
    [HideInInspector] public Canvas memo;
    [HideInInspector] public Canvas cursor;

    private void OnTriggerEnter(Collider other)
    {
        if (!InteractObjMgr.GetInst().Coma)
        {
            this.gameObject.GetComponent<Outline>().enabled = true;
            m_read.enabled = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        m_read.transform.position = Camera.main.WorldToScreenPoint
        (this.gameObject.transform.position);

        if (!InteractObjMgr.GetInst().Coma && Input.GetKey(KeyCode.R))
        {
            this.gameObject.GetComponent<MeshRenderer>().enabled = false;
            m_read.enabled = false;
            paper.enabled = true;
            m_ui.enabled = true;
            memo.enabled = true;
            cursor.enabled = false;
        }

        if (Input.GetMouseButtonDown(1) | Input.GetKey(KeyCode.B))
        {
            m_read.enabled = true;
            paper.enabled = false;
            m_ui.enabled = false;
            memo.enabled = false;
            cursor.enabled = true;
            this.gameObject.GetComponent<MeshRenderer>().enabled = true;
            paper.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
        }
        PaperRotate();
    }
    private void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<MeshRenderer>().enabled = true;
        this.gameObject.GetComponent<Outline>().enabled = false;
        m_read.enabled = false;
        m_ui.enabled = false;
        paper.enabled = false;
        memo.enabled = false;
        cursor.enabled = true;
        paper.transform.rotation = Quaternion.Euler(0f, 0f, 0f);
    }
    void PaperRotate()
    {
        if(Input.GetKey(KeyCode.Q))
            paper.transform.Rotate(new Vector3(0, 0, -10 * Time.deltaTime));
        
        if(Input.GetKey(KeyCode.E))
            paper.transform.Rotate(new Vector3(0, 0, 10 * Time.deltaTime));
    }
}
