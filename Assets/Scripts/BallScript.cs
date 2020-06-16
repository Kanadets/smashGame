using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class BallScript : MonoBehaviour
{
     PauseMenu pauseMenu;
     CameraCharacter player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraCharacter>();
        pauseMenu = GameObject.FindGameObjectWithTag("GameController").GetComponent<PauseMenu>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("glass"))
        {
            Destroy(gameObject, 5f);
            player.UpdateBallCount(1);
            player.UpdateScoreCount(1);
        }

        if(other.CompareTag("PlayTab"))
        {
            PlayGame();
        }

        if (other.CompareTag("ExitTap"))
        {
            QuitGame();
        }

        if (other.CompareTag("RestartTab"))
        {
            player.Reset();
        }

        if (other.CompareTag("ContinueTab"))
        {
            pauseMenu.Resume();
        }

        if (other.CompareTag("MenuTab"))
        {
            SceneManager.LoadScene(0);
        }

    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
