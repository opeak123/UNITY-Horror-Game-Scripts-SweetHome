using UnityEngine;

public class CameraRotate : MonoBehaviour
{
    public Camera padCam;
    public GameObject num;
    void Update()
    {
        transform.Rotate(0, Input.GetAxis("Mouse X") * 0.2f, 0);
        Vector3 position = Camera.main.WorldToViewportPoint(transform.position);

        if(!LockControl.zoom)
        {
            padCam.transform.LookAt(num.transform);
        }

        if(LockControl.padOpen)
            Destroy(this.gameObject);
    }
}
