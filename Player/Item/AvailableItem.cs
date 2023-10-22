using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AvailableItem : MonoBehaviour
{
    public AudioSource AS;
    public Canvas ui;
    public AudioClip clip;
    Examine examine;
    void Start()
    {
        examine = GetComponent<Examine>();
    }


    void Update()
    {
        switch (examine.exName)
        {
            case "Nipper" :

                if(InteractObjMgr.GetInst().pickedObj == this.gameObject)
                {
                    if(Examine.exMode && Input.GetKeyDown(KeyCode.Q))
                    {
                        InventoryMgr.AddItem("Nipper");
                        Time.timeScale = 1f;
                        AS.PlayOneShot(clip);
                        GameMgr.PossibleEsc = true;
                        Examine.exMode = false;
                        ui.enabled = false;
                        Destroy(this.gameObject);

                    }
                }
                break;
        }

    }
}
