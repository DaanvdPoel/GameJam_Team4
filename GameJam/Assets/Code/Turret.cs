using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public GameObject turret;
    public GameObject bullet;
    public Transform spawnpoint;
    public Transform endpoint;
    public bool shot;
    float timer = 120f;
    public enum direction {up,down,left,right};
    public direction d;
    
    // Start is called before the first frame update
    void Start()
    {
        bullet.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (shot)
        {
            bullet.SetActive(true);
            bullet.transform.SetParent(this.transform);
            bullet.transform.Translate(Vector2.right * Time.deltaTime * 20f);
            /*
            if (d = direction.up)
            {
                bullet.transform.Translate(Vector2.up * Time.deltaTime * 20f);
            }

            if (d = direction.down)
            {
                bullet.transform.Translate(Vector2.down * Time.deltaTime * 20f);
            }

            if (d = direction.left)
            {
                bullet.transform.Translate(Vector2.left * Time.deltaTime * 20f);
            }

            if (d = direction.right)
            {
                bullet.transform.Translate(Vector2.right * Time.deltaTime * 20f);
            }*/
        }

        if (!shot)
        {
            bullet.SetActive(false);
            bullet.transform.SetParent(this.transform);
            bullet.GetComponent<Transform>().position = /*new Vector2(xposition, yposition);*/ spawnpoint.position;
        }

        //turns on and off turret
        TimerFunction();
        //shoots
        if(timer <= 0)
        {
            shot = !shot;
        }
    }

    //turns on and off timer
    void TimerFunction()
    {
        timer--;
        if (timer < 0)
        {
            timer = 120f;
        }
    }
}
