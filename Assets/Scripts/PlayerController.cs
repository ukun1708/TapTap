using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    string nameTag;

    public float force;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            if (nameTag == "RightTurn")
            {
                transform.rotation *= Quaternion.Euler(Vector3.up * 90f);
            }

            else if (nameTag == "LeftTurn")
            {
                transform.rotation *= Quaternion.Euler(Vector3.up * -90f);
            }

            else if (nameTag == "Jump")
            {
                rb.AddForce(Vector3.up * force, ForceMode.Impulse);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        nameTag = other.tag;
    }
}
