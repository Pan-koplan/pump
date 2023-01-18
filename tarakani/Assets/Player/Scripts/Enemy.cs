using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float speed = 7/2;
    public int health;
    public Transform player;
    public GameObject blood;
    private float visionDist = 7;
    [SerializeField] private Transform body;

    public void TakeDmg(int damage)
    {
        health -= damage;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        if (Vector2.Distance(transform.position,player.position) < visionDist)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            var observer = body.position - transform.position;
            var angle = Mathf.Atan2(observer.y, observer.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, 0, angle - 90);
        }

        if (health == 0)
        {
            Destroy(gameObject);
            Shetchik.enemys += 1;
            Instantiate(blood, transform.position, Quaternion.identity);
        }
    }
}
