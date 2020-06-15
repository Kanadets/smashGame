using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{

     CameraCharacter player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<CameraCharacter>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("glass"))
        {
            Destroy(gameObject, 5f);
            player.UpdateBallCount(1);
            player.UpdateScoreCount(1);
        }

        
    }
}
