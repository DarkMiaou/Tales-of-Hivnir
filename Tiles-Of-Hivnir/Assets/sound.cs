    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
     
    public class sound : MonoBehaviour
    {
        public Transform listenerTransform;
        public AudioSource audioSource;
        public float minDist=1;
        public float maxDist=200;
     
        void Update()
        {
            float dist = Vector2.Distance(transform.position, listenerTransform.position);
     
            if(dist < minDist)
            {
                audioSource.enabled = true;
            }
            else
            {
                if (maxDist<dist)
                {
                    audioSource.enabled = false;
                }
                
            }
        }
    }

