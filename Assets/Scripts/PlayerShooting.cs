using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPreFab;
    public float bulletSpeed = 20f;

    // Update is called once per frame
    void Update()
    {
        bulletPreFab.SetActive(false);
        if (Input.GetMouseButtonDown(0))
        {
            bulletPreFab.SetActive(true);
            Shoot();
        }
    }
    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPreFab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.right * bulletSpeed, ForceMode2D.Impulse);
    }
}
