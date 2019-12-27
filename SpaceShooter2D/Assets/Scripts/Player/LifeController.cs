using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeController : MonoBehaviour
{
    public GameObject first;
    public GameObject second;
    public GameObject third;
    public GameObject fourth;
    public GameObject fifth;

    private PlayerScript pScript;
    private ResourceManager resManager;

    private int prevHP = 0;

    // Start is called before the first frame update
    void Start()
    {
        resManager = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        pScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>();
        prevHP = pScript.currentHP;
    }

    // Update is called once per frame
    void Update()
    {
        if(prevHP != pScript.currentHP)
        {
            switch(pScript.currentHP)
            {
                case 0:

                    first.SetActive(false);
                    second.SetActive(false);
                    third.SetActive(false);
                    fourth.SetActive(false);
                    fifth.SetActive(false);

                    break;
                case 1:

                    first.SetActive(false);
                    second.SetActive(false);
                    third.SetActive(false);
                    fourth.SetActive(false);
                    fifth.SetActive(true);

                    break;
                case 2:

                    first.SetActive(false);
                    second.SetActive(false);
                    third.SetActive(false);
                    fourth.SetActive(true);
                    fifth.SetActive(true);

                    break;
                case 3:

                    first.SetActive(false);
                    second.SetActive(false);
                    third.SetActive(true);
                    fourth.SetActive(true);
                    fifth.SetActive(true);

                    break;
                case 4:

                    first.SetActive(false);
                    second.SetActive(true);
                    third.SetActive(true);
                    fourth.SetActive(true);
                    fifth.SetActive(true);

                    break;
                case 5:

                    first.SetActive(true);
                    second.SetActive(true);
                    third.SetActive(true);
                    fourth.SetActive(true);
                    fifth.SetActive(true);

                    break;
            }

        }

        prevHP = pScript.currentHP;
    }
}
