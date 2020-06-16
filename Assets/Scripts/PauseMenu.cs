using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public bool GameIsPause = false;

    public GameObject pauseMenuUI;

    CameraCharacter player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraCharacter>();
    }

    void Update()
    {
        PauseMenuCheck();
    }

    void PauseMenuCheck()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPause)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        player.StartCam();
        GameIsPause = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        player.StartCam();
        GameIsPause = true;
    }
}
