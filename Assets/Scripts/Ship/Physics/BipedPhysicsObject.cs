using Ship.Input;
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
        
        BaseInput input;

        void Awake()
        {
            input = GetComponent<BaseInput>();
        }

        protected override void Start()
        {
            base.Start();

            if (useRandomSpeed)
            {
                maxSpeed = Random.Range(minRandomSpeed, maxRandomSpeed);
            }
        }

        protected override void ComputeVelocity()
        {
            Vector2 move = Vector2.zero;

            move.x = input.Direction.x;

            if (input.GetButtonDown("Jump") && Grounded)
            {
                velocity.y = jumpTakeOffSpeed;
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