using ArmDGmod.Pickups;
using DuckGame;

namespace ArmDGmod.Modules.Pickups
{
    public abstract class PickupModule<T>:Pickup where T: ISupportModule
    {
        private readonly WeaponModule<T> _pickedup;
        protected PickupModule(float xval, float yval, string pickSound, WeaponModule<T> module) : base(xval, yval, pickSound, 60)
        {
            _pickedup = module;
        }

        protected override bool TryPick(Duck duck1)
        {
            return duck1.holdObject is BaseWeapon baseWeapon && baseWeapon.AddModule(_pickedup);
        }
    }
}