using System;

namespace ArmDGmod.Characteristics
{
    public struct AccuDistance
    {
        public float Accuracy;
        public float Scatter
        {
            get => Math.Max(1 - Accuracy, 0);
            set => Accuracy = Math.Max(1 - Math.Abs(value), 0);
        }

        public float AccuRange
        {
            get => 1 / Math.Max(Scatter, BaseWeapon.Epsilon);
            set => Scatter = 1 / Math.Max(value, BaseWeapon.Epsilon);
        }
    }
}