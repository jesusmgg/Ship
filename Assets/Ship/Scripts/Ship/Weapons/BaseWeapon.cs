using System.Collections;
using Ship.Input;
using UnityEngine;

namespace Ship.Weapons
{
    public class BaseWeapon : BaseComponent
    {
        public float reloadPeriod;

        public bool canShoot = false;
        
        protected BaseInput input;

        protected virtual void Awake()
        {
            input = transform.parent.GetComponent<BaseInput>();
        }
        
        void Start()
        {
            StartCoroutine(Reload());
        }

        protected virtual void Update()
        {
            if (canShoot)
            {
                if (input.GetButtonDown("Fire1"))
                {
                    Shoot();
                }
            }
        }

        protected virtual void Shoot()
        {
            canShoot = false;

            StartCoroutine(Reload());
        }

        IEnumerator Reload()
        {
            yield return new WaitForSeconds(reloadPeriod);
            canShoot = true;
            yield return null;
        }
    }
}