using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBomb : MonoBehaviour
{
    GameObject target;
    bool colidingWithPlayer;
    Vector3 positionToGo;

    public float speed;

    public bool exploded;

    public float damage;

    public ParticleSystem explosionParticles;
    
    // Start is called before the first frame update
    void Start()
    {
        target = GameObject.Find("AllShip");
        positionToGo = target.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, positionToGo, speed * Time.deltaTime);
        float distance = Vector3.Distance(transform.position, positionToGo);
        if (distance <= 0f && !exploded)
        {
            Explode();
        }        
    }    

    public void Explode()
    {
        exploded = true;
        Instantiate(explosionParticles, transform.position, Quaternion.identity);
        float distanceToTarget = Vector3.Distance(transform.position, target.transform.position);
        if (distanceToTarget <= GetComponent<SphereCollider>().radius)
        {
            if (target.GetComponent<ShipController>())
            {
                target.GetComponent<ShipController>().TakeDamage(damage);
            }
        }
        Destroy(gameObject);
    }

    private void OnTriggerStay(Collider other)
    {
        /*if (other.GetComponent<ShipController>() && exploded)
        {
            colidingWithPlayer = true;
        }  */      
    }

    private void OnTriggerExit(Collider other)
    {
        /*if (other.GetComponent<ShipController>() && exploded)
        {
            colidingWithPlayer = false;
        }*/
    }
}
