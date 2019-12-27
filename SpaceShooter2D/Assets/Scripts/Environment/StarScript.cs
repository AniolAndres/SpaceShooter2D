using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarScript : MonoBehaviour
{
    //this class will take care of the blinking of the environemnt stars

    public float blinkingTime = 0.5f;
    public float amplitude = 0.5f;
    public GameObject firstStar;
    public GameObject secondStar;
    public float speed = 1.0f;

    private float blinkTimer = 0.0f;
    private float maxScale = 1.5f;
    private float minScale = 0.5f;
    private float lambda = 0.0f;
    private float alpha = 0.0f;
    private float newScale1 = 0.0f;
    private float newScale2 = 0.0f;
    private Vector3 direction = new Vector3(0.0f, 1.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        firstStar.transform.localScale = new Vector3(minScale, minScale, minScale);
        secondStar.transform.localScale = new Vector3(maxScale, maxScale, maxScale);

        float rand = Random.Range(speed / 2.0f, speed * 1.5f);
        speed = rand;
    }

    // Update is called once per frame
    void Update()
    {
        if (blinkTimer > blinkingTime)
        {
            blinkTimer = blinkTimer - blinkingTime;
        }
        else
        {
            blinkTimer += Time.deltaTime;
            lambda = blinkTimer / blinkingTime;
            alpha = lambda * Mathf.PI * 2;

            newScale1 = 1.0f + amplitude * Mathf.Sin(alpha);
            newScale2 = 1.0f - amplitude * Mathf.Sin(alpha);

            firstStar.transform.localScale = new Vector3(newScale1, newScale1, newScale1);
            secondStar.transform.localScale = new Vector3(newScale2, newScale2, newScale2);
        }

        transform.position -= speed * Time.deltaTime * direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "KillBox")
        {
            Destroy(gameObject);
        }
    }

}
