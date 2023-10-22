using UnityEngine;

public class Door : MonoBehaviour
{
    public PlayerCotroller PS;
    public AudioSource AS;
    public AudioClip[] Clips;
    public GameObject UI;
    public Animator animator;
    public Key HaveKey;
    Interactable interactable;
    InteractUIPos IU;

    public bool DoorOpen;
    IsOpen isOpen;
    int aniState = 0;
    void Start()
    {
        interactable = GetComponent<Interactable>();
        isOpen = GetComponent<IsOpen>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (aniState == 0)
        {
            if (isOpen.value && InventoryMgr.ContainsItem("Key - 3"))
            {
                AS.volume = 0.5f;
                AS.PlayOneShot(Clips[0]);
                animator.Play("OpenDoor");
                interactable.value = false;
                aniState++;
            }
            else if (isOpen.value && !InventoryMgr.ContainsItem("Key - 3"))
            {
                isOpen.value = false;
                if(!AS.isPlaying)
                    AS.PlayOneShot(Clips[1]);
                animator.Play("ClosedDoor");
            }
        }

        else if(aniState == 1)
        {
            this.gameObject.GetComponent<IsOpen>().enabled = false;
            this.gameObject.GetComponent<InteractUIPos>().enabled = false;
        }
    }
}
