using ArmDGmod.Characteristics;
using ArmDGmod.Modules.Barrels.Interfaces;
using DuckGame;

namespace ArmDGmod.Modules.Barrels.Kinds
{
    public class RomanBarrel: BarrelModule<ISupport9MilMetre>
    {
        private readonly Sprite _sprite;
        public RomanBarrel(float priority) : base(priority)
        {
            _sprite = new SpriteMap("romanCandle", 16, 16);
            _sprite.CenterOrigin();
            _sprite.centerx = 0;
        }

        protected override void DrawAt(Vec2 pos)
        {
            AttachedWeapon.Draw(_sprite, pos);
        }

        protected override void UpdateChars(ref CharacteristicsSet applied)
        {
            AttachedWeapon.BarrelOffsetTl += AttachedWeapon.OffsetLocal(new Vec2(16, 0));
            base.UpdateChars(ref applied);
        }
    }
}