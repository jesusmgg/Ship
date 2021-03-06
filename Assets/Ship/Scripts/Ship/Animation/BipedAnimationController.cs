﻿using Ship.Input;
using Ship.Physics;
using UnityEngine;

namespace Ship.Animation
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
            bool flipSprite = transform.localScale.x < 0 ? input.Direction.x > 0.01f : input.Direction.x < -0.01f;
            if (flipSprite)
            {
                var localScale = transform.localScale;
                localScale.x = -localScale.x;
                transform.localScale = localScale;
            }
            
            animator.SetBool("grounded", physicsObject.Grounded);
            animator.SetFloat("velocityX", Mathf.Abs(physicsObject.Velocity.x));
            animator.SetFloat("velocityY", physicsObject.Velocity.y);
            animator.SetBool("jump", input.GetButtonDown("Jump"));
        }
    }
}