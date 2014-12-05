using UnityEngine;
using System.Collections;

public class PlayerShoot : MonoBehaviour
{
    public int damagePerShot = 10;
    public float distance = 100f;
    public float timeBetweenShots = 0.2f;
    public int maxShots = 3;
    public Vector3 direction;

    float timer;
    int currentShots;
    float currentLaserSize;

    LineRenderer laserLine;

    void Awake()
    {
        currentLaserSize = distance;
        laserLine = GetComponent<LineRenderer>();
    }
	
    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKey(KeyCode.Space) && timer >= timeBetweenShots 
            && currentShots < maxShots && Time.timeScale != 0)
        {
            Shoot();
        }

        if (timer >= timeBetweenShots * 2)
        {
            laserLine.enabled = false;
        }
    }

    void Shoot()
    {
        timer = 0f;
        //currentShots++;

        laserLine.enabled = true;
        laserLine.SetPosition(0, transform.position);

        RaycastHit2D hit = Physics2D.Raycast(transform.position, direction, distance);

        if (hit.collider != null)
        {
            Debug.Log("Hit!");
            currentLaserSize = Vector2.Distance(hit.point, transform.position);
            laserLine.SetPosition(1, hit.point);
        } else
        {
            laserLine.SetPosition(1, transform.position + direction * distance);
        }
    }

    void OnDestroy()
    {
        currentShots--;
    }
}
