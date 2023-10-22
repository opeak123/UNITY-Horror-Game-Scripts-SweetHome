using UnityEngine;
using UnityEngine.UI;
public class Hunger : MonoBehaviour
{
    public Slider slider;
    public static  float Gauge = 1;
    float limitedtime = 400f; // sec //400
    public Image img;

    void Update()
    {
        hunger();
    }

    void hunger()
    {
        if (Gauge > 0)
        {
            slider.value = Gauge;
            Gauge -= Time.deltaTime / limitedtime;
            InteractObjMgr.GetInst().GameStop = false;
            if (Gauge <= 0.4f)
            {
                img.color = new Color32(135, 30, 30, 255);
            }
        }
        else if(Gauge <= 0)
        {
            InteractObjMgr.GetInst().GameStop = true;
            Time.timeScale = 0f;
        }
    }
}
