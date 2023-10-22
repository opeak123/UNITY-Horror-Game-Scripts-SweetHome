using UnityEngine;
public class OpenURL : MonoBehaviour
{
    public void Youtube()
    {
        Application.OpenURL("https://www.youtube.com/channel/UCuL7OYcraZktTWF9MV5LdRg");
    }
    public void Kakao()
    {
        Application.OpenURL("https://open.kakao.com/o/sM2jbdne");
    }
}
