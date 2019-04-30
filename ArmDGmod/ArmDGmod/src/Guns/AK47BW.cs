using ArmDGmod.Characteristics;
using ArmDGmod.Modules;
using ArmDGmod.Modules.Sights.Interfaces;
using ArmDGmod.Modules.Sights.Kinds;
using DuckGame;

namespace ArmDGmod.Guns
{
    [EditorGroup("guns|machine guns")]
    [BaggedProperty("isSuperWeapon", true)]
    public class Ak47Bw : BaseWeapon, ISupportMediumSight
    {
        public Ak47Bw(float xval, float yval)
            : base(xval, yval, new CharacteristicsSet(0.1f, 1000f, 200f, FwSec / 10, 0.2f, 3f))
        {
            ModuleUpdTicks = 1;
            ammo = 30;
            _ammoType = new AT9mm {range = 200f, accuracy = 0.85f, penetration = 2f};
            _type = "gun";
            _graphic = new Sprite("ak47");
            _center = new Vec2(16f, 15f);
            _collisionOffset = new Vec2(-8f, -3f);
            _collisionSize = new Vec2(18f, 10f);
            _barrelOffsetTL = new Vec2(32f, 14f);
            _fireSound = "deepMachineGun2";
            _fullAuto = true;
            _fireWait = 1.2f;
            _kickForce = 3.5f;
            ApplyChars(Defaults);
            AddModule(new CraneSight(1));
        }

        public override void OnQuackPress()
        {
            foreach (var module in CurrModulesP)
            {
                RemoveModule(module);
            }
        }

        public Vec2 GetOffset(ModuleLocation modloc)
        {
            return new Vec2(5,-5);
        }
    }
}
