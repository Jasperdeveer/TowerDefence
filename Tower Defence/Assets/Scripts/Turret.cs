using UnityEngine;

public class Turret : MonoBehaviour
{

    private Transform target;
    public Transform Target
    {
        get { return this.target; }
        set { this.target = value; }
    }
    private Enemy targetEnemy;
    public Enemy TargetEnemy
    {
        get { return this.targetEnemy; }
        set { this.targetEnemy = value; }
    }

    [Header("General")]
    public float range = 15f;
    [HeaderAttribute("Use Bullets (default)")]
    public float fireRate = 1f;
    private float fireCountdown = 0f;
    public GameObject bulletPrefab;




    [Header("Unity setup fields")]

    public string enemyTag = "Enemy";

    public Transform partToRotate;
    public float turnSpeed = 10f;


    public Transform firePoint;



    // Use this for initialization
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }
    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance) // check the closest enemy
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }
        if (nearestEnemy != null && shortestDistance <= range)
        {
            Target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.GetComponent<Enemy>();
        }
        else
        {
            Target = null;
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTarget();

        //target lock-on
        LockOnTarget();

            if (fireCountdown <= 0f)
            {
                shoot();
                fireCountdown = 1f / fireRate;
            }
            fireCountdown -= Time.deltaTime;
        



    }

    public void LockOnTarget()
    {
        Vector3 dir = Target.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles; // lerp is making the turret move smooth
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }



    void shoot()
    {
        Debug.Log("Shoot!");
        GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Bullet bullet = bulletGO.GetComponent<Bullet>();

        if (bullet != null)
        {
            bullet.Seek(Target);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
