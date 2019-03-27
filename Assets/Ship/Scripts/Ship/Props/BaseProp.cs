using UnityEngine;

namespace Ship.Props
{
    public class BaseProp : BaseComponent
    {
        protected Rigidbody2D rigidBody2D;

        void OnEnable()
        {
            rigidBody2D = GetComponent<Rigidbody2D>();
        }
    }
}