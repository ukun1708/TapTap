using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoseMenu : MonoBehaviour
{
    float timeOfTravel = 5f;

    float currentTime = 0f;

    float normalizedValue;

    // ui маню проигрыша 

    public GameObject loseLogoImg;

    public GameObject loseBottomButtons;

    public GameObject loseButton;

    public GameObject loseMenuBackground;

    // позиции меню проигрыша

    Vector3 loseStartPositionLogo;

    Vector3 loseEndPositioLogo;

    Vector3 loseStartPositionbottomButtons;

    Vector3 loseEndPositiobottomButtons;

    Vector3 loseButtonStartPos;

    Vector3 loseButtonEndPos;

    public float speedMove;

    public static LoseMenu Singleton;
    void Start()
    {

        Singleton = this;

        loseStartPositionLogo = loseLogoImg.GetComponent<RectTransform>().anchoredPosition;

        loseEndPositioLogo = new Vector3(0f, -1280f);

        loseStartPositionbottomButtons = loseBottomButtons.GetComponent<RectTransform>().anchoredPosition;

        loseEndPositiobottomButtons = new Vector3(0f, 260f);

        loseButtonStartPos = loseButton.GetComponent<RectTransform>().anchoredPosition;

        loseButtonEndPos = new Vector3(0f, -158f);

        StartCoroutine(LoseMenuLerp());
    }


    public IEnumerator LoseMenuLerp()
    {
        while (currentTime <= timeOfTravel)
        {
            Color originalColorBackground = loseMenuBackground.GetComponent<Image>().color;

            Color fadeColor = new Color(0f, 0.372549f, 7176471f, 0.8f);


            currentTime += Time.deltaTime;

            normalizedValue = currentTime / timeOfTravel;


            loseLogoImg.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(loseStartPositionLogo, loseEndPositioLogo, normalizedValue * speedMove);

            loseBottomButtons.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(loseStartPositionbottomButtons, loseEndPositiobottomButtons, normalizedValue * speedMove);


            loseButton.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(loseButtonStartPos, loseButtonEndPos, normalizedValue * speedMove);


            loseMenuBackground.GetComponent<Image>().color = Color.Lerp(originalColorBackground, fadeColor, normalizedValue * speedMove);


            yield return null;
        }

    }
}
