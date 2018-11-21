using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGlove : Glove
{
    public SphereCollider hitbox;
    bool isCoRunning;
    public GameObject fist;
    public Transform startP, endP;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        
        hitbox = transform.GetChild(0).GetComponent<SphereCollider>();
        fist = hitbox.gameObject;
        startP = transform.GetChild(1).GetComponent<Transform>();
        endP = transform.GetChild(2).GetComponent<Transform>();

        comboLimit = 3;
        coolDown = 0.5f;
        comboWindow = 0.2f;
        player.comboLimit = comboLimit;
        player.comboTimeLimit = comboWindow;
        player.coolDownLimit = coolDown;
        
    }

    public override void Attack()
    {
        Debug.Log("This is basic glove");
        //hitbox.gameObject.SetActive(true);
        hitbox.enabled = true;
        StartCoroutine(PunchingLerp(0.2f));
        CallDeactivateHitbox();
    }

    IEnumerator DeactivateHitbox()
    {
        isCoRunning = true;
        yield return new WaitForSeconds(0.2f);
        //hitbox.gameObject.SetActive(false);
        hitbox.enabled = false;
        isCoRunning = false;
    }

    void CallDeactivateHitbox()
    {
        if (isCoRunning)
        {
            StopCoroutine(DeactivateHitbox());
        }
        StartCoroutine(DeactivateHitbox());
    }

    IEnumerator PunchingLerp(float punchTime)
    {
        float time = Time.time;
        while (Time.time < time + punchTime / 2)
        {
            fist.transform.position = Vector3.Lerp(startP.transform.position, endP.transform.position, (Time.time - time) / (punchTime / 2));
            yield return null;
        }
        time = Time.time;
        while (Time.time < time + punchTime / 2)
        {
            fist.transform.position = Vector3.Lerp(endP.transform.position, startP.transform.position, (Time.time - time) / (punchTime / 2));
            yield return null;
        }
        fist.transform.position = startP.transform.position;
    }
}
