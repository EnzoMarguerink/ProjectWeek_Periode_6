using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCam : MonoBehaviour
{
    //// Start is called before the first frame update
    //void Start()
    //{
    //    GetComponent<Rigidbody>().velocity = new Vector3(0, -1.9f, 5);
    //}

    //// Update is called once per frame
    //void Update()
    //{

    //}
    public Vector3 myPos;
    public Transform myPlay;

    public void Update()
    {
        transform.position = myPlay.position + myPos;
    }
}
