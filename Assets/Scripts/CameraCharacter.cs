﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CameraCharacter : MonoBehaviour
{
    public float speed = 1;
    public float incrementFactor = 0.02f;
    public float spawnHelper = 4.5f;
    public GameObject ball;
    public float ballForce = 700;
    public GameObject DeathMenu;
    public GameObject[] glass;
    public GameObject destory;
    public GameObject pauseMenu;
    PauseMenu gameIsPaused;
    public int ballCounter;
    public int scoreCounter;
    public Text ballCounterText;
    public Text score;
    public Text finalScore;

    //for UI
    public  bool camMoving = false;

    private CharacterController cameraChar;
    private bool collision = false;
    public Camera _cam;



    // Use this for initialization
    void Start()
    {
        StartCam();
        cameraChar = gameObject.transform.GetComponent<CharacterController>();
        _cam = gameObject.GetComponentInChildren<Camera>();
        gameIsPaused = pauseMenu.GetComponent<PauseMenu>();
        UpdateBallCount(ballCounter);
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlChar();
        glass = GameObject.FindGameObjectsWithTag("glass");
    }

    void ControlChar()
    {
        

        if (!collision && camMoving && gameIsPaused.GameIsPause == false)
        {
            cameraChar.Move(Vector3.forward * Time.deltaTime * speed);
            destory.transform.position = Vector3.MoveTowards(destory.transform.position, cameraChar.transform.position, speed);
            speed = speed + incrementFactor;
        }
        else if (collision || !camMoving)
        {
            cameraChar.Move(Vector3.zero);
        }

        if (Input.GetMouseButtonDown(0) && camMoving && gameIsPaused.GameIsPause == false && ballCounter > 0)
        {
            ThrowBall();
            UpdateBallCount(-1);
        }

        if (Input.GetMouseButtonDown(0) && !camMoving)
        {
            ThrowBall();
        }

        gameObject.transform.position -= new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
    }

    void ThrowBall()
    {
        float mousePosx = Input.mousePosition.x;
        float mousePosy = Input.mousePosition.y;

        Vector3 BallInstantiatePoint = _cam.ScreenToWorldPoint(new Vector3(mousePosx, mousePosy, _cam.nearClipPlane + spawnHelper));

        GameObject ballRigid;
        ballRigid = Instantiate(ball, BallInstantiatePoint, transform.rotation) as GameObject;
        ballRigid.GetComponent<Rigidbody>().AddForce(Vector3.forward * ballForce);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("glass"))
        {
            collision = true;
            Debug.Log("Collided with glass!! Man down!!");
            camMoving = false;
            DeathMenu.SetActive(true);
            for (int i = glass.Length - 1; i >= 0; i--)
            {
                GameObject.Destroy(glass[i]);
            }
        }
    }
    public void StartCam()
    {
        camMoving = !camMoving;
    }
    public void Reset()
    {
        SceneManager.LoadScene("Scene1");
        camMoving = true;
        Time.timeScale = 1f;
        gameIsPaused.GameIsPause = false;
    }

    public void UpdateBallCount(int count)
    {
        ballCounter += count;
        ballCounterText.text = "Your Balls: " + ballCounter.ToString();
    }

    public void UpdateScoreCount(int count)
    {
        scoreCounter += count;
        score.text = "Score: " + scoreCounter.ToString();
        finalScore.text = score.text;
    }


    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

}