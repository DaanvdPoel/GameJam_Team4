using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    bool Glitches;
    public GameObject glitch1;
    public GameObject getridofglitch;
    public Sprite glitchlever;

    // Start is called before the first frame update
    void Start()
    {
        Glitches = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Glitches)
        {
            glitch1.SetActive(true);

        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Glitches = false;
            getridofglitch.GetComponent<SpriteRenderer>().sprite = glitchlever;
            glitch1.SetActive(false);
        }    
    }
}
