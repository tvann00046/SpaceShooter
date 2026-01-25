using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Click chuột trái
        {
            Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        }
    }
}
