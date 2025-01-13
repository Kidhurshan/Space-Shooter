using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Float : MonoBehaviour
{
    [SerializeField] private float floatSpeed = 0.5f;          // Speed of floating movement
    [SerializeField] private float floatIntensity = 0.5f;      // Amplitude of the floating movement
    [SerializeField] private float pistolKnockback = 5f;       // Knockback force for pistol
    [SerializeField] private float shotgunKnockback = 10f;     // Knockback force for shotgun
    [SerializeField] private float rifleKnockback = 15f;       // Knockback force for rifle

    private PlayerMain playerMain;
    private Vector3 floatOrigin;             // Current origin point for floating
    private float noiseOffsetX;
    private float noiseOffsetY;
    private bool isShooting = false;

    private void Awake()
    {
        playerMain = GetComponent<PlayerMain>();

        floatOrigin = transform.position;

        // Generate random offsets for Perlin noise to ensure unique movement
        noiseOffsetX = Random.Range(0f, 100f);
        noiseOffsetY = Random.Range(0f, 100f);
    }

    private void Update()
    {
        if (!isShooting)
        {
            HandleFloatingMotion();
        }
    }

    private void HandleFloatingMotion()
    {
        // Generate Perlin noise-based offsets for smooth, random floating movement
        float moveX = (Mathf.PerlinNoise(Time.time * floatSpeed + noiseOffsetX, 0f) - 0.5f) * floatIntensity;
        float moveY = (Mathf.PerlinNoise(0f, Time.time * floatSpeed + noiseOffsetY) - 0.5f) * floatIntensity;

        // Update the position based on the floatOrigin plus the floating offset
        Vector3 floatMotion = new Vector3(moveX, moveY, 0);
        transform.position = floatOrigin + floatMotion;

        // Play idle animation if needed
        playerMain.PlayerSwapAimNormal.PlayIdleAnim();
    }

    // Method to apply knockback in the opposite direction of the fire
    public void ApplyKnockback(Vector3 fireDirection, Weapon.WeaponType weaponType)
    {
        isShooting = true;
        float knockbackForce = 0f;

        // Determine the knockback force based on weapon type
        switch (weaponType)
        {
            case Weapon.WeaponType.Pistol:
                knockbackForce = pistolKnockback;
                break;
            case Weapon.WeaponType.Shotgun:
                knockbackForce = shotgunKnockback;
                break;
            case Weapon.WeaponType.Rifle:
                knockbackForce = rifleKnockback;
                break;
        }

        // Apply force in the opposite direction of the firing direction
        Vector3 knockbackDirection = -fireDirection.normalized * knockbackForce;
        playerMain.PlayerRigidbody2D.AddForce(knockbackDirection, ForceMode2D.Impulse);

        // Update floatOrigin to be the player's new position after knockback
        floatOrigin = transform.position;

        // Allow floating motion to resume after a short delay
        StartCoroutine(ResumeFloatingAfterDelay());
    }

    private IEnumerator ResumeFloatingAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);  // Delay for shooting knockback effect
        isShooting = false;
        floatOrigin = transform.position; // Reset float origin to current position after knockback
    }

    public void Enable()
    {
        enabled = true;
    }

    public void Disable()
    {
        enabled = false;
        playerMain.PlayerRigidbody2D.velocity = Vector3.zero;
    }
}
