using UnityEngine;

public class Examine : MonoBehaviour
{
    public GameObject ObjectName;
    public GameObject pos;
    public Canvas cursor;
    public Canvas ui;

    AudioSource AS;
    Camera mainCam;
    IsOpen isOpen;
    Outline OL;
    InteractUIPos uiPos;

    Vector3 originalPosition;
    Vector3 originalRotation;
    public static bool exMode;
    public string exName;
    bool examineMode;

    void Start()
    {
        ObjectName = this.gameObject;
        mainCam = Camera.main;
        uiPos = GetComponent<InteractUIPos>();
        AS = GetComponentInParent<AudioSource>();
        isOpen = GetComponent<IsOpen>();
        OL = GetComponent<Outline>();
        examineMode = false;
    }

    void Update()
    {
        ExitExamineMode();
        clickedObject();
        TurnObject();
    }

    void clickedObject()
    {
        if (!InteractObjMgr.GetInst().Coma && examineMode == false)
        {
            RaycastHit hit;
            Ray ray = mainCam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 1.1f))
            {
                exName = hit.collider.name;
                if (hit.collider.CompareTag("Object") && hit.collider.name == this.gameObject.name)
                {
                    this.gameObject.GetComponent<Outline>().enabled = true;
                    
                    if (Input.GetMouseButtonDown(0) | Input.GetKeyDown(KeyCode.E))
                    {
                        ObjectName = hit.transform.gameObject;
                        AS.PlayOneShot(AS.clip);

                        originalPosition = ObjectName.transform.position;
                        originalRotation = ObjectName.transform.rotation.eulerAngles;

                        Vector3 worldpos = Camera.main.WorldToViewportPoint(pos.transform.position);
                        if (worldpos.x < 0f) worldpos.x = 0f;
                        if (worldpos.y < 0f) worldpos.y = 0f;
                        if (worldpos.x > 1f) worldpos.x = 1f;
                        if (worldpos.y > 1f) worldpos.y = 1f;
                        transform.position = Camera.main.ViewportToWorldPoint(worldpos);

                        Time.timeScale = 0f;

                        this.gameObject.GetComponent<Outline>().enabled = false;
                        GameMgr.PossibleEsc = false;
                        cursor.enabled = false;
                        ui.enabled = true;
                        examineMode = true;
                        exMode = true;
                    }
                }

                else
                {
                    this.gameObject.GetComponent<Outline>().enabled = false;
                    ui.enabled = false;
                }

            }
            else if (hit.collider != ObjectName)
            {
                OL.enabled = false;
                cursor.enabled = true;

                ObjectName.transform.position = uiPos.transform.position;
                ObjectName.transform.eulerAngles = uiPos.transform.eulerAngles;
            }
        }
    }


    void TurnObject()
    {
        if (Input.GetKey(KeyCode.E) && examineMode)
        {
            float rotationSpeed = 4f;

            float xAxis = Input.GetAxis("Mouse X") * rotationSpeed;
            float yAxis = Input.GetAxis("Mouse Y") * rotationSpeed;

            ObjectName.transform.Rotate(Vector3.up, -xAxis, Space.World);
            ObjectName.transform.Rotate(Vector3.right, yAxis, Space.World);
        }
    }


    void ExitExamineMode()
    {
        if (Input.GetKeyDown(KeyCode.B) | Input.GetMouseButtonDown(1)
            && examineMode && !InteractObjMgr.GetInst().Coma)
        {
            this.ObjectName.transform.position = originalPosition;
            this.ObjectName.transform.eulerAngles = originalRotation;

            AS.PlayOneShot(AS.clip);
            this.gameObject.GetComponent<Outline>().enabled = false;
            cursor.enabled = true;
            examineMode = false;
            GameMgr.PossibleEsc = true;
            Time.timeScale = 1f;
            ui.enabled = false;
            exMode = false;
        }
    }
}
