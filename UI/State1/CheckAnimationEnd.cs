using UnityEngine;
public class CheckAnimationEnd
{
    public static bool Check(Animator anim)
    {
        if (anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
            return true;
        return false;
    }
}
