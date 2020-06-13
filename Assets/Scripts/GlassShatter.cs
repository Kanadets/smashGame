using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassShatter : MonoBehaviour
{
    public GameObject[] shatteredObject;

    [System.Obsolete]
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("destructive"))
        {
            //picks a random gameobject in the array
            int objectIndex = UnityEngine.Random.RandomRange(0, shatteredObject.Length);
            Instantiate(shatteredObject[objectIndex], transform.position, shatteredObject[objectIndex].transform.rotation);
            Destroy(gameObject);
        }

        if (other.CompareTag("glass"))
        {
            Destroy(gameObject);
        }
            
    }

}
