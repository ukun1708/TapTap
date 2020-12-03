using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed;

    public static MovementPlayer Singleton;
    void Start()
    {
        Singleton = this;
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
