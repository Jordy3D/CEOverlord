using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace GoHome
{
    public class OnEmpty : MonoBehaviour
    {
        public UnityEvent onEmpty;

        // Use this for initialization
        void Start()
        {
            
        }

        // Update is called once per frame
        void Update()
        {
            if (transform.childCount == 0)
            {
                onEmpty.Invoke();
                gameObject.SetActive(false);
            }
        }

        public void Empty()
        {
            
        }
    } 
}
