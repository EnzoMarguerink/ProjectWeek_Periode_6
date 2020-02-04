using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public KeyCode MoveL;
    public KeyCode MoveR;

    public float horiVel = 0;
    public int LaneNum = 2;

    public string ControlLocked = "N";
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(horiVel, 0, 5);

        if ((Input.GetKeyDown(MoveL)) && (LaneNum>1) && (ControlLocked == "N"))
        {
            horiVel = -2;
            StartCoroutine(stopSlide());
            LaneNum -= 1;
            ControlLocked = "Y";
        }

        if ((Input.GetKeyDown(MoveR)) && (LaneNum < 3) && (ControlLocked == "N"))
        {
            horiVel = 2;
            StartCoroutine(stopSlide());
            LaneNum += 1;
            ControlLocked = "Y";
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lethal")
        {
            Destroy(gameObject);
            
        }

    }

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horiVel = 0;
        ControlLocked = "N";
    }
   
}
