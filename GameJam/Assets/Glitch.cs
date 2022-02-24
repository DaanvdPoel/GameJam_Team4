using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glitch : MonoBehaviour
{
    bool Glitches;
    public GameObject glitch1;
    public GameObject glitch2;
    public GameObject glitch3;
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
            glitch2.SetActive(true);
            glitch3.SetActive(true);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("lever2"))
        {
            getridofglitch.GetComponent<SpriteRenderer>().sprite = glitchlever;
            glitch1.SetActive(false);
            glitch2.SetActive(false);
            glitch3.SetActive(false);
        }
    }
}
