using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    float timeOfTravel = 5f;

    float currentTime = 0f;

    float normalizedValue;

    // ui главного меню

    public GameObject logoImg;

    public GameObject mainMenu;

    public GameObject bottomButtons;

    public GameObject loseMenu;

    // позиции главного меню

    Vector3 startPositionLogo;

    Vector3 endPositioLogo;

    Vector3 startPositionbottomButtons;

    Vector3 endPositiobottomButtons;

    

    public float speedMove;

    public static StartGame Singleton;

    void Start()
    {
        Singleton = this;

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

        PlayerController.Singleton.enableControl = true;
    }

    public void RestartButton()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


}
