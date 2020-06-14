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
    public GameObject button;
    public GameObject glass;
    public GameObject destory;
    public GameObject pauseMenu;
    PauseMenu gameIsPaused;
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
        
    }

    // Update is called once per frame
    void Update()
    {
        ControlChar();
    }

    void ControlChar()
    {
        

        float mousePosx = Input.mousePosition.x;
        float mousePosy = Input.mousePosition.y;
       
        Vector3 BallInstantiatePoint = _cam.ScreenToWorldPoint(new Vector3(mousePosx, mousePosy, _cam.nearClipPlane + spawnHelper));

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

        if (Input.GetMouseButtonDown(0) && camMoving && gameIsPaused.GameIsPause == false)
        {
            GameObject ballRigid;
            ballRigid = Instantiate(ball, BallInstantiatePoint, transform.rotation) as GameObject;
            ballRigid.GetComponent<Rigidbody>().AddForce(Vector3.forward * ballForce);
        }

        gameObject.transform.position -= new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, 0f);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("glass"))
        {
            collision = true;
            Debug.Log("Collided with glass!! Man down!!");
            camMoving = false;
            
            
            button.SetActive(true);
        }
    }
    public void StartCam()
    {
        camMoving = !camMoving;
    }
    public void Reset()
    {
        SceneManager.LoadScene("Scene1");
    }

}