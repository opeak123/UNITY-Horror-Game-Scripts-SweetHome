using System.Collections;
using UnityEngine;

public class JumpScare1 : MonoBehaviour
{

    public GameObject Obj;
    public Animator animator;
    public PlayerCotroller PS;
    IsTriggerOn isTriggerOn;
    IEnumerator Start()
    {
        isTriggerOn = GetComponent<IsTriggerOn>();
        yield return null;

        while (true)
        {
            if (isTriggerOn.value)
            {
                Obj.SetActive(true);
                animator.Play("run",0,0);
                PS.AS3.PlayOneShot(PS.SoundsClips[3]);
                this.GetComponent<BoxCollider>().enabled = false;
                break;
            }
            yield return null;
        }
        yield return null;
        StartCoroutine("Delay");
        while (true)
        {
            if (CheckAnimationEnd.Check(animator))
            {
                Obj.SetActive(false);
                break;
            }
            yield return null;
        }
    }

    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1.5f);
        PS.AS3.PlayOneShot(PS.SoundsClips[4]);
    }

}
