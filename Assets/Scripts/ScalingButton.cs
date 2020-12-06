using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalingButton : MonoBehaviour
{
    public GameObject playButton;

    public bool scalingButton = true;

    float timeOfTravel = 5f;

    float currentTime = 0f;

    float normalizedValue;

    public float speedScale;

    Vector3 currentScale;

    Vector3 targetScale;
    void Start()
    {
        currentScale = new Vector3(1.5f, 1.5f, 1.5f);

        targetScale = new Vector3(1.5f, 1.5f, 1.5f);

        StartCoroutine(ScalerButton());
    }


    IEnumerator ScalerButton()
    {
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;

            normalizedValue = currentTime / timeOfTravel;

            playButton.GetComponent<RectTransform>().localScale = Vector3.Lerp(currentScale, targetScale, normalizedValue * speedScale);

            currentTime = 0f;
        }

        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;

            normalizedValue = currentTime / timeOfTravel;

            playButton.GetComponent<RectTransform>().localScale = Vector3.Lerp(targetScale, currentScale, normalizedValue * speedScale);
        }

        yield return new WaitForSeconds(0f);
    }
}
