using System.Collections;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed;

    public static MovementPlayer Singleton;

    public bool playGame = false;
    void Start()
    {
        speed = 8f;

        Singleton = this;
    }

    void Update()
    {
        if (playGame == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Acceleration")
        {
            Debug.Log("Ускорение");

            speed = 12f;
        }

        if (other.tag == "Finish")
        {
            Debug.Log("Вы победили");

            speed = 0f;

            StartCoroutine(CameraScaler());
        }
    }

    
    IEnumerator CameraScaler()
    {
        yield return new WaitForSeconds(1.5f);

        FollowCamera.Singleton.offset = new Vector3(0f, 5f, 0f);

        StartGame.Singleton.WinMenu.SetActive(true);

        PlayerController.Singleton.enableControl = false;

        yield return null;
    }


}
