using System.Collections;
using CodeBase.Interfaces;
using UnityEngine;

public class CubeAnimator : MonoBehaviour, ICubeAnimation
{
    public float shrinkDuration = 0.5f;
    public float growDuration = 0.2f;
    public float pauseDuration = 1f;
    public Vector3 shrinkScale = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 initialScale;
    private bool isAnimating = false;

    private void Start()
    {
        initialScale = transform.localScale;
        DontDestroyOnLoad(gameObject);
    }

    public void PlayShrinkAnimation()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateCube(shrinkScale, shrinkDuration));
        }
    }

    public void PlayGrowAnimation()
    {
        if (!isAnimating)
        {
            StartCoroutine(AnimateCube(initialScale, growDuration));
        }
    }

    private IEnumerator AnimateCube(Vector3 targetScale, float duration)
    {
        isAnimating = true;
        Vector3 initialScale = transform.localScale;
        float timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(initialScale, targetScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = targetScale;

        yield return new WaitForSeconds(pauseDuration);

        timeElapsed = 0f;

        while (timeElapsed < duration)
        {
            transform.localScale = Vector3.Lerp(targetScale, initialScale, timeElapsed / duration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        transform.localScale = initialScale;
        isAnimating = false;
    }
}