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
    public float amplitude;
    public float resizeTime;
    public Color newScoreColor;

    private ResourceManager resManager;

    private int score = 0;
    private int hundredThousandsNumber;
    private int tenThousandsNumber;
    private int thousandsNumber;
    private int hundredsNumber;
    private int tensNumber;
    private int unitsNumber;
    private float growTimer = 0.0f;
    private bool scoreChanged = false;
    private float lambda = 0.0f;

    private void ChangeSpritesColor(float lambda)
    {
        hundredThousands.color = Color.Lerp(Color.white, newScoreColor, lambda);
        tenThousands.color = Color.Lerp(Color.white, newScoreColor, lambda);
        thousands.color = Color.Lerp(Color.white, newScoreColor, lambda);
        hundreds.color = Color.Lerp(Color.white, newScoreColor, lambda);
        tens.color = Color.Lerp(Color.white, newScoreColor, lambda);
        units.color = Color.Lerp(Color.white, newScoreColor, lambda);
    }

    // Start is called before the first frame update
    void Start()
    {
        resManager = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        score = resManager.GetScore();
    }

    // Update is called once per frame
    private void Update()
    {
        // TODO: Put everything UI related in a Canvas
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

            scoreChanged = true;
            growTimer = 0.0f;
            lambda = 0.0f;
        }

        if(scoreChanged)
        {
            if(lambda >= 1.0f)
            {
                scoreChanged = false;
            }
            else
            {
                growTimer += Time.deltaTime;
                lambda = growTimer / resizeTime;

                if(lambda > 1.0f)
                {
                    lambda = 1.0f;
                }

                Color newColor = Color.Lerp(newScoreColor, Color.white, lambda);

                float newLambda = amplitude * (-(lambda*lambda) * 4.0f + lambda * 4.0f);
                float newScale = 1.0f + newLambda;

                ChangeSpritesColor(newLambda);

                Vector3 newScaleVector = new Vector3(newScale, newScale, newScale);
                gameObject.transform.localScale = newScaleVector;
            }
        }     
    }
}
