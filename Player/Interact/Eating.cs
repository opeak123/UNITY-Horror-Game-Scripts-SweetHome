using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class Eating : MonoBehaviour
{
    public Canvas ui;
    public PostProcessVolume ppp;

    Examine examine;
    PlayerCotroller ps;
    GameMgr gameMgr;
     
    bool dizzy;
    bool realase;
    float duringTime;

    void Start()
    {
        examine = GetComponent<Examine>();
        ps = FindObjectOfType<PlayerCotroller>();
        ppp = FindObjectOfType<PostProcessVolume>();
        gameMgr = FindObjectOfType<GameMgr>();
    }


    void Update()
    {
        Sickness();
        eat();
    }


    void eat()
    {
        switch (examine.exName)
        {
            case "tunacan":

                if (InteractObjMgr.GetInst().pickedObj == this.gameObject)
                {
                    if (Examine.exMode && Input.GetKeyDown(KeyCode.Q))
                    {
                        Time.timeScale = 1f;
                        gameMgr.AS[2].PlayOneShot(gameMgr.SoundsClips[1]);

                        GameMgr.PossibleEsc = true;
                        Examine.exMode = false;
                        ui.enabled = false;
                        Hunger.Gauge *= 1.3f;
                        Destroy(this.gameObject);
                    }
                }
                break;

            case "painkiller":
                break;


            case "unknwon_drug":

                if (InteractObjMgr.GetInst().pickedObj == this.gameObject)
                {
                    if (Examine.exMode && Input.GetKeyDown(KeyCode.Q))
                    {
                        Time.timeScale = 1f;
                        gameMgr.AS[0].PlayOneShot(ps.SoundsClips[7]);
                        gameMgr.AS[1].PlayOneShot(ps.SoundsClips[8]);
                        gameMgr.AS[2].volume = 0.2f;
                        gameMgr.AS[2].PlayOneShot(gameMgr.SoundsClips[0]);
                        GameMgr.PossibleEsc = true;
                        Examine.exMode = false;
                        InteractObjMgr.GetInst().Coma = true;
                        dizzy = true;
                        ui.enabled = false;
                        ppp.isGlobal = true;
                        this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
                        this.gameObject.GetComponent<BoxCollider>().enabled = false;

                    }
                }
                break;
        }
    }
    
    void Sickness()
    {
        if (dizzy)
        {
            ps.MoveSpeed = 1f;
            ps.AS.pitch = 0.7f;
            if (ppp.weight <= 1)
            {
                duringTime += Time.deltaTime * 0.08f;
                ppp.weight = duringTime;

                if (ppp.weight >= 1)
                {
                    dizzy = false;
                    realase = true;
                }
            }
        }
        else if(realase)
        {
            duringTime += Time.deltaTime * 0.08f;

            if(duringTime >= 4.3f) // 4.3√ 
            {
                ppp.weight -= Time.deltaTime * 0.08f;

                if(ppp.weight <= 0)
                {
                    ps.AS.pitch = 1f;
                    ps.MoveSpeed = 1.8f;
                    gameMgr.AS[2].volume = 1f;
                    realase = false;
                    ppp.isGlobal = false;
                    InteractObjMgr.GetInst().Coma = false;
                    Destroy(this.gameObject);
                }
            }
        }
    }

}
