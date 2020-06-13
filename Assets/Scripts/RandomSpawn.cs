using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RandomSpawn : MonoBehaviour
{

    public GameObject GlassPrefab;
    public int howManyItems;

    public Vector3 center;
    public Vector3 size;

    GameObject[] obj;

    // Update is called once per frame
    void Update()
    {
        obj = GameObject.FindGameObjectsWithTag("glass");
        if (obj.Length <= howManyItems)
        {
            SpawnGlass();
        }
        center.z = gameObject.transform.position.z + 0.02f;
    }

    public void SpawnGlass()
    {
        Vector3 pos = center + new Vector3(UnityEngine.Random.Range(-size.x / 2, size.x / 2), UnityEngine.Random.Range(-size.y / 2, size.y / 2), UnityEngine.Random.Range(-size.z / 2, size.z / 2));
        Instantiate(GlassPrefab, pos, GlassPrefab.transform.rotation);      
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(10, 0, 0, 0.5f);
        Gizmos.DrawCube(center, size);
    }

}
