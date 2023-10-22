using UnityEngine;

public class LockControl : MonoBehaviour
{
    private int[] result, correctCombination;
    public Camera[] cam;
    public static bool padOpen;
    public static bool zoom;
    PlayerCotroller ps;
    IsOpen isopen;
    Animator animator;

    private void Start()
    {
        ps = FindObjectOfType<PlayerCotroller>();
        isopen = GetComponent<IsOpen>();
        animator = GetComponentInChildren<Animator>();
        padOpen = false;
        zoom = false;
        result = new int[] { 0, 0, 0 };
        correctCombination = new int[] { 2, 4, 3 };
        WheelRotate.Rotated += CheckResults;
    }

    private void Update()
    {
        interact();
    }

    private void CheckResults(string wheelName, int numer)
    {
        switch (wheelName)
        {
            case "wheel1":
                result[0] = numer;
                break;

            case "wheel2":
                result[1] = numer;
                break;

            case "wheel3":
                result[2] = numer;
                break;

        }
        if (result[0] == correctCombination[0] && result[1] == correctCombination[1] &&
            result[2] == correctCombination[2])
        {
            this.gameObject.GetComponent<LockControl>().enabled = false;
            animator.Play("briefCase");
            ps.AS3.PlayOneShot(ps.SoundsClips[9]);
            padOpen = true;
            cam[0].enabled = true;
            cam[1].enabled = false;
            ps.enabled = true;

            //if (padOpen)
            //    gameObject.GetComponent<BoxCollider>().enabled = false;
        }
        else
            padOpen = false;
        
        
    }
    void OnDestroy()
    {
        WheelRotate.Rotated -= CheckResults;
    }

    void interact()
    {
        if (InteractObjMgr.GetInst().pickedObj == this.isopen.gameObject)
        {
            if (Input.GetMouseButtonDown(1) | Input.GetKeyDown(KeyCode.B))
            {
                cam[0].enabled = true;
                cam[1].enabled = false;
                ps.enabled = true;
                zoom = false;
            }
        }

        if (InteractObjMgr.GetInst().pickedObj == this.isopen.gameObject)
        {
            if (!InteractObjMgr.GetInst().Coma & !LockControl.padOpen && Input.GetKeyDown(KeyCode.E))
            {
                cam[0].enabled = false;
                cam[1].enabled = true;
                ps.enabled = false;
                zoom = true;
            }
        }
    }
}
