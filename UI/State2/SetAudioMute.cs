using UnityEngine;
public class SetAudioMute
{
    public static void Set(bool bMute)
    {
        AudioListener.volume = bMute ? 0 : 1;
    }
}
