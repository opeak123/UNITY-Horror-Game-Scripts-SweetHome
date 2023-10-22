using UnityEngine;
public class GameMgr : MonoBehaviour
{
    [HideInInspector] public Canvas Escape;
    [HideInInspector] public CanvasGroup showMenu;
    [HideInInspector] public CanvasGroup option;
    [HideInInspector] public CanvasGroup exit;
    [HideInInspector] public CanvasGroup gameSetting;
    [HideInInspector] public CanvasGroup video;
    [HideInInspector] public CanvasGroup sound;
    [HideInInspector] public CanvasGroup control;
    
    public AudioSource[] AS;
    public AudioClip[] SoundsClips;
    public bool IsPlaying = true;
    public static bool PossibleEsc = true;

    void Update()
    {
        ESC();
    }

    void ESC()
    {
        if (PossibleEsc && IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Pause();
        }

        else if (!IsPlaying)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                Resume();
        }  
    }


    public void Pause()
    {
        Time.timeScale = 0f;

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = false;
        SetAudioMute.Set(false);
        AudioListener.pause = true;

        for (int i = 0; i < AS.Length; i++)
            AS[i].Pause();

        Escape.enabled = true;
        IsPlaying = false;
    }
    public void Resume()
    {
        Time.timeScale = 1f;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        SetAudioMute.Set(false);
        AudioListener.pause = false;

        for (int i = 0; i < AS.Length; i++)
            AS[i].UnPause();

        Escape.enabled = false;
        IsPlaying = true;
    }
    public void ToMenu()
    {
        showMenu.alpha = 1f;
        showMenu.interactable = true;
        showMenu.blocksRaycasts = true;

        option.alpha = 0f;
        option.interactable = false;
        option.blocksRaycasts = false;

        exit.alpha = 0f;
        exit.interactable = false;
        exit.blocksRaycasts = false;
    }
    public void ClickOption()
    {
        showMenu.alpha = 0f;
        showMenu.interactable = false;
        showMenu.blocksRaycasts = false;

        option.alpha = 1f;
        option.interactable = true;
        option.blocksRaycasts = true;

        gameSetting.alpha = 1f;
        gameSetting.interactable = true;
        gameSetting.blocksRaycasts = true;
    }
    public void ClickExit()
    {
        showMenu.alpha = 0f;
        showMenu.interactable = false;
        showMenu.blocksRaycasts = false;

        option.alpha = 0f;
        option.interactable = false;
        option.blocksRaycasts = false;

        exit.alpha = 1f;
        exit.interactable = true;
        exit.blocksRaycasts = true;
    }
    public void ClickVideo()
    {
        gameSetting.alpha = 0f;
        gameSetting.interactable = false;
        gameSetting.blocksRaycasts = false;

        video.alpha = 1f;
        video.interactable = true;
        video.blocksRaycasts = true;
    }
    public void VideoToOption()
    {
        gameSetting.alpha = 1f;
        gameSetting.interactable = true;
        gameSetting.blocksRaycasts = true;

        video.alpha = 0f;
        video.interactable = false;
        video.blocksRaycasts = false;
    }
    public void ClickAudio()
    {
        gameSetting.alpha = 0f;
        gameSetting.interactable = false;
        gameSetting.blocksRaycasts = false;

        sound.alpha = 1f;
        sound.interactable = true;
        sound.blocksRaycasts = true;
    }
    public void AudioToOption()
    {
        gameSetting.alpha = 1f;
        gameSetting.interactable = true;
        gameSetting.blocksRaycasts = true;

        sound.alpha = 0f;
        sound.interactable = false;
        sound.blocksRaycasts = false;
    }
    public void ClickControl()
    {
        gameSetting.alpha = 0f;
        gameSetting.interactable = false;
        gameSetting.blocksRaycasts = false;

        control.alpha = 1f;
        control.interactable = true;
        control.blocksRaycasts = true;
    }
    public void ControlToOption()
    {
        gameSetting.alpha = 1f;
        gameSetting.interactable = true;
        gameSetting.blocksRaycasts = true;

        control.alpha = 0f;
        control.interactable = false;
        control.blocksRaycasts = false;
    }








    public void GameQuit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}

