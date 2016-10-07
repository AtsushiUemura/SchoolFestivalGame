using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartManager : MonoBehaviour
{

    [SerializeField]
    private AudioClip BGM;
    [SerializeField]
    private AudioClip startSE;
    private bool fadeIsRunning;
    [SerializeField]
    private Image fadeImage;
    [SerializeField]
    private string sceneName;

    #region
    IEnumerator Start()
    {
        Init();
        Coroutine coroutine = StartCoroutine(TouchWait());
        yield return coroutine;
        yield return new WaitForSeconds(0.5f);
        coroutine = StartCoroutine(FadeIn(1));
        yield return coroutine;
        SceneManager.LoadSceneAsync(sceneName);
    }
    #endregion

    private void Init()
    {
        GameManager.I.BGMPlay(BGM);
        fadeIsRunning = false;
    }
    private IEnumerator TouchWait()
    {
        bool flag = false;
        while (!flag)
        {
            if (Input.GetMouseButtonDown(0))
            {
                flag = true;
                GameManager.I.SEPlay(startSE);
            }

            yield return null;
        }
    }
    public IEnumerator FadeIn(float fadeLeap)
    {
        if (fadeIsRunning) yield break;
        fadeIsRunning = true;
        float elapsedTime = 0;
        while (fadeImage.color.a < 1)
        {
            elapsedTime += Time.deltaTime;
            Color tmpColor = fadeImage.color;
            tmpColor.a = Mathf.Lerp(tmpColor.a, 1, elapsedTime * fadeLeap);
            fadeImage.color = tmpColor;
            yield return null;
            if (fadeImage.color.a >= 0.99f)
            {
                tmpColor.a = 1;
                fadeImage.color = tmpColor;
                break;
            }
        }
        fadeIsRunning = false;
    }
    public IEnumerator FadeOut(float fadeLeap)
    {
        if (fadeIsRunning) yield break;
        fadeIsRunning = true;
        float elapsedTime = 0;
        while (fadeImage.color.a > 0)
        {
            elapsedTime += Time.deltaTime;
            var tmpColor = fadeImage.color;
            tmpColor.a = Mathf.Lerp(fadeImage.color.a, 0, elapsedTime * fadeLeap);
            fadeImage.color = tmpColor;
            yield return null;
            if (fadeImage.color.a <= 0.01f)
            {
                tmpColor.a = 0;
                fadeImage.color = tmpColor;
                break;
            }
        }
        fadeIsRunning = false;
    }
}
