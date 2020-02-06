using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Animations;

public class Player : MonoBehaviour
{
    public KeyCode MoveL;
    public KeyCode MoveR;

    public float horiVel = 0;
    public int LaneNum = 2;

    public string ControlLocked = "N";

    private bool gotHit = false;
    private int health = 100;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.C))
        {
            anim.Play("Active");
        }

    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Lethal")
        {
            SceneManager.LoadScene(0);
        }
        //if (other.gameObject.tag == "Enemy")
        //{
        //    //if player didn't get hit, start new coroutine
        //    if (!gotHit)
        //        StartCoroutine(TakeDamage(20, 6));
        //}

    }
    //IEnumerator TakeDamage(int damage, int seconds)
    //{
    //    gotHit = true;
    //    //substract damage from health
    //    health -= damage;
    //    //wait for x seconds
    //    yield return new WaitForSeconds(seconds);
    //    //after x seconds, the player can get hit again
    //    gotHit = false;
    //}

    IEnumerator stopSlide()
    {
        yield return new WaitForSeconds(.5f);
        horiVel = 0;
        ControlLocked = "N";
    }
   
}
