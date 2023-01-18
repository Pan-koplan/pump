using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunTarakan : MonoBehaviour
{
    private float speed = 5;
    public int health1;
    public Transform player;
    public GameObject blood;
    private float visionDist = 8;
    [SerializeField] private Transform body;

    public void TakeDmg1(int damage1)
    {
        health1 -= damage1;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) < visionDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            var observer = body.position - transform.position;
            var angle = Mathf.Atan2(observer.y, observer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        if (health1 == 0)
        {
            Shetchik.enemys += 1;
            Destroy(gameObject);
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
}
