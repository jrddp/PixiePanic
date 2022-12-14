using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;
using Platformer.Model;
using Platformer.Core;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This is the main class used to implement control of the player.
    /// It is a superset of the AnimationController class, but is inlined to allow for any kind of customisation.
    /// </summary>
    public class PlayerController : KinematicObject
    {
        // Controls movement controls
        public int controlScheme = 1;

        public GameObject abilitySpawn;

        public AudioClip jumpAudio;
        public AudioClip respawnAudio;
        public AudioClip ouchAudio;

        public float abilityDelay = 3f;
        private float lastAbility = 0;

        /// <summary>
        /// Max horizontal speed of the player.
        /// </summary>
        public float maxSpeed = 7;
        /// <summary>
        /// Initial jump velocity at the start of a jump.
        /// </summary>
        public float jumpTakeOffSpeed = 7;

        public JumpState jumpState = JumpState.Grounded;
        private bool stopJump;
        /*internal new*/ public Collider2D collider2d;
        /*internal new*/ public AudioSource audioSource;
        public Health health;
        public bool controlEnabled = true;

        bool jump;
        Vector2 move;
        SpriteRenderer spriteRenderer;
        internal Animator animator;
        readonly PlatformerModel model = Simulation.GetModel<PlatformerModel>();

        public Bounds Bounds => collider2d.bounds;

        void Awake()
        {
            health = GetComponent<Health>();
            audioSource = GetComponent<AudioSource>();
            collider2d = GetComponent<Collider2D>();
            spriteRenderer = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }

        protected override void Update()
        {
            if (controlEnabled)
            {
                string xaxisStr = "P" + controlScheme + "Horizontal";
                string jumpStr = "P" + controlScheme + "Jump";
                string abilityStr = "P" + controlScheme + "Ability";

                move.x = Input.GetAxis(xaxisStr);
                if (jumpState == JumpState.Grounded && Input.GetButtonDown(jumpStr))
                    jumpState = JumpState.PrepareToJump;
                else if (Input.GetButtonUp(jumpStr))
                {
                    stopJump = true;
                    Schedule<PlayerStopJump>().player = this;
                }
                if (Input.GetButtonDown(abilityStr) && IsGrounded && Time.time - lastAbility >= abilityDelay) {
                    lastAbility = Time.time;
                    int dir = 1;
                    if (spriteRenderer.flipX) dir = -1;
                    Vector3 newPos = transform.position + new Vector3(dir * .5f, 0, 0);
                    Instantiate(abilitySpawn, newPos, transform.rotation);
                }
            }
            else
            {
                move.x = 0;
            }
            UpdateJumpState();
            base.Update();
        }


        // void OnCollisionEnter2D(Collision2D collision)
        // {
        //     if (collision.gameObject.name == "Player1" || collision.gameObject.name == "Player2")
        //     {
        //         Debug.Log(this.gameObject.name + " collided by: " + collision.gameObject.name);
        //         targetVelocity.x = -1 * maxSpeed;
        //         ComputeVelocity();
        //     }

        // }

        void UpdateJumpState()
        {
            jump = false;
            switch (jumpState)
            {
                case JumpState.PrepareToJump:
                    jumpState = JumpState.Jumping;
                    jump = true;
                    stopJump = false;
                    break;
                case JumpState.Jumping:
                    if (!IsGrounded)
                    {
                        Schedule<PlayerJumped>().player = this;
                        jumpState = JumpState.InFlight;
                    }
                    break;
                case JumpState.InFlight:
                    if (IsGrounded)
                    {
                        Schedule<PlayerLanded>().player = this;
                        jumpState = JumpState.Landed;
                    }
                    break;
                case JumpState.Landed:
                    jumpState = JumpState.Grounded;
                    break;
            }
        }

        protected override void ComputeVelocity()
        {
            if (jump && IsGrounded)
            {
                velocity.y = jumpTakeOffSpeed * model.jumpModifier;
                jump = false;
            }
            else if (stopJump)
            {
                stopJump = false;
                if (velocity.y > 0)
                {
                    velocity.y = velocity.y * model.jumpDeceleration;
                }
            }

            if (move.x > 0.01f)
                spriteRenderer.flipX = false;
            else if (move.x < -0.01f)
                spriteRenderer.flipX = true;

            animator.SetBool("grounded", IsGrounded);
            animator.SetFloat("velocityX", Mathf.Abs(velocity.x) / maxSpeed);

            targetVelocity = move * maxSpeed;
        }

        public enum JumpState
        {
            Grounded,
            PrepareToJump,
            Jumping,
            InFlight,
            Landed
        }
    }
}