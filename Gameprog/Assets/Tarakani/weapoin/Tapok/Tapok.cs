using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tapok : MonoBehaviour
{
    public Transform Hit;
    public LayerMask enemy;
    public float rangeHit;
    private int damage = 1;
    private float ReloadHit;
    public float startReloadHit;
    public Animator anim;
   
    void Start()
    {
        
        
    }

    void Update()
    {
        if (ReloadHit <=0)
        { 
            if (Input.GetMouseButtonDown(0))
            {
                anim.SetTrigger("hit");
                Collider2D[] enemies = Physics2D.OverlapCircleAll(Hit.position, rangeHit, enemy);
                for (int i = 0; i < enemies.Length; i++)
                {
                    enemies[i].GetComponent<GunTarakan>().TakeDmg(damage);
                }
                ReloadHit = startReloadHit;
            }
         
        }
        else
        {
            ReloadHit -= Time.deltaTime;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(Hit.position, rangeHit);
    }
}
