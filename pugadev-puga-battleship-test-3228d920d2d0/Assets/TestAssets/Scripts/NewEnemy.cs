using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewEnemy : EnemysBehavior
{
    public bool isAbleToShoot;   

    public float radius = 2.0f;
    public float radiusSpeed = 0.5f;

    public Transform bombSpawn;

    public GameObject bomb;

    // Start is called before the first frame update
    void Start()
    {
        StartStatus();
        shipTransform = GameObject.Find("AllShip").transform;

        StartCoroutine(ShootBomb());
    }

    // Update is called once per frame
    void Update()
    {
        OrbitAround(shipTransform);        
    }

    public void OrbitAround(Transform objectToOrbit)
    {
        transform.RotateAround(objectToOrbit.position, Vector3.up, status[level - 1].movimentSpeed * Time.deltaTime);
        Vector3 desiredPosition = (transform.position - objectToOrbit.position).normalized * radius + objectToOrbit.position;
        transform.position = Vector3.MoveTowards(transform.position, desiredPosition, Time.deltaTime * radiusSpeed);        
    }

    public void SetIsAbleToShoot(bool isAbleToShoot)
    {
        this.isAbleToShoot = isAbleToShoot;
        if (isAbleToShoot)
        {
            StartCoroutine(ShootBomb());
        }
    }

    public IEnumerator ShootBomb()
    {
        while (isAbleToShoot)
        {
            //Debug.Log("Shot");
            Instantiate(bomb, bombSpawn.position, Quaternion.identity);
            yield return new WaitForSeconds(1 / status[level -1].fireRate);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<ShipController>())
        {
            SetIsAbleToShoot(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<ShipController>())
        {
            SetIsAbleToShoot(false);
        }
    }
}
