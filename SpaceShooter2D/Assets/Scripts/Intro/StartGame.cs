using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Color highLightColor;

    private Color usualColor;
    private SpriteRenderer mySprite;

    private void OnMouseEnter()
    {
        mySprite.color = highLightColor;
    }

    private void OnMouseExit()
    {
        mySprite.color = usualColor;
    }

    private void OnMouseDown()
    {
        SceneManager.LoadScene("FirstLevel");
    }

    // Start is called before the first frame update
    void Start()
    {
        mySprite = gameObject.GetComponent<SpriteRenderer>();
        usualColor = mySprite.color;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
