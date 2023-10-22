using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class Loading : MonoBehaviour
{
    public GameObject LoadingPanel;
    public Slider slider;
    public Text Loadingtext;
    private float loadingtime;

    public void LoadScene(int SceneNumber)
    {
        StartCoroutine(LoadAsync(SceneNumber));
    }


    IEnumerator LoadAsync(int SceneNumber)
    {
        AsyncOperation op = SceneManager.LoadSceneAsync(SceneNumber);

        LoadingPanel.SetActive(true);
        op.allowSceneActivation = false;

        while (!op.isDone)
        {
            loadingtime += Time.deltaTime * 0.08f;
            slider.value = loadingtime;
            Loadingtext.text = loadingtime.ToString("P0");

            if (slider.value < 0.9f)
                slider.value = loadingtime;
            
            else
            {
                slider.value = Mathf.Clamp(slider.value, 0.9f,loadingtime);
                if(slider.value == 1f)
                {
                    op.allowSceneActivation = true;
                    yield break;
                }
            }
            yield return null;
        }
    }
}
