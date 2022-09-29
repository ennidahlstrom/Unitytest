using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class BatSpawner : MonoBehaviour
{
    public Transform bat;
    private Transform player;
    private float screenEdgeRight_WorldPos;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        CreateBat();
    }

    void CreateBat()
    {
        //Instantiate(this.bat, new Vector2(0, 0), Quaternion.identity);
        float playerHeight = this.player.position.y;
        screenEdgeRight_WorldPos = Camera.main.ViewportToWorldPoint(new Vector3(1.0f, 0, 0.0f)).x;
        Instantiate(bat, new Vector3(screenEdgeRight_WorldPos * 1.1f, playerHeight, 0.0f), Quaternion.identity);
       float spawnInterval = Random.Range(2.0f, 10.0f);
       print(spawnInterval);
       Invoke("CreateBat", spawnInterval);
    }

    

    
}
