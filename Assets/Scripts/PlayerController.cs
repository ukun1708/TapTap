using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public enum MoveDirection
    {
        Left,
        Right,
        Jump
    }

    public MoveDirection[] moves;

    public float force;

    int checkTurn = 0;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            switch (moves[checkTurn])
            {
                case MoveDirection.Left:

                    transform.rotation *= Quaternion.Euler(Vector3.up * -90f);

                    break;
                case MoveDirection.Right:

                    transform.rotation *= Quaternion.Euler(Vector3.up * 90f);

                    break;
                case MoveDirection.Jump:

                    rb.AddForce(Vector3.up * force, ForceMode.Impulse);
                    break;
                default:
                    break;
            }
            checkTurn++;
        }
    }
}
