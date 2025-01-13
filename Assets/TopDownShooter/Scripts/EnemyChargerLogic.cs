using System;
using UnityEngine;
using V_AnimationSystem;
using CodeMonkey.Utils;

/*
 * Enemy Charger
 * */
public class EnemyChargerLogic : MonoBehaviour
{

    private enum State
    {
        Normal,
        Charging,
        Attacking,
        Busy,
        Cooldown
    }

    [SerializeField] private float maxChargeSpeed = 100f; // Initial charge speed
    [SerializeField] private float chargeDelayMax = 2f;   // Time between charges
    [SerializeField] private float knockbackDistance = 2f; // Distance to move back after hitting
    [SerializeField] private float chargeSpeedMinimum = 10f; // Minimum charge speed before stopping
    [SerializeField] private float followCooldown = 1.5f; // Cooldown time after each charge

    private EnemyMain enemyMain;
    private Character_Base characterBase;
    private State state;
    private Enemy.IEnemyTargetable enemyTarget;
    private Vector3 chargeDir;
    private float chargeSpeed;
    private float chargeDelay;
    private float followCooldownTimer;
    private Transform aimTransform;

    private void Awake()
    {
        enemyMain = GetComponent<EnemyMain>();
        characterBase = GetComponent<Character_Base>();

        aimTransform = transform.Find("Aim");

        SetStateNormal();
        HideAim();
    }

    private void Start()
    {
        enemyMain.HealthSystem.SetHealthMax(120, true);
        chargeDelay = chargeDelayMax; // Set initial delay to max
    }

    private void Update()
    {
        switch (state)
        {
            case State.Normal:
                chargeDelay -= Time.deltaTime;
                enemyTarget = enemyMain.EnemyTargeting.GetActiveTarget();
                if (enemyTarget != null)
                {
                    Vector3 targetPosition = enemyTarget.GetPosition();
                    if (chargeDelay > 0)
                    {
                        // Too soon to charge, move towards the target
                        enemyMain.EnemyPathfindingMovement.MoveToTimer(targetPosition);
                    }
                    else
                    {
                        if (CanChargeToTarget(targetPosition, enemyTarget.GetGameObject()))
                        {
                            chargeDir = (targetPosition - GetPosition()).normalized;
                            SetAimTarget(targetPosition);
                            ShowAim();
                            chargeSpeed = maxChargeSpeed; // Use max charge speed variable
                            enemyMain.EnemyPathfindingMovement.Disable();
                            characterBase.PlayDodgeAnimation(chargeDir);
                            state = State.Charging;
                        }
                        else
                        {
                            // Cannot see target, move to it
                            enemyMain.EnemyPathfindingMovement.MoveToTimer(targetPosition);
                        }
                    }
                }
                break;
            case State.Charging:
                float chargeSpeedDropMultiplier = 1f;
                chargeSpeed -= chargeSpeed * chargeSpeedDropMultiplier * Time.deltaTime;

                float hitDistance = 3f;
                RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), chargeDir, hitDistance, 1 << GameAssets.i.playerLayer);
                if (raycastHit2D.collider != null)
                {
                    Player player = raycastHit2D.collider.GetComponent<Player>();
                    if (player != null)
                    {
                        player.Damage(enemyMain.Enemy, .6f);
                        player.Knockback(chargeDir, 5f);
                        chargeSpeed = 60f;
                        chargeDir *= -1f; // Move back after hit
                        MoveBackAfterHit();
                    }
                }

                if (chargeSpeed < chargeSpeedMinimum)
                {
                    state = State.Cooldown; // Set to cooldown state after charging
                    followCooldownTimer = followCooldown; // Reset cooldown timer
                    enemyMain.EnemyPathfindingMovement.Enable();
                    chargeDelay = chargeDelayMax; // Reset charge delay
                    HideAim();
                }
                break;
            case State.Cooldown:
                followCooldownTimer -= Time.deltaTime;
                if (followCooldownTimer <= 0)
                {
                    SetStateNormal(); // Return to normal state after cooldown
                }
                break;
            case State.Attacking:
                break;
            case State.Busy:
                break;
        }
    }

    private void FixedUpdate()
    {
        switch (state)
        {
            case State.Charging:
                enemyMain.EnemyRigidbody2D.velocity = chargeDir * chargeSpeed;
                break;
        }
    }

    private bool CanChargeToTarget(Vector3 targetPosition, GameObject targetGameObject)
    {
        float targetDistance = Vector3.Distance(GetPosition(), targetPosition);
        float maxChargeDistance = 50f;
        if (targetDistance > maxChargeDistance)
        {
            return false;
        }

        Vector3 dirToTarget = (targetPosition - GetPosition()).normalized;
        RaycastHit2D raycastHit2D = Physics2D.Raycast(GetPosition(), dirToTarget, targetDistance, ~(1 << GameAssets.i.enemyLayer | 1 << GameAssets.i.ignoreRaycastLayer));
        return raycastHit2D.collider == null || raycastHit2D.collider.gameObject == targetGameObject;
    }

    public void SetAimTarget(Vector3 targetPosition)
    {
        Vector3 aimDir = (targetPosition - transform.position).normalized;
        aimTransform.eulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(aimDir));
    }

    private void ShowAim()
    {
        aimTransform.gameObject.SetActive(true);
    }

    private void HideAim()
    {
        aimTransform.gameObject.SetActive(false);
    }

    private void SetStateNormal()
    {
        state = State.Normal;
    }

    private void MoveBackAfterHit()
    {
        chargeDir *= -1f; // Reverse direction for knockback
        chargeSpeed = knockbackDistance; // Use knockback distance as speed for moving back
    }

    public Vector3 GetPosition()
    {
        return transform.position;
    }
}
