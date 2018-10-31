using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KonamiCode : MonoBehaviour
{
    public KeyCode[] sequence;
    private int sequenceIndex;
    public float time = 0f, coolDownTime = 0f, coolDownLimit;
    private bool isCombo, isCoolDown;
    public GameObject hitTest;
    private IEnumerator myCoR;

    private void Start()
    {
        hitTest = GameObject.FindGameObjectWithTag("Player").transform.GetChild(0).gameObject;
        hitTest.SetActive(false);
    }
    private void Update()
    {
        if (isCombo)
        {
            time += Time.deltaTime;
        }

        if (!isCoolDown)
        {
            if (Input.GetKeyDown(sequence[sequenceIndex]))
            {
                if (sequenceIndex == 0)
                {
                    Debug.Log("First hit");
                    hitTest.SetActive(true);
                    time = 0f;
                    isCombo = true;
                    myCoR = hideHitBox(0.2f);
                    StartCoroutine(myCoR);
                    
                }
                else if (sequenceIndex == 1)
                {
                    Debug.Log("Second Hit");
                    time = 0f;
                    StopCoroutine(myCoR);
                    hitTest.SetActive(true);
                    StartCoroutine(hideHitBox(0.2f));
                }
                else if (sequenceIndex == 2)
                {
                    Debug.Log("Third Hit");
                    time = 0f;
                    StopCoroutine(myCoR);
                    hitTest.SetActive(true);
                    StartCoroutine(hideHitBox(0.2f));
                }

                if (++sequenceIndex == sequence.Length)
                {
                    sequenceIndex = 0;
                    Debug.Log("Combo Complete");
                    isCombo = false;
                    time = 0f;
                    sequenceIndex = 0;
                    isCoolDown = true;
                    Debug.Log("On cooldown");
                    // sequence typed
                }
            }
            else if (isCombo && (Input.anyKeyDown || time > 0.6f))
            {
                sequenceIndex = 0;
                isCombo = false;
                time = 0f;
                Debug.Log("Combo Dropped");
            }
        } else
        {
            coolDownTime += Time.deltaTime;
            if(coolDownTime >= coolDownLimit)
            {
                isCoolDown = false;
                coolDownTime = 0f;
                Debug.Log("Off Cooldown");
            }
        }
    }

    IEnumerator hideHitBox(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);

        hitTest.SetActive(false);
    }
}
