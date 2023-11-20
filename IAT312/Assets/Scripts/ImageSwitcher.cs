using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ImageSwitcher : MonoBehaviour
{
    public Image imageComponent;
    public Sprite[] images;
    public float startGap, gapBetweenEachImage, fadeDuration, transitionToNextSceneDelay;

    void Start()
    {
        StartCoroutine(StartFading());
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            imageComponent.color = new Color(1f, 1f, 1f, 0f);

            SceneManager.LoadScene("TutorialRoom");
        }
    }

    IEnumerator StartFading()
    {
        // Set the initial color to fully transparent
        imageComponent.color = new Color(1f, 1f, 1f, 0f);

        // Wait for a short delay
        yield return new WaitForSeconds(startGap);

        // Fade in from transparent at the beginning
        yield return FadeImage(true, fadeDuration);

        // Start switching images after the initial fade-in
        StartCoroutine(SwitchImages());
    }

    IEnumerator SwitchImages()
    {
        foreach (var spriteHere in images)
        {
            // Fade out the current image
            yield return FadeImage(false, fadeDuration);

            // Set the new sprite
            imageComponent.sprite = spriteHere;

            // Fade in the new image
            yield return FadeImage(true, fadeDuration);

            // Wait for the specified gap between images
            yield return new WaitForSeconds(gapBetweenEachImage);
        }

        // Fade out to black before transitioning to the next scene
        yield return FadeImage(false, fadeDuration);

        // Wait for a delay before transitioning to the next scene
        yield return new WaitForSeconds(transitionToNextSceneDelay);

        // Switch to the next scene
        imageComponent.color = new Color(1f, 1f, 1f, 0f);

        SceneManager.LoadSceneAsync("TutorialRoom");
    }

    IEnumerator FadeImage(bool fadeIn, float duration)
    {
        float targetAlpha = fadeIn ? 1f : 0f;
        Color startColor = imageComponent.color;
        Color targetColor = new Color(startColor.r, startColor.g, startColor.b, targetAlpha);

        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            imageComponent.color = Color.Lerp(startColor, targetColor, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        imageComponent.color = targetColor; // Ensure the final color is set
    }
}
