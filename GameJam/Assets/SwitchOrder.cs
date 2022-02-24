using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchOrder : MonoBehaviour
{
    public GameObject flickswitch1;
    public GameObject flickswitch2;
    public GameObject flickswitch3;
    public GameObject flickswitch4;
    public GameObject flickswitch5;

    public GameObject door2;
    public GameObject key2;
    // Start is called before the first frame update
    void Start()
    {
        door2.GetComponent<BoxCollider2D>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        complicated();

        Opendoor2();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("key2"))
        {
            //door2
            door2.GetComponent<BoxCollider2D>().enabled = false;
            Invoke("DoorTimer", 8f);
        }
    }

    void complicated()
    {
        //2 has to be unactive first
        if (flickswitch2.activeSelf && !flickswitch1.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch2.activeSelf && !flickswitch3.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch2.activeSelf && !flickswitch4.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch2.activeSelf && !flickswitch5.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }

        //4 has to be unactive second
        if (flickswitch4.activeSelf && !flickswitch1.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch4.activeSelf && !flickswitch3.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch4.activeSelf && !flickswitch5.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }

        //1 has to be unactive second
        if (flickswitch1.activeSelf && !flickswitch3.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
        if (flickswitch1.activeSelf && !flickswitch5.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }

        //5 has to be unactive second
        if (flickswitch5.activeSelf && !flickswitch3.activeSelf)
        {
            flickswitch1.SetActive(true);
            flickswitch2.SetActive(true);
            flickswitch3.SetActive(true);
            flickswitch4.SetActive(true);
            flickswitch5.SetActive(true);
        }
    }

    void Opendoor2()
    {
        if (!flickswitch1.activeSelf &&
            !flickswitch2.activeSelf &&
            !flickswitch3.activeSelf &&
            !flickswitch4.activeSelf &&
            !flickswitch5.activeSelf)
        {
            key2.SetActive(true);
        }
    }

    //door closes after 8 seconds
    void DoorTimer()
    {
        flickswitch1.SetActive(true);
        flickswitch2.SetActive(true);
        flickswitch3.SetActive(true);
        flickswitch4.SetActive(true);
        flickswitch5.SetActive(true);

        door2.GetComponent<BoxCollider2D>().enabled = true;
    }
}
