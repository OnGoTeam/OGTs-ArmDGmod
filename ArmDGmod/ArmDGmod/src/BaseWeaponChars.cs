using ArmDGmod.Characteristics;
using DuckGame;

namespace ArmDGmod
{
    public partial class BaseWeapon
    {
        public StateBinding CurrCharBinding = new StateBinding(nameof(CurrChar));

        protected CharAppliable Defaults { get; }

        partial void ResetChars()
        {
            CurrChar = Defaults;
        }

        protected void ApplyChars(CharAppliable charAppliable)
        {
            charAppliable.Apply(this);
        }

        protected CharAppliable CurrChar
        {
            get => new CharAppliable(CharacteristicsSet.Extract(this));
            set => ApplyChars(value);
        }
    }
}