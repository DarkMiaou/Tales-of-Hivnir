using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TalesofHivnir
{
    public class CameraController : MonoBehaviour
    {
        public Transform target;
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
            // Permet à la caméra de suivre le joueur
            transform.position = new Vector3(target.transform.position.x, target.transform.position.y,
                transform.position.z);
        }
    }
}
