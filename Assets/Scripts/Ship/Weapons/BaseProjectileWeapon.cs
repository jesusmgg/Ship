namespace Ship.Weapons
{
    public class BaseProjectileWeapon : BaseWeapon
    {
        public BaseProjectile projectilePrefab;

        protected override void Shoot()
        {
            base.Shoot();
            InstantiateProjectile();
        }

        protected virtual void InstantiateProjectile()
        {
        }
    }
}