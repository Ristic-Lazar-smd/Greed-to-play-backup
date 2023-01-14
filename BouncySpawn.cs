using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BouncySpawn : MonoBehaviour
{
    public GameObject bouncy;
    private float randomXposition, randomYposition;
    private Vector3 spawnPosition;
    public Button spawnButton;
    public PlayerMovement thelist;

    public void TaskOnClick()
    {
        randomXposition = Random.Range(-8f, 8.20f);
        randomYposition = Random.Range(-4.40f, 4.10f);
        spawnPosition = new Vector3(randomXposition, randomYposition, 0f);
        Instantiate(bouncy, spawnPosition, Quaternion.identity);
    }
}
