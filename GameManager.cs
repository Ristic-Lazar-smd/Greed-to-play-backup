using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    private BouncySpawn bouncyspawn;

    public float spawntime;
    public float countdown = 3;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        bouncyspawn = gameObject.GetComponent<BouncySpawn>();

    }

    void Update()
    {   
        countdown -= Time.deltaTime;
        if (countdown <= 0)
        {
            Spawnbouncy();
            if (spawntime > 0.5) { 
                spawntime = (float)(spawntime * 0.9); 
            }
            countdown = spawntime;
        }
    }

    public void Spawnbouncy()
    {
        bouncyspawn.TaskOnClick();
    }

}
