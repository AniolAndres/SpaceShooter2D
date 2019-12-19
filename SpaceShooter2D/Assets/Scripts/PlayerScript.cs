using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
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
    public float baseProjDamage;
    public GameObject basicProjectile;

    public float GetBaseProjCD() { return baseProjCooldown; }
    public float GetBaseProjSpeed() { return baseProjSpeed; }
    public float GetBaseProjDamage() { return baseProjDamage; }

    // Update is called once per frame
    void Update()
    {
        Vector3 totalSpeed = new Vector3(rightSpeed-leftSpeed, upwardsSpeed - downwardsSpeed, 0);
        transform.position += SpeedModifier * Time.deltaTime * totalSpeed;
    }
}
