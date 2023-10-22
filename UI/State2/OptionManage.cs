using UnityEngine;
public class OptionManage : MonoBehaviour
{
    public CanvasGroup exitCGroup;
    public CanvasGroup optionCGroup;
    public CanvasGroup GameSetCGroup;
    public CanvasGroup VolumeCGroup;

    public CanvasGroup VideoCGroup;
    public CanvasGroup ControlCGroup;
    public AudioSource AS;
    public void OnClickControl()
    {
        if (ControlCGroup.alpha <= 0)
        {
            ControlCGroup.blocksRaycasts = true;
            ControlCGroup.interactable = true;
            ControlCGroup.alpha = 1;

            GameSetCGroup.blocksRaycasts = false;
            GameSetCGroup.interactable = false;
            GameSetCGroup.alpha = 0;
        }
        else
        {
            ControlCGroup.blocksRaycasts = false;
            ControlCGroup.interactable = false;
            ControlCGroup.alpha = 0;
        }
    }

    public void OnClickVideo()
    {
        if (VideoCGroup.alpha <= 0)
        {
            VideoCGroup.blocksRaycasts = true;
            VideoCGroup.interactable = true;
            VideoCGroup.alpha = 1;

            GameSetCGroup.blocksRaycasts = false;
            GameSetCGroup.interactable = false;
            GameSetCGroup.alpha = 0;
        }
        else
        {
            VideoCGroup.blocksRaycasts = false;
            VideoCGroup.interactable = false;
            VideoCGroup.alpha = 0;
        }
    }

    public void OnClickAudio()
    {
        if (VolumeCGroup.alpha <= 0)
        {
            VolumeCGroup.blocksRaycasts = true;
            VolumeCGroup.interactable = true;
            VolumeCGroup.alpha = 1;

            GameSetCGroup.blocksRaycasts = false;
            GameSetCGroup.interactable = false;
            GameSetCGroup.alpha = 0;
        }
        else
        {
            VolumeCGroup.blocksRaycasts = false;
            VolumeCGroup.interactable = false;
            VolumeCGroup.alpha = 0;
        }
    }
    public void OnClickOptions()
    {

        if (exitCGroup.alpha <= 0)
        {
            optionCGroup.blocksRaycasts = true;
            optionCGroup.interactable = true;
            optionCGroup.alpha = 1;
        }
        else
        {
            optionCGroup.blocksRaycasts = false;
            optionCGroup.interactable = false;
            optionCGroup.alpha = 0;
        }
    }

    public void ReturnMenu()
    {
        optionCGroup.blocksRaycasts = false;
        optionCGroup.interactable = false;
        optionCGroup.alpha = 0;
    }

    public void ReturnToOption()
    {
        GameSetCGroup.blocksRaycasts = true;
        GameSetCGroup.interactable = true;
        GameSetCGroup.alpha = 1;

        VideoCGroup.blocksRaycasts = false;
        VideoCGroup.interactable = false;
        VideoCGroup.alpha = 0;
    }
    public void ControlToOption()
    {
        if (ControlCGroup.alpha <= 1)
        {
            ControlCGroup.blocksRaycasts = false;
            ControlCGroup.interactable = false;
            ControlCGroup.alpha = 0;

            GameSetCGroup.blocksRaycasts = true;
            GameSetCGroup.interactable = true;
            GameSetCGroup.alpha = 1;
        }
    }

    public void VolumeToOption()
    {
        if(VolumeCGroup.alpha <= 1)
        {
            VolumeCGroup.blocksRaycasts = false;
            VolumeCGroup.interactable = false;
            VolumeCGroup.alpha = 0;

            GameSetCGroup.blocksRaycasts = true;
            GameSetCGroup.interactable = true;
            GameSetCGroup.alpha = 1;
        }
    }

    public void OnClickExit()
    {
        if (exitCGroup.alpha <= 0)
        {
            exitCGroup.blocksRaycasts = true;
            exitCGroup.interactable = true;
            exitCGroup.alpha = 1;
        }
        else
        {
            exitCGroup.blocksRaycasts = false;
            exitCGroup.interactable = false;
            exitCGroup.alpha = 0;
        }
    }

    private void Update()
    {
        if (optionCGroup.alpha == 0)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                AS.Play();
                OnClickExit();
            }
        }
    }

    public void GameQuit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
