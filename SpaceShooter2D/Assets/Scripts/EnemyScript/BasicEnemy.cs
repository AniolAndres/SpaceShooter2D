using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{
    public GameObject projectilePrefab;
    public float projectileSpeed;

    //AI States
    private EnemyState appear;
    private EnemyState attack;
    private EnemyState currentState;
    public void SetStateTo(EnemyState next) { currentState = next; }
    public EnemyState GetAttackState() { return attack; }

    //Movement
    [Header("Polar constants")]
    public float consA = 1.0f;
    public float consB = 1.0f;
    public float consC = 1.0f;

    private EnemyController enemyController;
    private Curve curve;
    private Vector3 curveCenter;
    private float alpha = 0.0f;
    private Vector3 firstPosition;
    private Vector3 spawnPosition;

    public EnemyController GetEC() { return enemyController; }
    public float GetAlpha() { return alpha; }
    public void SetAlpha(float a) { alpha = a; }
    public Vector3 GetCurveCenter() { return curveCenter; }
    public void SetCurve(Curve c) { curve = c; }
    public Curve GetCurve() { return curve; }
    public Vector3 GetSpawnPos() { return spawnPosition; }
    public Vector3 GetFirstPos() { return firstPosition; }

    //Duraitons
    public float appearDuration = 5.0f;

    private void CheckStates(EnemyState previous)
    {
        if(previous != currentState)
        {
            previous.Exit();
            currentState.Enter();
        }
    }

    public void SpawnProjectile()
    {
        BasicProjectile projScript = Instantiate(projectilePrefab, transform.position, Quaternion.identity).GetComponent<BasicProjectile>();
        projScript.SetSpeed(-projectileSpeed);
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyController = gameObject.GetComponent<EnemyController>();
        curveCenter = GameObject.FindGameObjectWithTag("CurveCenter").transform.position;
        curve = new Cardioid();
        alpha = Random.Range(0.0f, Mathf.PI * 2);

        firstPosition = curve.FollowCurve(alpha, consA, consB, consC, curveCenter);
        spawnPosition = gameObject.transform.position;

        appear = new AppearState();
        appear.SetEnemy(this);

        attack = new AttackState();
        attack.SetEnemy(this);

        currentState = appear;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyState previous = currentState;

        currentState.ChangeState();

        CheckStates(previous);

        currentState.UpdateState();
    }
}
