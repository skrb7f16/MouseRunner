using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class EventsManager : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject outGamePanel; 
    public GameObject inGamePanel;
    public GameObject tileManager;
    public GameObject player;
    public Camera Cam;
    public TextMeshProUGUI playBtn;
    public string playbtnVal="Play";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playBtn.text = playbtnVal;
        if(PlayerMovementManager.gameOver == true)
        {
            gameOverFunc();
        }
    }

   


    public void pauseGame(string s="Resume")
    {
        Cam.GetComponent<CameraMovement>().ResetCamera();
        playbtnVal = s;
        PlayerMovementManager.gameStarted = false;
        inGamePanel.SetActive(false);
        outGamePanel.SetActive(true);
        tileManager.SetActive(false);
        player.SetActive(false);
    }

    public void startGame()
    {
        PlayerMovementManager.gameOver = false;
        PlayerMovementManager.gameStarted = true;
        inGamePanel.SetActive(true);
        outGamePanel.SetActive(false);
        tileManager.SetActive(true);
        player.SetActive(true);
    }

    public void gameOverFunc()
    {
        ScoreManager.score = 0;
        
        TileManager.zSpawn = 0;
        player.transform.position = new Vector3(0, 1, -49);
        pauseGame("Play");

    }
}
