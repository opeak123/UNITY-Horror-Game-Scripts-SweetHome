using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Resolution : MonoBehaviour
{
    List<int> widths = new List<int>() { 1600, 1920, 1280, 800 };
    List<int> heights = new List<int>() { 900, 1080, 720, 600 };
    public Dropdown ScreenDD;

    private void Update()
    {
        ScreenSzie();
    }
    public void SetResolutionSize(int num1)
    {
        int width = widths[num1];
        int height = heights[num1];
        Screen.SetResolution(width, height,FullScreenMode.Windowed);;
    }
   public void ScreenSzie()
    {
        if(ScreenDD.value == 0)
        {
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
        else if(ScreenDD.value == 1)
        {
            Screen.fullScreenMode = FullScreenMode.MaximizedWindow;
        }
        else if(ScreenDD.value == 2)
        {
            Screen.fullScreenMode = FullScreenMode.FullScreenWindow;
        }
    }
}
