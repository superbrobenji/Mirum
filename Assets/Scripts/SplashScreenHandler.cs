using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SplashScreenHandler : MonoBehaviour {

    public CanvasGroup uiElement;
    public string scene;

    private void Start()
    {
        //uiElement.alpha = 0;
        if (uiElement.alpha == 0)
        {
            FadeIn();
        }
        
    }

    public void FadeIn()
    {
        StartCoroutine(Fade(uiElement, uiElement.alpha, 1));
    }

    public void FadeOut()
    {
        StartCoroutine(Fade(uiElement, uiElement.alpha, 0));
    }

    IEnumerator Fade(CanvasGroup cg, float start, float end, float lerpTime = 0.5f)
    {

        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float CurrentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = CurrentValue;

            //print("running...");

            if (percentageComplete >= 1) break;

            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForSeconds(2.5f);
        FadeOut();
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(scene);
    }
}
