using UnityEngine;
using Ship.Props;

namespace Ship.Physics
{
    public class BasePhysicsObject : BaseComponent
    {
        public float minGroundNormalY = 0.65f;
        public float gravityModifier = 1.0f;
        public float fallGravityMultiplier = 1.0f;
        public float maxFallSpeed = 50.0f;

        public bool usePhysics = true;
        
        protected Vector2 groundNormal;
        protected Vector2 velocity;
        protected Vector2 externalTranslation;
        protected ContactFilter2D contactFilter;
        protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

        protected const float MinMoveDistance = 0.001f;
        protected const float ShellRadius = 0.01f;
        
        protected Rigidbody2D rigidBody2D;

        public Lift currentLift;
        
        public Vector2 TargetVelocity { get; set; }
        public Vector2 Velocity => velocity;
        public bool Grounded { get; set; }

        void OnEnable()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
        }

        protected virtual void Start()
        {
            contactFilter.useTriggers = false;
            contactFilter.SetLayerMask(Physics2D.GetLayerCollisionMask(gameObject.layer));
            contactFilter.useLayerMask = true;

            currentLift = null;
            externalTranslation = Vector2.zero;
        }

        protected virtual void Update()
        {
            TargetVelocity = Vector2.zero;
            ComputeVelocity();
        }

        protected virtual void ComputeVelocity()
        {
            TargetVelocity = Vector2.zero;
        }

        protected virtual void FixedUpdate()
        {
            if (usePhysics)
            {
                float gravityMultiplier = 1.0f;
                gravityMultiplier *= gravityModifier;
                if (velocity.y < 0)
                {
                    gravityMultiplier *= fallGravityMultiplier;
                }
                velocity += gravityMultiplier * Physics2D.gravity * Time.deltaTime;
                velocity.x = TargetVelocity.x;

                if (velocity.y < -maxFallSpeed)
                {
                    velocity.y = -maxFallSpeed;
                }
                
                transform.Translate(externalTranslation);
                externalTranslation = Vector2.zero;
                
                if (currentLift != null)
                {
                    transform.Translate(currentLift.deltaPosition);
                }

                Grounded = false;

                Vector2 deltaPosition = velocity * Time.deltaTime;
                
                Vector2 moveAlongGround = new Vector2(groundNormal.y, -groundNormal.x);
                Vector2 move = moveAlongGround * deltaPosition.x;
                Movement(move, false);

                move = Vector2.up * deltaPosition.y;
                Movement(move, true);
            }
        }

        void Movement(Vector2 move, bool yMovement)
        {
            float distance = move.magnitude;

            if (distance > MinMoveDistance)
            {
                int count = rigidBody2D.Cast(move, contactFilter, hitBuffer, distance + ShellRadius);
                for (int i = 0; i < count; i++)
                {
                    Vector2 currentNormal = hitBuffer[i].normal;
                    if (currentNormal.y > minGroundNormalY)
                    {
                        Grounded = true;
                        if (yMovement)
                        {
                            groundNormal = currentNormal;
                            currentNormal.x = 0;
                        }
                    }

                    float projection = Vector2.Dot(velocity, currentNormal);
                    if (projection < 0)
                    {
                        velocity = velocity - projection * currentNormal;
                    }

                    float modifiedDistance = hitBuffer[i].distance - ShellRadius;
                    distance = modifiedDistance < distance ? modifiedDistance : distance;
                }
            }
            
            transform.Translate(move.normalized * distance);    
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Lift"))
            {
                currentLift = other.GetComponent<Lift>();
            }
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Lift"))
            {
                currentLift = null;
            }
        }
    }
}