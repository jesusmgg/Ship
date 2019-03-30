using Ship.Mechanics;
using UnityEngine;

namespace Ship.Stats
{
    public class PlayerStats : BaseStats
    {
        public float health;
        public bool dead;

        void Start()
        {
            if (health > 0)
            {
                dead = false;
            }
        }

        void Update()
        {
            if (health <= 0 && !dead)
            {
                Debug.Log("Player has died");
                dead = true;
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            HealthModifier hm = other.gameObject.GetComponent<HealthModifier>();
            if (hm != null)
            {
                if (CompareTag(hm.targetTag))
                {
                    if (!dead)
                    {
                        health += hm.healthDelta;    
                    }
                }
            }
        }
    }
}