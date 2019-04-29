using ArmDGmod.Characteristics;
using ArmDGmod.Modules.Sights.Interfaces;
using ArmDGmod.Modules.Sights.Pickups;
using DuckGame;

namespace ArmDGmod.Modules.Sights.Kinds
{
    public class CraneSight:SightModule<ISupportMediumSight>
    {
        private readonly Sprite _sprite;
        public CraneSight(float priority) : base(priority)
        {
            _sprite = new Sprite("tinyGun");
            _sprite.CenterOrigin();
            CharExpMod *= new CharacteristicsSet(10,defaultval:1f);
        }

        protected override void DrawAt(Vec2 pos, float angle, bool flipH)
        {
            _sprite.angle = angle;
            _sprite.flipH = flipH;
            Graphics.Draw(_sprite, pos.x, pos.y);
        }

        protected override void DetachFromWeapon()
        {
            var offset = ((ISupportClassicModule)AttachedWeapon).GetOffset(ModLoc);
            offset = AttachedWeapon.Anglify(offset);
            offset = AttachedWeapon.Offdirify(offset);
            var v = AttachedWeapon.position + offset;
            Level.Add(new CraneSightPickup(v.x, v.y, this)
            {
                hSpeed = AttachedWeapon.hSpeed,
                vSpeed = AttachedWeapon.vSpeed
            });
        }
    }
}