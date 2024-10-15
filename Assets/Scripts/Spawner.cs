using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using static UnityEngine.ParticleSystem;

public class Spawner : MonoBehaviour
{

    [Header("Spawn")]
    public int spawnRate;
    [Tooltip("Le rayon de spawn des particules"), Range(0,354)]
    public float spawnRadius;


    [Header("Pool setup")]
    public int maxPooledItem;
    public GameObject prefabParticle;
    public IObjectPool<GameObject> poolParticles;

    private float chrono = 0f;

    // Start is called before the first frame update
    void Start()
    {
        poolParticles = new ObjectPool<GameObject>(CreateItem, OnTakeItem, OnReturnToPool, OnDestroyitem,maxSize: maxPooledItem);

        for (int i = 0; i< maxPooledItem; i++)
        {
            poolParticles.Release(CreateParticle());
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (chrono >= 1/spawnRate )
        {
            //Vector2 randomCircle = Random.insideUnitCircle * Camera.main.orthographicSize;

            poolParticles.Get();
            
            chrono = 0f;
        }
        else
        {
            chrono += Time.deltaTime;
        }
    }



    private GameObject CreateParticle()
    {
        GameObject particle = Instantiate(prefabParticle);
        ReturnToPool rtp = particle.AddComponent<ReturnToPool>();
        rtp.pool = poolParticles;
        return particle;
    }

    public GameObject CreateItem()
    {
        return CreateParticle();
    }

    // Called when an item is taken from the pool using Get
    void OnTakeItem(GameObject item)
    {
        item.transform.SetPositionAndRotation((Vector2)transform.position + Random.insideUnitCircle * spawnRadius, transform.rotation);
        item.SetActive(true);
    }

    // Called when an item is returned to the pool using Release
    void OnReturnToPool(GameObject item)
    {
        item.SetActive(false);
    }


    // If the pool capacity is reached then any items returned will be destroyed.
    // We can control what the destroy behavior does, here we destroy the GameObject.
    void OnDestroyitem(GameObject item)
    {
        Destroy(item);
    }
}
