using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Flammable : MonoBehaviour
{
    public GameObject firePs;
    private float timer = 0.25f;
    private bool ignited;
    private List<ParticleSystem> particleSystems = new List<ParticleSystem>();

    public void Ignite(Vector3 ignitePoint)
    {
        timer -= Time.deltaTime;
        if (timer <= 0)
        {
            particleSystems.Add(Instantiate(firePs, ignitePoint - transform.forward, Quaternion.identity).GetComponent<ParticleSystem>());
            timer = 0.25f;
            
            if (!ignited)
            {
                ignited = true;
                StartCoroutine(Finish());
            }
        }
    }

    IEnumerator Finish()
    {
        yield return new WaitForSeconds(5);
        foreach (var ps in particleSystems)  
            ps.Stop();
        Destroy(gameObject);
    }
}
