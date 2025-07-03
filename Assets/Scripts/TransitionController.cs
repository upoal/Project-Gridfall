using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Only if using TextMeshPro

public class TransitionController : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    public float fadeDuration = 1.5f;
    public string nextSceneName = "DemoLvl";
    public TMP_Text levelText; // Or Text if using legacy

    void Start()
    {
        levelText.text = $"Level: {nextSceneName}";
        StartCoroutine(DoTransition());
    }

    IEnumerator DoTransition()
    {
        // Fade in (fully black)
        yield return new WaitForSeconds(0.5f);

        // Optional hold time
        yield return new WaitForSeconds(1f);

        // Fade out
        yield return StartCoroutine(FadeCanvasGroup(1, 0, fadeDuration));

        // Load actual level
        SceneManager.LoadScene(nextSceneName);
    }

    IEnumerator FadeCanvasGroup(float from, float to, float duration)
    {
        float timer = 0f;
        while (timer < duration)
        {
            timer += Time.deltaTime;
            canvasGroup.alpha = Mathf.Lerp(from, to, timer / duration);
            yield return null;
        }
        canvasGroup.alpha = to;
    }
}
