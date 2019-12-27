using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Resources
    private ResourceManager resManager;
    private GameObject mainSpriteGO;
    private GameObject shieldSprite;
    private AudioSource audioSource;

    //Combat
    private bool isShielded = false;
    private bool isInvul = false;
    private bool isBoosted = false;
    public bool IsInvul() {return isInvul;}
    public bool IsBoosted() { return isBoosted; }

    [Header("Combat stats")]
    [Space(10)]

    public int currentHP;
    public int maxHP = 10;
    public float invulDuration = 2.0f;
    public float blinkInterval = 0.0f;
    public float boostDuration = 5.0f;
    public AudioClip shotSound;
    public AudioClip powerUpSound;

    private float boostTimer = 0.0f;
    private float blinkTimer = 0.0f;
    private float invulTimer = 0.0f;

    //Death
    [Header("Death")]
    [Space(10)]
    public float deathDuration = 5.0f;
    public GameObject ExplosionPrefab;

    private float deathTimer = 0.0f;
    private bool activeSprites = true;

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
    public Sprite[] mainSprites;

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
        audioSource = gameObject.GetComponent<AudioSource>();
        mainSpriteGO = GameObject.FindGameObjectWithTag("MainSprite");
        int randSprite = Random.Range(0, 12);
        mainSpriteGO.GetComponent<SpriteRenderer>().sprite = mainSprites[randSprite];

        shieldSprite = GameObject.FindGameObjectWithTag("ShieldSprite");
        shieldSprite.SetActive(false);

        currentHP = maxHP;
    }

    public void PlayShotAudio()
    {
        audioSource.PlayOneShot(shotSound);
    }

    public void PlayPowerUpAudio()
    {
        audioSource.PlayOneShot(powerUpSound);
    }

    //Shoot twice instead of once
    public void BoostPlayer()
    {
        PlayPowerUpAudio();

        if(isBoosted)
        {
            boostTimer = 0.0f;
        }
        else
        {
            isBoosted = true;
        }
    }

    //Shield player ignoring next instance of damage
    public void ShieldPlayer()
    {
        if (!isShielded)
        {
            isShielded = true;

            PlayPowerUpAudio();
            //Activate shield sprites

            shieldSprite.SetActive(true);
        }
    }

    //Dammage the player
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

    //Heal the player
    public void HealPlayer(int amount)
    {
        if(currentHP > 0)
        {
            PlayPowerUpAudio();

            currentHP += amount;

            if(currentHP > maxHP)
            {
                currentHP = maxHP;
            }
        }
    }

    //When hit player will have a brief invulnerability
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

    //Will handle the sprite blink
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

    //Will handle if the projectile is ready
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

    //Will tell the resMAnager that player died and it's ready to change scene back
    private void UpdateDeathTimer()
    {
        if(deathTimer > deathDuration)
        {
            resManager.PlayerIsDead(true);
            gameObject.SetActive(false);
        }
        else
        {
            deathTimer += Time.deltaTime;

            if(activeSprites)
            {
                Instantiate(ExplosionPrefab, transform.position, Quaternion.identity);

                mainSpriteGO.SetActive(false);
                activeSprites = false;
            }
        }
    }

    //Will update the boost status of the player
    private void UpdateBoostTimer()
    {
        if(boostTimer > boostDuration)
        {
            isBoosted = false;
            boostTimer = 0.0f;
        }
        else
        {
            boostTimer += Time.deltaTime;
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
        if(isInvul && currentHP > 0)
        {
            UpdateInvulTimer();
        }

        if(!projReady && currentHP > 0)
        {
            UpdateProjectileCD();
        }

        if(currentHP <= 0)
        {
            UpdateDeathTimer();
        }

        if(isBoosted)
        {
            UpdateBoostTimer();
        }
    }
}
