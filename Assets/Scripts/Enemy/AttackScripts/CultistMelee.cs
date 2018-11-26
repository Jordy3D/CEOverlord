using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CultistMelee : EnemyAttack
{

    public NavMeshAgent agent;
    public SphereCollider hitbox;
    public GameObject fist;
    public GameObject startP, endP;
    bool isPunching;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        hitbox = projectile.GetComponent<SphereCollider>();
        state = Behaviour.Seek;
    }

    

    public override void Attack()
    {
        agent.isStopped = true;
        
        StartCoroutine(ChargingAttack());
        
        //StartCoroutine(DeactivateHitbox());

    }

    

   

    IEnumerator PunchingLerp(float punchTime)
    {
        //enable the hitbox for the attack
        hitbox.enabled = true;
        //the current time
        float time = Time.time;
        //while the current time is less that our saved time + half the time it takes to punch
        while(Time.time < time + punchTime/2)
        {
            //lerp the punch outwards
            fist.transform.position = Vector3.Lerp(startP.transform.position, endP.transform.position, (Time.time - time) / (punchTime/2));
            yield return null;
        }
        //resave the time
        time = Time.time;
        //do same as above but for returning the punch
        while (Time.time < time + punchTime / 2)
        {
            fist.transform.position = Vector3.Lerp(endP.transform.position, startP.transform.position, (Time.time - time) / (punchTime / 2));
            yield return null;
        }
        //set punch back to start pos for good measure
        fist.transform.position = startP.transform.position;
        //turn off hitbox
        DeactivateHitboxF();
    }

    IEnumerator ChargingAttack()
    {
        Color normalColour = this.gameObject.GetComponent<Renderer>().material.color;
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        yield return new WaitForSeconds(0.3f);
        this.gameObject.GetComponent<Renderer>().material.SetColor("_Color", normalColour);
        StartCoroutine(PunchingLerp(0.2f));
    }

    void DeactivateHitboxF()
    {
        hitbox.enabled = false;
        agent.isStopped = false;
    }
}
