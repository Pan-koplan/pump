using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private float speed = 18;
    private int damage = 1;
    public LayerMask notMissed;
    public float distance;
    public float EndFly;

    void Start()
    {
        Invoke("DestroyBullet", EndFly);
    }

    void DestroyBullet()
    {
        Destroy(gameObject);
    }

    void Update()
    {
        RaycastHit2D whoTakeHit = Physics2D.Raycast(transform.position, transform.up, distance, notMissed);
        if (whoTakeHit.collider != null)
        {
            if (whoTakeHit.collider.CompareTag("Enemy"))
            {
                whoTakeHit.collider.GetComponent<Enemy>().TakeDmg(damage);
            }
            Destroy(gameObject);
        }
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}