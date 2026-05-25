using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Yarn.Unity;

public class ScreenFade : MonoBehaviour
{
    public static ScreenFade Instance;

    public Image fadeImage;

    private Coroutine currentFade;

    private void Awake()
    {
        Instance = this;
    }

    [YarnCommand("fade_in")]
    public static void FadeIn(string duration)
    {
        float time = float.Parse(duration);
        Instance.StartFade(1f, time);
    }

    [YarnCommand("fade_out")]
    public static void FadeOut(string duration)
    {
        float time = float.Parse(duration);
        Instance.StartFade(0f, time);
    }

    private void StartFade(float targetAlpha, float duration)
    {
        if (currentFade != null)
            StopCoroutine(currentFade);

        currentFade = StartCoroutine(FadeRoutine(targetAlpha, duration));
    }

    private IEnumerator FadeRoutine(float targetAlpha, float duration)
    {
        float startAlpha = fadeImage.color.a;
        float timer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;

            float alpha = Mathf.Lerp(startAlpha, targetAlpha, timer / duration);

            Color c = fadeImage.color;
            c.a = alpha;
            fadeImage.color = c;

            yield return null;
        }

        Color final = fadeImage.color;
        final.a = targetAlpha;
        fadeImage.color = final;
    }
}