using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{
    public GameObject[] tilePrefabs;
    public static float zSpawn = 0;
    public float tileLength = 100;
    public GameObject player;
    public static List<GameObject> tiles=new List<GameObject>();
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (zSpawn - player.transform.position.z < tileLength && PlayerMovementManager.gameStarted)
        {
            SpawnTile(Random.Range(0, 4));
        }
        if (tiles.Count > 3)
        {
            DestroyImmediate(tiles[0]);
            tiles.RemoveAt(0);
        }
        if (PlayerMovementManager.gameOver)
        {
            while (tiles.Count>0)
            {
                DestroyImmediate(tiles[0]);
                tiles.RemoveAt(0);
            }
        }
    }

    void SpawnTile(int index)
    {
        GameObject temp=Instantiate(tilePrefabs[index], transform.forward * zSpawn, transform.rotation);
        temp.transform.parent = transform;
        tiles.Add(temp);
        zSpawn += tileLength;
    }
}
