using Pixelplacement;
using Pixelplacement.TweenSystem;
using Ship.Utils.Types;
using UnityEngine;

namespace Ship.Props
{
    public class Lift : BaseProp
    {
        [DraggablePoint] public Vector3 position1;
        [DraggablePoint] public Vector3 position2;
        public AnimationCurve moveCurve;

        public float moveDuration;
        public float pauseDuration;

        public Vector2 velocity;
        public Vector2 deltaPosition;
        Vector2 lastPosition;

        Vector3 currentTarget;
        float timer;
        bool isPaused;

        void Start()
        {
            transform.position = position1;
            currentTarget = position2;
            timer = 0.0f;
            isPaused = true;

            lastPosition = transform.position;
            deltaPosition = Vector2.zero;
            velocity = Vector2.zero;
        }

        void FixedUpdate()
        {
            if (isPaused)
            {
                timer += Time.deltaTime;
                timer = Mathf.Clamp(timer, 0.0f, pauseDuration);
                
                if (timer >= pauseDuration)
                {
                    isPaused = false;
                    timer = 0.0f;
                }
            }
            else
            {
                timer += Time.deltaTime;
                timer = Mathf.Clamp(timer, 0.0f, moveDuration);
                float animationProgress = moveCurve.Evaluate(timer / moveDuration);
            
                if (currentTarget == position2)
                {
                    transform.position = Vector3.LerpUnclamped(position1, position2, animationProgress);
                }
                else if (currentTarget == position1)
                {
                    transform.position = Vector3.LerpUnclamped(position2, position1, animationProgress);
                }

                if (timer >= moveDuration)
                {
                    isPaused = true;
                    timer = 0.0f;

                    if (currentTarget == position2)
                    {
                        currentTarget = position1;
                    }
                    else if (currentTarget == position1)
                    {
                        currentTarget = position2;
                    }
                }
            }
            
            deltaPosition = (Vector2) transform.position - lastPosition;
            lastPosition = transform.position;

            velocity = deltaPosition * Time.deltaTime;
        }
    }
}