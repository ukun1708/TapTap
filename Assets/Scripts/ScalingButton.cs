using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalingButton : MonoBehaviour
{
    public GameObject playButton;

    public bool scalingButton = true;

    public float speedScale;

    Vector3 currentScale;

    Vector3 targetScale;
    void Start()
    {
        currentScale = new Vector3(1f, 1f, 1f);

        targetScale = new Vector3(1.1f, 1.1f, 1.1f);

        StartCoroutine(ScalerButton());
    }


    IEnumerator ScalerButton()
    {
        while (true)
        {
            for (float i = 0.01f; i < speedScale; i++)
            {
                playButton.GetComponent<RectTransform>().localScale = Vector3.Lerp(currentScale, targetScale, Mathf.Min(1f, i / speedScale));

                yield return null;
            }

            for (float i = 0.01f; i < speedScale; i++)
            {
                playButton.GetComponent<RectTransform>().localScale = Vector3.Lerp(targetScale, currentScale, Mathf.Min(1f, i / speedScale));

                yield return null;
            }
        }
    }
}
