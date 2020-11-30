using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public float speed;
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }
}
