using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.ParticleSystem;

public class ReturnToPool : MonoBehaviour
{
    Rigidbody2D rb2d;
    public float particleSpeed = 10f;
    TrailRenderer trailRenderer;
    public IObjectPool<GameObject> pool;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Si la particule se déplace à moins de 0.1m/s
        if (rb2d.velocity.magnitude <= 0.5f)
        {
            pool.Release(gameObject);   
        }
    }

    private void OnEnable()
    {
        if(trailRenderer == null)
        {
            trailRenderer = GetComponent<TrailRenderer>();
        }
        trailRenderer.emitting = true;

        if (rb2d == null)
        {
            rb2d = GetComponent<Rigidbody2D>();
        }


        rb2d.velocity = transform.right * particleSpeed;
    }
    private void OnDisable()
    {
        rb2d.velocity = Vector2.zero;
        trailRenderer.Clear();
        trailRenderer.emitting = false;
    }
}
