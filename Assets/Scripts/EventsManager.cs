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
    public TextMeshProUGUI playBtn;
    public string playbtnVal="Play";
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playBtn.text = playbtnVal;
    }

   


    public void pauseGame()
    {
        playbtnVal = "Resume";
        PlayerMovementManager.gameStarted = false;
        inGamePanel.SetActive(false);
        outGamePanel.SetActive(true);
        tileManager.SetActive(false);
        player.SetActive(false);
    }

    public void startGame()
    {
        PlayerMovementManager.gameStarted = true;
        inGamePanel.SetActive(true);
        outGamePanel.SetActive(false);
        tileManager.SetActive(true);
        player.SetActive(true);
    }
}
