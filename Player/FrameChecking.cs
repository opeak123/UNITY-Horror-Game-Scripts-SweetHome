using UnityEngine;
using UnityEngine.UI;
public class FrameChecking : MonoBehaviour
{
    public Canvas m_Canvas;
    public Text m_text;
    float time = 0f;
    [Range(0.0f,2f)] public float showTime;
    bool isOn = true;
    void Update()
    {
        time += (Time.unscaledDeltaTime - time) * showTime;
        checking();
        if (Input.GetKeyDown(KeyCode.F1))
        {
            isOn = !isOn;
            m_Canvas.enabled = !m_Canvas.enabled;
        }
    }

    void checking()
    {
        float ms = time * 1000f;
        float fps = 1f / time;
        m_text.text = string.Format
            ("{0:0.} FPS\n\t{1:0.0} ms", fps, ms);
    }
}
