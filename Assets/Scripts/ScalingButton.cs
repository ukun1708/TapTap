using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScalingButton : MonoBehaviour
{
    public GameObject playButton;

    public bool scalingButton = true;

    public float speedScale;

    Vector3 startScale = new Vector3(1f, 1f, 1f);

    Vector3 endScale = new Vector3(1.1f, 1.1f, 1.1f);

    RectTransform rect;

    void Start()
    {
        rect = playButton.GetComponent<RectTransform>();

        StartCoroutine(ScalerButton());
    }


    public IEnumerator ScalerButton()
    {
        while (true)
        {

            rect.localScale = Vector3.Lerp(startScale, endScale, Mathf.Sin(Time.time * speedScale) * 0.5f + 0.5f);

            yield return null;

        }
    }
}
