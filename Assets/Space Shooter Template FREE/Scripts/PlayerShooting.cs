using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Guns objects in Player hierarchy
[System.Serializable]
public class Guns
{
    public GameObject rightGun;
    public GameObject leftGun;
    public GameObject centralGun;

    [HideInInspector] public ParticleSystem leftGunVFX;
    [HideInInspector] public ParticleSystem rightGunVFX;
    [HideInInspector] public ParticleSystem centralGunVFX;
}

public class PlayerShooting : MonoBehaviour
{
    // 👉 DÒNG QUAN TRỌNG để Bonus.cs không lỗi
    public static PlayerShooting instance;

    [Header("Shooting Settings")]
    [Tooltip("Shooting frequency (higher = faster)")]
    public float fireRate = 8f;

    [Tooltip("Projectile prefab")]
    public GameObject projectileObject;

    private float nextFire = 0f;

    [Header("Weapon Power")]
    [Range(1, 4)]
    public int weaponPower = 1;

    public int maxweaponPower = 4;
    public bool shootingIsActive = true;

    public Guns guns;

    // =========================
    private void Awake()
    {
        // Singleton
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    private void Start()
    {
        // Get particle systems safely
        if (guns.leftGun != null)
            guns.leftGunVFX = guns.leftGun.GetComponent<ParticleSystem>();

        if (guns.rightGun != null)
            guns.rightGunVFX = guns.rightGun.GetComponent<ParticleSystem>();

        if (guns.centralGun != null)
            guns.centralGunVFX = guns.centralGun.GetComponent<ParticleSystem>();
    }

    private void Update()
    {
        if (!shootingIsActive) return;

        // HOLD left mouse / tap screen
        if (Input.GetMouseButton(0))
        {
            if (Time.time >= nextFire)
            {
                MakeAShot();
                nextFire = Time.time + 1f / fireRate;
            }
        }
    }

    // =========================
    // Shooting logic
    void MakeAShot()
    {
        switch (weaponPower)
        {
            case 1:
                CreateLazerShot(
                    projectileObject,
                    guns.centralGun.transform.position,
                    Vector3.zero
                );
                guns.centralGunVFX?.Play();
                break;

            case 2:
                CreateLazerShot(
                    projectileObject,
                    guns.leftGun.transform.position,
                    Vector3.zero
                );
                CreateLazerShot(
                    projectileObject,
                    guns.rightGun.transform.position,
                    Vector3.zero
                );
                guns.leftGunVFX?.Play();
                guns.rightGunVFX?.Play();
                break;

            case 3:
                CreateLazerShot(
                    projectileObject,
                    guns.centralGun.transform.position,
                    Vector3.zero
                );
                CreateLazerShot(
                    projectileObject,
                    guns.leftGun.transform.position,
                    new Vector3(0, 0, 5)
                );
                CreateLazerShot(
                    projectileObject,
                    guns.rightGun.transform.position,
                    new Vector3(0, 0, -5)
                );
                guns.leftGunVFX?.Play();
                guns.rightGunVFX?.Play();
                break;

            case 4:
                CreateLazerShot(
                    projectileObject,
                    guns.centralGun.transform.position,
                    Vector3.zero
                );
                CreateLazerShot(
                    projectileObject,
                    guns.leftGun.transform.position,
                    new Vector3(0, 0, 8)
                );
                CreateLazerShot(
                    projectileObject,
                    guns.rightGun.transform.position,
                    new Vector3(0, 0, -8)
                );
                guns.leftGunVFX?.Play();
                guns.rightGunVFX?.Play();
                break;
        }
    }

    void CreateLazerShot(GameObject lazer, Vector3 pos, Vector3 rot)
    {
        Instantiate(lazer, pos, Quaternion.Euler(rot));
    }

    // =========================
    // Optional: increase weapon power (used by Bonus)
    public void UpgradeWeapon()
    {
        weaponPower++;
        if (weaponPower > maxweaponPower)
            weaponPower = maxweaponPower;
    }
}
