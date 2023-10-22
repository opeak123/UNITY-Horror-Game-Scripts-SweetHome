using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class gamecredit : MonoBehaviour
{
    public void LoadScene(int SceneNumber)
    {
        StartCoroutine(LoadAsync(SceneNumber));
    }
    IEnumerator LoadAsync(int SceneNumber)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneNumber);
        op.allowSceneActivation = true;
        yield return null;
    }
    public void exit()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
