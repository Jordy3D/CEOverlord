using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicGlove : Glove
{
    public SphereCollider hitbox;
    bool isCoRunning;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>();
        hitbox = transform.GetChild(0).GetComponent<SphereCollider>();
        
        comboLimit = 3;
        player.comboLimit = comboLimit;
        
    }

    public override void Attack()
    {
        Debug.Log("This is basic glove");
        hitbox.gameObject.SetActive(true);
        //hitbox.enabled = true;
        CallDeactivateHitbox();
    }

    IEnumerator DeactivateHitbox()
    {
        isCoRunning = true;
        yield return new WaitForSeconds(0.2f);
        hitbox.gameObject.SetActive(false);
        //hitbox.enabled = false;
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
