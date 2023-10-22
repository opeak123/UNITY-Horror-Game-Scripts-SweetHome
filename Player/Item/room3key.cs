using UnityEngine;

public class room3key : MonoBehaviour
{
    //Drawer drawer;
    //IsOpen rootOpen;


    IsOpen isOpen;
    Outline outline;
    MeshRenderer mesh;
    Interactable interactable;
    PlayerGetItem getitem;
    FlashLight fl;
    AudioSource AS;

    private void Start()
    {
        interactable = GetComponentInParent<Interactable>();
        mesh = GetComponent<MeshRenderer>();
        //drawer = GetComponentInParent<Drawer>();
        isOpen = GetComponentInParent<IsOpen>();
        outline = GetComponent<Outline>();
        //rootOpen = GetComponentInParent<RootTag>().GetComponent<IsOpen>();
        fl = FindObjectOfType<FlashLight>();
        getitem = FindObjectOfType<PlayerGetItem>();
        AS = GetComponentInParent<AudioSource>();
    }
    
    void Update()
    {
        if (InteractObjMgr.GetInst().pickedObj == this.gameObject)
        {
            outline.enabled = true;

            fl.isOn = false;
        }

        else if(!InteractObjMgr.GetInst().pickedObj == this.gameObject)
        {
            outline.enabled = false;

            if (fl.Have)
                fl.isOn = true;
        }

        if (isOpen.value)
        {
            getitem.HaveKey02 = true;
            InventoryMgr.AddItem("Master Key");
            InteractObjMgr.GetInst().key_fade = true;
            AS.PlayOneShot(AS.clip);
            gameObject.SetActive(false);

            if(getitem.HaveKey02 && fl.Have)
                fl.isOn = true;
        }
    }
}
