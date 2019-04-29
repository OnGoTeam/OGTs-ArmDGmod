using ArmDGmod.Characteristics;
using ArmDGmod.Modules.Sights.Interfaces;
using DuckGame;

namespace ArmDGmod.Modules.Sights.Kinds
{
    public class CraneSight:SightModule<ISupportMediumSight>
    {
        private readonly Sprite _sprite;
        public CraneSight(float priority) : base(priority)
        {
            _sprite = new Sprite("tinyGun");
            CharExpMod *= new CharacteristicsSet(10,defaultval:1f);
        }

        protected override void DrawAt(Vec2 pos, float angle, bool flipH)
        {
            _sprite.angle = angle;
            _sprite.flipH = flipH;
            Graphics.Draw(_sprite, pos.x, pos.y);
        }
    }
}