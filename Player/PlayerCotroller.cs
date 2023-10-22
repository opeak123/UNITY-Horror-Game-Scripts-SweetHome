using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerCotroller : MonoBehaviour
{
    Transform PlayerTR;
    Transform CameraTR;
    Rigidbody PlayerRB;
    public Slider m_stemina;
    public bool run;
    [Range(0,5)]public float MoveSpeed;
    private float h = 0f, v = 0f;
    float shape = 10.0f;

    [Space] public AudioClip[] SoundsClips;

    [HideInInspector] public FlashLight flashlight;
    [HideInInspector] public GameObject Light;

    [Space][Header("AudioSource")]
    public AudioSource AS;
    public AudioSource AS2;
    public AudioSource AS3;
    [HideInInspector] public bool ON;
    Camera mainCam;
    CapsuleCollider col;
    List<RaycastHit> hitList = new List<RaycastHit>();


    void Start()
    {
        col = GetComponent<CapsuleCollider>();
        mainCam = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        flashlight = FindObjectOfType<FlashLight>();
        PlayerTR = GetComponent<Transform>();
        CameraTR = GetComponentInChildren<Transform>();
        PlayerRB = GetComponent<Rigidbody>();
        AS = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Time.timeScale == 0)
            return;
        PlayerRotate();
        FootstepSound();
        OnFlash();
        InteractObj();
        CheckTrigger();
    }
    void FixedUpdate()
    {
        if (Time.timeScale == 0)
            return;

        PlayerMove();
    }

    void CheckTrigger()
    {
        var bounds = col.bounds;
        var hits = Physics.OverlapBox(bounds.center, bounds.extents);
        for(int i=0;i<hits.Length;i++)
        {
            var hit = hits[i];
            var isTriggerOn = hit.GetComponent<IsTriggerOn>();
            if(isTriggerOn != null)
            {
                isTriggerOn.value = true;
            }
        }
    }
    void InteractObj()
    {
        if (mainCam)
        {
            Ray ray = mainCam.ScreenPointToRay(new Vector3(Screen.width/2f,Screen.height/2f));
            hitList.Clear();
            hitList.AddRange(Physics.RaycastAll(ray, 1.1f));
            hitList.Sort((a,b)=>a.distance.CompareTo(b.distance));
            
            bool noPick = true;

            for (int i = 0; i < hitList.Count; i++)
            {
                var hit = hitList[i];
                if (hit.collider.gameObject == gameObject)
                    continue;
                
                bool bInteractable = true;
                var interactable = hit.collider.GetComponentInParent<Interactable>();
                if (interactable != null)
                    bInteractable = interactable.value;
                var isOpen = hit.collider.GetComponentInParent<IsOpen>();

                if (isOpen != null && bInteractable)
                {
                    var toolTipKey = hit.collider.GetComponentInParent<InteractToolTipKey>();
                    if(toolTipKey != null)
                    {
                        InteractObjMgr.GetInst().m_OpenUIKey = toolTipKey.m_OpenKey;
                        InteractObjMgr.GetInst().m_CloseUIKey = toolTipKey.m_CloseKey;
                    }
                    InteractObjMgr.GetInst().showUI = true;
                    InteractObjMgr.GetInst().objIsOpened = isOpen.value;
                    InteractObjMgr.GetInst().objPos = isOpen.transform.position;
                    var uiPos = hit.collider.GetComponentInParent<InteractUIPos>();
                    if (uiPos != null)
                        InteractObjMgr.GetInst().objPos += uiPos.value;

                    InteractObjMgr.GetInst().interactable = true;
                    InteractObjMgr.GetInst().pickedObj = isOpen.gameObject;

                    var interactInputKey = hit.collider.GetComponent<InteractInputKey>();
                    if (interactInputKey != null)
                        InteractObjMgr.GetInst().m_InteractInputKey = interactInputKey.m_Value;
                    else
                        InteractObjMgr.GetInst().m_InteractInputKey = KeyCode.E;

                    noPick = false;
                }
                break;
            }
            if(noPick)
            {
                InteractObjMgr.GetInst().showUI = false;
                InteractObjMgr.GetInst().interactable = false;
                InteractObjMgr.GetInst().pickedObj = null;
            }

        }

        if (Input.GetKeyDown(InteractObjMgr.GetInst().m_InteractInputKey))
        {
            if(InteractObjMgr.GetInst().interactable)
            {
                if(InteractObjMgr.GetInst().pickedObj != null)
                {
                    var isOpen = InteractObjMgr.GetInst().pickedObj.GetComponentInParent<IsOpen>();
                    if(isOpen != null)
                    {
                        isOpen.value = !isOpen.value;
                    }
                }
            }
        }
    }

    void PlayerMove()
    {
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");
        PlayerTR.Translate(Vector3.forward * MoveSpeed * v * Time.deltaTime);
        PlayerTR.Translate(Vector3.right * MoveSpeed * h * Time.deltaTime);

        if (Input.GetKey(KeyCode.LeftShift) && m_stemina.value >= 0.1)
        {
            MoveSpeed = 2.5f;
            run = true;
        }
        else
        {
            MoveSpeed = 1.8f;
            run = false;
        }
    }


    void PlayerRotate()
    {
        Vector2 mouseDelta = new Vector2(Input.GetAxis("Mouse X"),
            Input.GetAxis("Mouse Y"));

        Vector3 CamAngle = CameraTR.rotation.eulerAngles;

        float x = CamAngle.x - mouseDelta.y;
        float y = CamAngle.y + mouseDelta.x;

        if (x < 180f)
        {
            x = Mathf.Clamp(x, -1f, 70f);
        }
        else
        {
            x = Mathf.Clamp(x, 335f, 360f);
        }

        Vector3 rot = Vector3.Scale(CameraTR.transform.forward, new Vector3(1f, 0f, 1f));
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(rot), Time.deltaTime * shape);
        CameraTR.rotation = Quaternion.Euler(x, y, CamAngle.z);
    }
    
    void FootstepSound()
    {
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out RaycastHit hit, 20f))
        {
            switch (hit.transform.gameObject.layer)
            {
                case 8: // floor wood

                    if (Input.GetButton("Horizontal") || Input.GetButton("Vertical"))
                    {
                        if (!AS.isPlaying && !run)
                        {
                            AS.clip = SoundsClips[0];
                            AS.PlayOneShot(AS.clip);
                        }
                        else if (!AS.isPlaying && run && m_stemina.value > 0.1)
                        {
                            m_stemina.value -= Time.deltaTime / 0.2f;
                            AS.clip = SoundsClips[6];
                            AS.PlayOneShot(AS.clip);
                        }
                    }
                    else
                        AS.Stop();

                    break;
            }
        }
    }


    void OnFlash()
    {
       if(flashlight.isOn)
        {
            if(!ON && Input.GetKeyDown(KeyCode.F))
            {
                Light.SetActive(true);
                AS2.PlayOneShot(SoundsClips[1]);
                ON = true;
            }
            else if(ON && Input.GetKeyDown(KeyCode.F))
            {
                Light.SetActive(false);
                AS2.PlayOneShot(SoundsClips[1]);
                ON = false;
            }
        }
    }
}
