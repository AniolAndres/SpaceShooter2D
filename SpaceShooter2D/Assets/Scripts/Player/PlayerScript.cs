using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Resources
    private ResourceManager resManager;
    private GameObject mainSpriteGO;
    private GameObject shieldSprite;

    //Combat
    private bool isShielded = false;
    private bool isInvul = false;
    public bool IsInvul() {return isInvul;}

    [Header("Combat stats")]
    [Space(10)]

    public int currentHP;
    public int maxHP = 10;
    public float invulDuration = 2.0f;
    public float blinkInterval = 0.0f;

    private float blinkTimer = 0.0f;
    private float invulTimer = 0.0f;
    

    //Movement
    private float upwardsSpeed = 0.0f;
    private float downwardsSpeed = 0.0f;
    private float leftSpeed = 0.0f;
    private float rightSpeed = 0.0f;

    public void MoveForward(float v) { upwardsSpeed = v; }
    public void MoveDown(float v) { downwardsSpeed = v; }
    public void MoveLeft(float v) { leftSpeed = v; }
    public void MoveRight(float v) { rightSpeed = v; }

    [Header("Movement")]
    [Space(10)]

    public float SpeedModifier = 1.0f;

    //Projectiles
    [Header("Projectile")]
    [Space(10)]

    public float baseProjCooldown;
    public float baseProjSpeed;
    public int baseProjDamage;
    public GameObject basicProjectile;

    public float GetBaseProjCD() { return baseProjCooldown; }
    public float GetBaseProjSpeed() { return baseProjSpeed; }
    public int GetBaseProjDamage() { return baseProjDamage; }

    private bool projReady = true;
    private float projCDTimer = 0.0f;

    public bool IsProjReady() { return projReady; }
    public void SetProjReady(bool r) { projReady = r; }

    private void Start()
    {
        resManager = GameObject.FindGameObjectWithTag("ResourceManager").GetComponent<ResourceManager>();
        mainSpriteGO = GameObject.FindGameObjectWithTag("MainSprite");
        shieldSprite = GameObject.FindGameObjectWithTag("ShieldSprite");
        shieldSprite.SetActive(false);

        currentHP = maxHP;
    }

    public void ShieldPlayer()
    {
        if(!isShielded)
        {
            isShielded = true;
            //Activate shield sprites

            shieldSprite.SetActive(true);
        }
    }

    public void DamagePlayer(int amount)
    {
        if(!isInvul)
        {
            if(isShielded)
            {
                isShielded = false;
                shieldSprite.SetActive(false);
            }
            else
            {
                currentHP -= amount;
                mainSpriteGO.SetActive(false);
                isInvul = true;
            }
        }
    }

    private void UpdateInvulTimer()
    {
        if(invulTimer > invulDuration)
        {
            mainSpriteGO.SetActive(true);
            isInvul = false;
            invulTimer = 0.0f;
            blinkTimer = 0.0f;
        }
        else
        {
            invulTimer += Time.deltaTime;
            UpdateBlinking();
        }
    }

    private void UpdateBlinking()
    {
        if(blinkTimer > blinkInterval)
        {
            bool active = mainSpriteGO.activeInHierarchy;
            mainSpriteGO.SetActive(!active);
            blinkTimer = 0.0f;
        }
        else
        {
            blinkTimer += Time.deltaTime;
        }
    }

    private void UpdateProjectileCD()
    {
        if (projCDTimer > baseProjCooldown)
        {
            projCDTimer = 0.0f;
            projReady = true;
        }
        else
        {
            projCDTimer += Time.deltaTime;
        }
    }

    // Update is called once per frame
    private void Update()
    {
        //Movement
        Vector3 totalSpeed = new Vector3(rightSpeed-leftSpeed, upwardsSpeed - downwardsSpeed, 0);
        transform.position += SpeedModifier * Time.deltaTime * totalSpeed;
        transform.position = resManager.Rectify(transform.position);

        //Combat
        if(isInvul)
        {
            UpdateInvulTimer();
        }

        if(!projReady)
        {
            UpdateProjectileCD();
        }
    }
}
