using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUps : MonoBehaviour
{
    bool havekey;
    private bool havekey2;
    public GameObject door;
    public GameObject door15;
    public GameObject key;
    public GameObject key2;




    // Start is called before the first frame update
    void Start()
    {
        havekey  = false;
        havekey2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        DoIHaveKey();
    }

    //Pick up key
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //to get the key
        if (collision.gameObject.CompareTag("key"))
        {
            //door1
            havekey = true;
            door.GetComponent<BoxCollider2D>().enabled = false;
            key.transform.SetParent(this.transform);
            key.GetComponent<BoxCollider2D>().enabled = false;
        }

        //to get the key
        if (collision.gameObject.CompareTag("key2"))
        {
            //door1
            havekey2 = true;
            door15.GetComponent<BoxCollider2D>().enabled = false;
            key2.transform.SetParent(this.transform);
            key2.GetComponent<BoxCollider2D>().enabled = false;
        }

        if (collision.gameObject.CompareTag("door"))
        {
            key.transform.SetParent(null);
            key.GetComponent<Transform>().position = new Vector2(-2f, 4f);
            havekey = false;
            key.GetComponent<BoxCollider2D>().enabled = true;
            door.GetComponent<BoxCollider2D>().enabled = false;

        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        // they can go into a place but cant get back out --ONE WAY DOOR--
        if (collision.gameObject.CompareTag("enterance"))
        {
            blockenterance();

        }
    }

    //what happens when you have the key
    void DoIHaveKey()
    {
        // Cant walk by places without a key
        if (havekey)
        {
            door.GetComponent<BoxCollider2D>().enabled = false;
            key.transform.SetParent(this.transform);
            key.GetComponent<BoxCollider2D>().enabled = false;
        }
        // Cant walk by places without a key
        if (havekey2)
        {
            door15.GetComponent<BoxCollider2D>().enabled = false;
            key2.transform.SetParent(this.transform);
            key2.GetComponent<BoxCollider2D>().enabled = false;
        }
    }

    //cant get back past the door
    void blockenterance()
    {
        if (!door.GetComponent<BoxCollider2D>().enabled)
        {
            key.SetActive(false);
        }

        if (!door15.GetComponent<BoxCollider2D>().enabled)
        {
            key2.SetActive(false);
        }
    }  
}
