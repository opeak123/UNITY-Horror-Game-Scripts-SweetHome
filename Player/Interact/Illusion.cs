using UnityEngine;

public class Illusion : MonoBehaviour
{
    PlayerCotroller PS;
    Animator ani;
    public AudioSource AS;
    public GameObject Obj;

    void Start()
    {
        PS = FindObjectOfType<PlayerCotroller>();
        ani = GetComponentInChildren<Animator>();
        AS = GetComponent<AudioSource>();
        Obj.SetActive(false);
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.gameObject.tag == "Player")
        {
            Obj.SetActive(true);
            AS.PlayOneShot(AS.clip);
            ani.SetTrigger("thunder");
            ani.SetTrigger("head");

            if(PS.Light)
            {
                PS.Light.SetActive(false);
                PS.ON = false;
            }
            PS.Light.SetActive(false);

        }
    }

    private void OnTriggerExit(Collider other)
    {
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
        Obj.SetActive(false);
    }

}
