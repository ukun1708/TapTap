using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    float timeOfTravel = 5f;

    float currentTime = 0f;

    float normalizedValue;

    public GameObject logoImg;

    public GameObject mainMenu;

    public GameObject bottomButtons;

    Vector3 startPositionLogo;

    Vector3 endPositioLogo;

    Vector3 startPositionbottomButtons;

    Vector3 endPositiobottomButtons;

    public float speedMove;

    void Start()
    {
        startPositionLogo = logoImg.GetComponent<RectTransform>().anchoredPosition;

        endPositioLogo = new Vector3(0f, -1280f);

        startPositionbottomButtons = bottomButtons.GetComponent<RectTransform>().anchoredPosition;

        endPositiobottomButtons = new Vector3(0f, 260f);

        StartCoroutine(LerpObject());
    }
    
    IEnumerator LerpObject()
    {
        while (currentTime <= timeOfTravel)
        {
            currentTime += Time.deltaTime;

            normalizedValue = currentTime / timeOfTravel;


            logoImg.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPositionLogo, endPositioLogo, normalizedValue * speedMove);

            bottomButtons.GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(startPositionbottomButtons, endPositiobottomButtons, normalizedValue * speedMove);

            yield return null;
        }
    }

    public void ClickPlayButton()
    {
        mainMenu.SetActive(false);

        MovementPlayer.Singleton.playGame = true;
    }


}
