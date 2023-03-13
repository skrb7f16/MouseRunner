using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class MainMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    public TextMeshProUGUI mainMenuBtn;
    public static string mainMenuBtnVal = "Play";
    void Start()
    {
        mainMenuBtn.text = mainMenuBtnVal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
}
