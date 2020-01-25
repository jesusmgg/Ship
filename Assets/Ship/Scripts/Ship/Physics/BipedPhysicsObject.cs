using Ship.Input;
using Ship.Props;
using UnityEngine;

namespace Ship.Physics
{
    public class BipedPhysicsObject : BasePhysicsObject
    {
        [Header("Biped")]
        public float maxSpeed = 7;
        public float jumpTakeOffSpeed = 7;
        
        public bool useRandomSpeed = false;
        public float minRandomSpeed = 5.0f;
        public float maxRandomSpeed = 7.0f;

        public bool isJumping;
        public Lift jumpLift;
        
        bool jumpFrame;
        
        BaseInput input;
        new Collider2D collider;

        void Awake()
        {
            input = GetComponent<BaseInput>();
            collider = GetComponent<Collider2D>();
        }

        protected override void Start()
        {
            base.Start();

            if (useRandomSpeed)
            {
                maxSpeed = Random.Range(minRandomSpeed, maxRandomSpeed);
            }

            isJumping = false;
            jumpFrame = false;
        }

        protected override void FixedUpdate()
        {
            if (isJumping)
            {
                if (Grounded && !jumpFrame)
                {
                    isJumping = false;
                    jumpLift = null;
                }
                else if (jumpLift != null)
                {
                    int layerMask = 1 << gameObject.layer;
                    layerMask = ~layerMask;

                    RaycastHit2D hit = Physics2D.Raycast(transform.position, -Vector2.up, Mathf.Infinity, layerMask);
                    if (hit)
                    {
                        if (hit.collider.CompareTag("Lift"))
                        {
                            if (hit.collider.gameObject.GetComponent<Lift>() == jumpLift)
                            {
                                Vector2 translation = jumpLift.deltaPosition;
                                if (jumpLift.deltaPosition.y < 0)
                                {
                                    translation.y = 0;
                                }

                                externalTranslation += translation;
                            }
                            else
                            {
                                jumpLift = null;
                            }
                        }
                        else
                        {
                            jumpLift = null;
                        }
                    }
                    else
                    {
                        jumpLift = null;
                    }
                }
            }
            
            base.FixedUpdate();
        }

        protected override void ComputeVelocity()
        {
            jumpFrame = false;
            
            Vector2 move = Vector2.zero;

            move.x = input.Direction.x;
            
            if (input.GetButtonDown("Jump") && Grounded)
            {
                velocity.y = jumpTakeOffSpeed;
                isJumping = true;
                jumpFrame = true;

                jumpLift = currentLift;
            }
            else if (input.GetButtonUp("Jump"))
            {
                if (velocity.y > 0)
                {
                    velocity.y *= 0.5f;
                }
            }
            
            TargetVelocity = move * maxSpeed;
        }
    }
}