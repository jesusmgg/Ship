using UnityEngine;
using xaf2.Input;
using xaf2.Physics;

namespace xaf2.Animation
{
    public class BipedAnimationController : BaseAnimationController
    {
        BaseInput input;
        BipedPhysicsObject physicsObject;

        protected override void Awake()
        {
            base.Awake();

            input = GetComponent<BaseInput>();
            physicsObject = GetComponent<BipedPhysicsObject>();
        }

        void Update()
        {
            bool flipSprite = spriteRenderer.flipX ? input.Direction.x > 0.01f : input.Direction.x < 0.01f;
            if (flipSprite)
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

            animator.SetBool("grounded", physicsObject.Grounded);
            animator.SetFloat("velocityX", Mathf.Abs(input.Direction.x) / physicsObject.maxSpeed);
        }
    }
}