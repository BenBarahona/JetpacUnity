using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public int shotType;
    public int maxShots;
    public float reloadTime;
    public float timeBetweenShots;
    public GameObject shotObject;

    int currentShots;
    float timer;
    float reloadTimer;

    void Awake()
    {
        currentShots = 0;
        reloadTimer = 0f;
        timer = 0f;
    }

	
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKey(KeyCode.Space) && timer >= timeBetweenShots 
            && Time.timeScale != 0 && currentShots < maxShots)
        {
            Shoot();
        }

        if (currentShots >= maxShots)
        {
            Reload();
        }
    }

    void Shoot()
    {
        currentShots++;
        timer = 0f;
        Instantiate(shotObject, transform.position, transform.rotation);
    }

    void Reload()
    {
        reloadTimer += Time.deltaTime;
        if (reloadTimer >= reloadTime)
        {
            reloadTimer = 0;
            currentShots = 0;
        }
    }
}
