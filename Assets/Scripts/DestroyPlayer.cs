using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject cubes;

    public int xSize;

    public int ySize;

    public int zSize;

    Vector3 offset;

    public bool lose = false;

    public static DestroyPlayer Singleton;

    private void Start()
    {
        Singleton = this;

        offset = cubes.GetComponent<MeshRenderer>().bounds.size;

        cubes.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "playerDied")
        {
            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    for (int z = 0; z < zSize; z++)
                    {
                        Instantiate(cubes, new Vector3(transform.position.x + (offset.x * x), transform.position.y + (offset.y * y), transform.position.z + (offset.z * z)), Quaternion.identity);

                        gameObject.GetComponent<MeshRenderer>().enabled = false;

                        MovementPlayer.Singleton.speed = 0f;

                        Debug.Log("Игроку пиздец");

                        StartCoroutine(CameraScaler());

                        lose = true;
                    }
                }
            }
        }
    }

    IEnumerator CameraScaler()
    {
        yield return new WaitForSeconds(1.5f);

        FollowCamera.Singleton.offset = new Vector3(0f, 5f, 0f);

        StartGame.Singleton.loseMenu.SetActive(true);

        PlayerController.Singleton.enableControl = false;

        yield return null;
    }

}
