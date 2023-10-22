using UnityEngine;
public class FlashLight : MonoBehaviour
{
    PlayerCotroller PS;
    AudioSource AS;
    [HideInInspector] public Canvas m_ui; //    [F]flashlight
    [HideInInspector] public bool isOn;
    [HideInInspector] public bool Have;

    private void Start()
    {
        AS = GetComponentInParent<AudioSource>();
        PS = FindObjectOfType<PlayerCotroller>();
        Have = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        this.gameObject.GetComponent<Outline>().enabled = true;

        m_ui.enabled = true;
        m_ui.transform.position = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
    }

    private void OnTriggerStay(Collider col)
    {
        m_ui.transform.position = Camera.main.WorldToScreenPoint(this.gameObject.transform.position);
        if (col.gameObject.tag == "Player")
        {
            m_ui.enabled = true;
            if (isOn)
                m_ui.enabled = false;
            
            if (Input.GetKey(KeyCode.F))
            {
                if (!isOn && !AS.isPlaying)
                {
                    InventoryMgr.AddItem("FlashLight");
                    InteractObjMgr.GetInst().flash_fade = true;
                    isOn = true;
                    this.gameObject.SetActive(false);
                    AS.PlayOneShot(AS.clip);
                    m_ui.enabled = false;
                    Have = true;
                }
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        m_ui.enabled = false;
        this.gameObject.GetComponent<Outline>().enabled = false;
    }
}
