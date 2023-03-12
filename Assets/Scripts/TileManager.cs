using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 100;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        SpawnTile(0);
        SpawnTile(1);
        SpawnTile(2);
    }

    // Update is called once per frame
    void Update()
    {
        if (zSpawn - player.transform.position.z < tileLength)
        {
            SpawnTile(Random.Range(0, 2));
        }
    }

    void SpawnTile(int index)
    {
        Instantiate(tilePrefabs[index], transform.forward * zSpawn, transform.rotation);
        zSpawn += tileLength;
    }
}
