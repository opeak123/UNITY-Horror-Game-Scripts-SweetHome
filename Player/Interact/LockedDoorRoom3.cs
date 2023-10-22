using UnityEngine;

public class LockedDoorRoom3 : MonoBehaviour
{
    AudioSource AS;
    IsOpen isOpen;
    void Start()
    {
        AS = GetComponent<AudioSource>();
        isOpen = GetComponent<IsOpen>();
    }

    void Update()
    {
        if (isOpen.value && InteractObjMgr.GetInst().pickedObj == this.gameObject)
        {
            if (!AS.isPlaying)
                AS.PlayOneShot(AS.clip);

            isOpen.value = false;
        }

    }
}
