using System.Collections;
using UnityEngine;

namespace Ship.Mechanics
{
    [RequireComponent(typeof(Collider2D))]
    public class HealthModifier : MonoBehaviour
    {
        public float healthDelta;
        public string targetTag;

        public bool destroyOnTrigger;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag(targetTag))
            {
                if (destroyOnTrigger)
                {
                    StartCoroutine(WaitAndDestroy());    
                }
            }
        }

        IEnumerator WaitAndDestroy()
        {
            yield return new WaitForEndOfFrame();
            Destroy(gameObject);
        }
    }
}