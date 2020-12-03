using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target;

    public float smooth = 5f;

    public Vector3 offset = new Vector3(0, 0, 0);

    public float speedRotation;

    public GameObject cam;

    public static FollowCamera Singleton;

    private void Start()
    {
        Singleton = this;
    }
    void Update()
    {
        cam.transform.position = Vector3.Lerp(cam.transform.position, target.position + offset, Time.deltaTime * smooth);

        cam.transform.rotation = Quaternion.Lerp(cam.transform.rotation, target.transform.rotation, speedRotation * Time.deltaTime);
    }
}
