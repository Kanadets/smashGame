using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public float spawnHelper = 4.5f;
    public GameObject ball;
    public float ballForce = 700;

    private Camera _cam;


    // Use this for initialization
    void Start()
    {
        _cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        ThrowBall();
    }

    void ThrowBall()
    {
        //Local floats
        float mousePosx = Input.mousePosition.x;
        float mousePosy = Input.mousePosition.y;

        //Confusing part :-)
        Vector3 BallInstantiatePoint = _cam.ScreenToWorldPoint(new Vector3(mousePosx, mousePosy, _cam.nearClipPlane + spawnHelper));


        if (Input.GetMouseButtonDown(0))
        {
            GameObject ballRigid;
            ballRigid = Instantiate(ball, BallInstantiatePoint, transform.rotation) as GameObject;
            ballRigid.GetComponent<Rigidbody>().AddForce(Vector3.forward * ballForce);
        }
    }

    

}
