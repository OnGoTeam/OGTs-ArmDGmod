using ArmDGmod.Modules.Pickups;
using ArmDGmod.Modules.Sights.Interfaces;
using DuckGame;

namespace ArmDGmod.Modules.Sights.Pickups
{
    public sealed class CraneSightPickup:PickupModule<ISupportMediumSight>
    {
        public CraneSightPickup(float xval, float yval, WeaponModule<ISupportMediumSight> module) : base(xval, yval, "harp", module)
        {
            graphic = new Sprite("tinyGun");
            center = new Vec2(16f, 16f);
            collisionOffset = new Vec2(-6f, -4f);
            collisionSize = new Vec2(12f, 8f);
        }
    }
}