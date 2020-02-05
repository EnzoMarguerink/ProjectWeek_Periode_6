using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnNextSection : MonoBehaviour
{
    public Transform[] nextSection;


    void OnTriggerEnter(Collider other)
    {
        int randomSection = Random.Range(0, nextSection.Length);

        if (other.tag == "Player")
        {
            Debug.Log("Triggered");

            Vector3 spawnPosition = transform.parent.position + new Vector3(0, 0, 18);
            Quaternion spawnRotation = Quaternion.identity;
            Instantiate(nextSection[randomSection], spawnPosition, spawnRotation);
        }
    }
}
