using UnityEngine;

public class Drawer : MonoBehaviour
{

    Animator animator;
    int animState = 0;
    IsOpen isOpen;
    Interactable interactable;
    public AudioSource AS;
    public bool Open;



    void Start()
    {
        AS = GetComponentInParent<AudioSource>();
        interactable = GetComponent<Interactable>();
        isOpen = GetComponent<IsOpen>();
        animator = GetComponent<Animator>();
        Open = false;

        if (isOpen.value)
            animState = 1;
        else
            animState = 0;
    }

    
    void Update()
    {
        //var t = animator.GetFloat("OpenRate");
        //if (isOpen.value)
        //    t += Time.deltaTime / openTime;
        //else
        //    t -= Time.deltaTime / openTime;
        //animator.SetFloat("OpenRate", Mathf.Clamp01(t));

        //return;
        if (animState == 0) // 닫혀있는 상태
        {
            if (isOpen.value)
            {
                interactable.value = false;
                animator.Play("Open", 0, 0);

                AS.GetComponentInParent<AudioSource>().PlayOneShot(AS.clip);
                
                animState++;
            }
        }
        else if (animState == 1) // 열려있는 상태
        {
            if (CheckAnimationEnd.Check(animator))
            {
                interactable.value = true;
                animState++;
            }
        }
        else if (animState == 2)
        {
            if (!isOpen.value)
            {
                interactable.value = false;
                animator.Play("Close", 0, 0);

                AS.GetComponentInParent<AudioSource>().PlayOneShot(AS.clip);

                animState++;
            }
        }
        else if (animState == 3)
        {
            if (CheckAnimationEnd.Check(animator))
            {
                interactable.value = true;
                animState = 0;
            }
        }
    }
}
