using UnityEngine;

public class Key : MonoBehaviour
{

    //[HideInInspector] 
    public Transform Player;
    FlashLight LightControl;
    [HideInInspector] public bool GetKey;

    //PlayerCotroller PS;
    //GameObject KeyObj;
    Outline OL;        
    AudioSource AS; 
    MeshRenderer rend;
    IsOpen m_IsOpen;
    PlayerGetItem getItem;

    void Start()
    {
        m_IsOpen = GetComponent<IsOpen>();
        OL = GetComponent<Outline>();      
        //KeyObj = this.gameObject;         
        GetKey = false;                  

        AS = GetComponentInParent<AudioSource>();       
        rend = GetComponent<MeshRenderer>();
        getItem = FindObjectOfType<PlayerGetItem>();
        LightControl = FindObjectOfType<FlashLight>();
        //PS = FindObjectOfType<PlayerCotroller>();
    }

    private void Update()
    {
        if (InteractObjMgr.GetInst().pickedObj == gameObject)
        {
            OL.enabled = true;
            LightControl.isOn = false;
        }
        else
        {
            OL.enabled = false;

            if (LightControl.Have)
                LightControl.isOn = true;
        }

        if (m_IsOpen.value)
        {
            InventoryMgr.AddItem("Key - 3");
            InteractObjMgr.GetInst().key_fade = true;
            getItem.HaveKey03 = true;
            AS.PlayOneShot(AS.clip);
            gameObject.SetActive(false);

            if(LightControl.Have)
                LightControl.isOn = true;
        }
    }
}
