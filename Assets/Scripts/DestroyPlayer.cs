using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Monetization;

public class DestroyPlayer : MonoBehaviour
{
    public GameObject cubes;

    public int xSize;

    public int ySize;

    public int zSize;

    Vector3 offset;

    public bool lose = false;

    public static DestroyPlayer Singleton;

    int deadCount;

    void Start()
    {
        deadCount = 0;

        if (Advertisement.isSupported)
        {
            Advertisement.Initialize("3930947", false);
        }

        Singleton = this;

        offset = cubes.GetComponent<MeshRenderer>().bounds.size;

        cubes.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "playerDied")
        {
            deadCount++;

            gameObject.GetComponent<MeshRenderer>().enabled = false;

            gameObject.GetComponent<BoxCollider>().enabled = false;

            MovementPlayer.Singleton.speed = 0f;

            Debug.Log("Игроку пиздец");

            StartGame.Singleton.gameSound.SetActive(false);

            StartGame.Singleton.loseSound.SetActive(true);

            for (int x = 0; x < xSize; x++)
            {
                for (int y = 0; y < ySize; y++)
                {
                    for (int z = 0; z < zSize; z++)
                    {

                        var pieces = Instantiate(cubes, new Vector3(transform.position.x + (offset.x * x), transform.position.y + (offset.y * y), transform.position.z + (offset.z * z)), Quaternion.identity);

                        Destroy(pieces, Random.Range(2f, 3f));                        

                        if (deadCount == 5)
                        {
                            if (Advertisement.IsReady())
                            {
                                Advertisement.Show("video");
                            }

                            deadCount = 0;
                        }

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
