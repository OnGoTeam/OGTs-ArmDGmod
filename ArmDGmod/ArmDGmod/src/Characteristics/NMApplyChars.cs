using DuckGame;

namespace ArmDGmod.Characteristics
{
    // ReSharper disable once InconsistentNaming
    public class NMApplyChars:NMEvent
    {
        private BaseWeapon Weapon { get; }
        private CharAppliable CharSet { get; }
        public NMApplyChars()
        {

        }

        public NMApplyChars(BaseWeapon baseWeapon, CharAppliable charAppliable)
        {
            Weapon = baseWeapon;
            CharSet = charAppliable;
        }

        public override void Activate()
        {
            CharSet.Apply(Weapon);
        }
    }
}