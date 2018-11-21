using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGlove : Glove
{
    public SphereCollider hitbox;
    public MeshRenderer hitRender;
    bool isCoRunning;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        
        hitbox = transform.GetChild(0).GetComponent<SphereCollider>();
        hitRender = transform.GetChild(0).GetComponent<MeshRenderer>();
        
        comboLimit = 3;
        player.comboLimit = comboLimit;
        
        
    }

    public override void Attack()
    {
        Debug.Log("This is basic glove");
        //hitbox.gameObject.SetActive(true);
        hitbox.enabled = true;
        hitRender.enabled = true;
        CallDeactivateHitbox();
    }

    IEnumerator DeactivateHitbox()
    {
        isCoRunning = true;
        yield return new WaitForSeconds(0.2f);
        //hitbox.gameObject.SetActive(false);
        hitbox.enabled = false;
        hitRender.enabled = false;
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
}
