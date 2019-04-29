using System;
using ArmDGmod.Characteristics;
using DuckGame;

namespace ArmDGmod
{
    public partial class BaseWeapon
    {
        public StateBinding CurrCharBinding = new StateBinding(nameof(CurrChar));

        public float Scatter
        {
            get => Math.Max(1 - _ammoType.accuracy, 0);
            set => _ammoType.accuracy = Math.Max(1 - Math.Abs(value), 0);
        }

        public float AccuRange
        {
            get => 1 / Math.Max(Scatter, Epsilon);
            set => Scatter = 1 / Math.Max(value, Epsilon);
        }

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