using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public SpriteRenderer hundredThousands;
    public SpriteRenderer tenThousands;
    public SpriteRenderer thousands;
    public SpriteRenderer hundreds;
    public SpriteRenderer tens;
    public SpriteRenderer units;

    public Sprite[] numbers;

    private ResourceManager resManager;

    private int score = 0;
    private int hundredThousandsNumber;
    private int tenThousandsNumber;
    private int thousandsNumber;
    private int hundredsNumber;
    private int tensNumber;
    private int unitsNumber;


    // Start is called before the first frame update
    void Start()
    {
        resManager = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        score = resManager.GetScore();
    }

    // Update is called once per frame
    private void Update()
    {
        if(score != resManager.GetScore())
        {
            score = resManager.GetScore();

            hundredThousandsNumber = score / 100000;
            score -= hundredThousandsNumber * 100000;
            tenThousandsNumber = score / 10000;
            score -= tenThousandsNumber * 10000;
            thousandsNumber = score / 1000;
            score -= thousandsNumber * 1000;
            hundredsNumber = score / 100;
            score -= hundredsNumber * 100;
            tensNumber = score / 10;
            score -= tensNumber * 10;
            unitsNumber = score;

            hundredThousands.sprite = numbers[hundredThousandsNumber];
            tenThousands.sprite = numbers[tenThousandsNumber];
            thousands.sprite = numbers[thousandsNumber];
            hundreds.sprite = numbers[hundredsNumber];
            tens.sprite = numbers[tensNumber];
            units.sprite = numbers[unitsNumber];

            score = resManager.GetScore();
        }
        
    }
}
