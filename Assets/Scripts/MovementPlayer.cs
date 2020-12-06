using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed;

    public static MovementPlayer Singleton;

    public bool playGame = false;
    void Start()
    {
        Singleton = this;
    }

    void Update()
    {
        if (playGame == true)
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
        }
    }
}
