using UnityEngine;

public class room2key : MonoBehaviour
{
    IsOpen isOpen;
    AudioSource AS;
    Animator animator;
    PlayerGetItem getItem;
    public AudioClip[] clips;
    int aniState;
    Interactable interactable;

    void Start()
    {
        aniState = 0;
        getItem = FindObjectOfType<PlayerGetItem>();
        isOpen = GetComponent<IsOpen>();
        AS = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        interactable = GetComponent<Interactable>();
    }

    void Update()
    {
        if (aniState == 0)
        {
            if (isOpen.value && InventoryMgr.ContainsItem("Master Key"))
            {
                AS.PlayOneShot(clips[0]);
                getItem.HaveKey02 = true;
                animator.Play("OpenDoor");
                interactable.value = false;
                aniState++;
            }
            else if (isOpen.value && !InventoryMgr.ContainsItem("Master Key"))
            {
                isOpen.value = false;
                if (!AS.isPlaying)
                    AS.PlayOneShot(clips[2]);
                animator.Play("DoorLocked");
            }
        }
        else if(aniState == 1)
        {
            if (CheckAnimationEnd.Check(animator))
            {
                interactable.value = true;
                aniState++;
            }
        }

        else if (aniState == 2)
        {
            if (!isOpen.value && InventoryMgr.ContainsItem("Master Key"))
            {
                AS.PlayOneShot(clips[1]);
                animator.Play("ClosedDoor");
                interactable.value = false;
                aniState++;
            }
        }
        else if (aniState == 3)
        {
            if (CheckAnimationEnd.Check(animator))
            {
                interactable.value = true;
                aniState =0;
            }
        }
    }
}
