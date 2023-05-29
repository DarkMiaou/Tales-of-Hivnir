using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using UnityEngine.UI;

namespace TalesofHivnir
{

    public class PlayerController : MonoBehaviour
    {
        public float basespeed = 5f;
        public float speed;
        private Rigidbody2D rb;
        private Animator anim;
        private PhotonView photonView;
        private float lastMoveX = 0f;
        private float lastMoveY = -1f;
        public AudioClip stepSound;
        private AudioSource audioSource;

        void Start()
        {
            speed = SaveData.instance.Newbonusspeed;
            
            photonView = GetComponent<PhotonView>();
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }

        void Update()
        {
            if (photonView.IsMine)
            {
                if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow))
                {
                    audioSource.loop = true;
                    audioSource.enabled = true;
                }
                else
                {
                    audioSource.loop = false;
                    audioSource.enabled = false;
                }
                float horizontalInput = Input.GetAxisRaw("Horizontal");
                float verticalInput = Input.GetAxisRaw("Vertical");

                Vector2 movement = Vector2.zero;

                if (Mathf.Abs(horizontalInput) > 0.5f)
                {
                    movement.x = horizontalInput;
                    anim.SetFloat("Horizontal", movement.x);
                    anim.SetFloat("Vertical", 0f);
                    lastMoveX = movement.x;
                    lastMoveY = 0f;
                }
                else if (Mathf.Abs(verticalInput) > 0.5f)
                {
                    movement.y = verticalInput;
                    anim.SetFloat("Horizontal", 0f);
                    anim.SetFloat("Vertical", movement.y);
                    lastMoveX = 0f;
                    lastMoveY = movement.y;
                }
                else
                {
                    anim.SetFloat("Horizontal", 0f);
                    anim.SetFloat("Vertical", 0f);
                }

                rb.velocity = movement.normalized * speed;
            }
            else
            {
                anim.SetFloat("Horizontal", lastMoveX);
                anim.SetFloat("Vertical", lastMoveY);
            }
        }
    }
}