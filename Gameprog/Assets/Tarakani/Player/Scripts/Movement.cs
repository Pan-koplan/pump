using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    private float Speed = 9/2;
    private Rigidbody2D rb;
    Vector3 pos;
    Camera cam;
    public float HP;
    public Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        cam = FindObjectOfType<Camera>();
    }

    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        rb.velocity = new Vector2(Speed * x, Speed * y);

        pos = cam.WorldToScreenPoint(transform.position);

        animator.SetFloat("run", Mathf.Abs(x));

        Flip();

        if (HP <= 0)
        {            
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    void Flip()
    {
        if (Input.mousePosition.x < pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.mousePosition.x > pos.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            HP -= 1;
        }
    }
}
