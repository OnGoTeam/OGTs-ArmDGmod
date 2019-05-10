using ArmDGmod.Characteristics;
using ArmDGmod.Modules.Sights.Interfaces;
using ArmDGmod.Modules.Sights.Pickups;
using DuckGame;

namespace ArmDGmod.Modules.Sights.Kinds
{
    public class CraneSight:SightModule<ISupportMediumSight>, IDropModule
    {
        private readonly Sprite _sprite;
        public CraneSight(float priority) : base(priority)
        {
            _sprite = new Sprite("tinyGun");
            _sprite.CenterOrigin();
        }

        protected override void DrawAt(Vec2 pos)
        {
            AttachedWeapon.Draw(_sprite, pos);
        }

        protected override void UpdateChars(ref CharacteristicsSet applied)
        {
            AccuDistance accu;
            accu.Accuracy = applied.Accuracy;
            accu.AccuRange *= 3;
            applied += new CharacteristicsSet(accu.Accuracy - applied.Accuracy);
        }

        protected override void DetachFromWeapon()
        {
            var offset = ((ISupportClassicModule)AttachedWeapon).GetOffset(ModLoc);
            var v = AttachedWeapon.Offset(offset);
            Level.Add(new CraneSightPickup(v.x, v.y, this)
            {
                hSpeed = AttachedWeapon.hSpeed,
                vSpeed = AttachedWeapon.vSpeed
            });
        }
    }
}