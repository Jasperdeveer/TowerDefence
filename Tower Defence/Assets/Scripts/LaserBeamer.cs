using UnityEngine;

public class LaserBeamer : Turret
{

    [HeaderAttribute("Use Laser")]
    public bool useLaser = true;

    public int damageOverTime = 30;
    public float slowAmount = .5f;

    public LineRenderer LineRenderer;
    public ParticleSystem impactEffect;
    public Light impactLight;

    void Update()
    {
        LockOnTarget();

        if (Target != null)
        {
            Laser();
            LineRenderer.enabled = true;
            impactLight.enabled = true;
        }
        if(Target == null)
        {
            LineRenderer.enabled = false;
            impactEffect.Stop();
            impactLight.enabled = false;
        }

    }
    void Laser()
    {

        TargetEnemy.TakeDamage(damageOverTime * Time.deltaTime);
        TargetEnemy.Slow(slowAmount);

        if (!LineRenderer.enabled)
        {
            LineRenderer.enabled = true;
            impactEffect.Play();
            impactLight.enabled = true;
        }
        LineRenderer.SetPosition(0, firePoint.position);
        LineRenderer.SetPosition(1, Target.position);

        Vector3 dir = firePoint.position - Target.position; // vector3 for the impactEffect
        impactEffect.transform.position = Target.position + dir.normalized;
        impactEffect.transform.rotation = Quaternion.LookRotation(dir);


    }

}
