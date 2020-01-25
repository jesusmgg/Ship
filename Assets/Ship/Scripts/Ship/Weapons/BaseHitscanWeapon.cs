using UnityEngine;

namespace Ship.Weapons
{
    public class BaseHitscanWeapon : BaseWeapon
    {
        [Header("Hitscan weapon")]
        public bool debug;
        
        protected override void Shoot()
        {
            base.Shoot();
            
            RaycastHit2D hit = Physics2D.Raycast(shootPoint.position, transform.right);

            Debug.Log("shooting");
            if (debug)
            {
                Debug.DrawRay(shootPoint.position, transform.parent.right * Mathf.Sign(transform.parent.localScale.x));
            }
        }
    }
}