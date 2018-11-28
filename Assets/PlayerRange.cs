using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRange : MonoBehaviour
{
    public GameObject rangeTarget;
    public float range;

    PlayerStats stats;
    // Use this for initialization
    void Start()
    {
        stats = GetComponent<PlayerStats>();
        range = stats.attackRange;

        UpdateRange(range);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRange(range);
    }

    void UpdateRange(float range)
    {
        range = stats.attackRange;

        rangeTarget.transform.localPosition = new Vector3(0, 0, range);
    }
}
