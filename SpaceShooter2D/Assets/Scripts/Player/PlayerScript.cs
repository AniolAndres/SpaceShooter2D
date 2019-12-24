using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Resources

    private ResourceManager resManager;

    //Movement
    private float upwardsSpeed = 0.0f;
    private float downwardsSpeed = 0.0f;
    private float leftSpeed = 0.0f;
    private float rightSpeed = 0.0f;

    private float topScreen = 0.0f;
    private float bottomScreen = 0.0f;
    private float leftScreen = 0.0f;
    private float rightScreen = 0.0f;

    public void MoveForward(float v) { upwardsSpeed = v; }
    public void MoveDown(float v) { downwardsSpeed = v; }
    public void MoveLeft(float v) { leftSpeed = v; }
    public void MoveRight(float v) { rightSpeed = v; }

    [Header("Movement")]
    [Space(10)]

    public float SpeedModifier = 1.0f;

    private Vector3 Rectify(Vector3 position)
    {
        if(position.x > rightScreen)
        {
            position.x = rightScreen;
        }
        else if(position.x < leftScreen)
        {
            position.x = leftScreen;
        }

        if(position.y < bottomScreen)
        {
            position.y = bottomScreen;
        }
        else if(position.y > topScreen)
        {
            position.y = topScreen;
        }

        return position;
    }

    //Projectiles
    [Header("Projectile")]
    [Space(10)]

    public float baseProjCooldown;
    public float baseProjSpeed;
    public float baseProjDamage;
    public GameObject basicProjectile;

    public float GetBaseProjCD() { return baseProjCooldown; }
    public float GetBaseProjSpeed() { return baseProjSpeed; }
    public float GetBaseProjDamage() { return baseProjDamage; }

    private void Start()
    {
        resManager = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();

        float vertExtent = Camera.main.orthographicSize;
        float horzExtent = vertExtent * Screen.width / Screen.height;

        //Vector3 camPosition = Camera.main.transform.position;

        topScreen = vertExtent - resManager.topDownMargin;
        bottomScreen = -vertExtent + resManager.topDownMargin;
        leftScreen = -horzExtent + resManager.leftRightMargin;
        rightScreen = horzExtent - resManager.leftRightMargin;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 totalSpeed = new Vector3(rightSpeed-leftSpeed, upwardsSpeed - downwardsSpeed, 0);

        transform.position += SpeedModifier * Time.deltaTime * totalSpeed;

        transform.position = Rectify(transform.position);
    }
}
