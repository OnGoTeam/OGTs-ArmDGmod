namespace ArmDGmod.Characteristics
{
    public struct CharAppliable
    {
        public readonly CharacteristicsSet CharSet;

        public CharAppliable(CharacteristicsSet charSet)
        {
            CharSet = charSet;
        }

        internal void Apply(BaseWeapon baseWeapon)
        {
            if (baseWeapon is null) return;
            baseWeapon.ammoType.accuracy = CharSet.Accuracy;
            baseWeapon.ammoType.range = CharSet.Range;
            baseWeapon.ammoType.penetration = CharSet.Penetration;
            baseWeapon._fireWait = CharSet.FireWait;
            baseWeapon.KickForce = CharSet.KickForce;
            baseWeapon.weight = CharSet.Weight;
        }
    }
}