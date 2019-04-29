using static System.Single;

namespace ArmDGmod.Characteristics
{
    public struct CharacteristicsSet
    {
        public readonly float Accuracy;
        public readonly float Range;
        public readonly float Penetration;
        public readonly float FireWait;
        public readonly float KickForce;
        public readonly float Weight;

        private static float UnNaNify(float f, float def)
        {
            if (IsNaN(f) || IsInfinity(f)) return def;
            return f;
        }

        public CharacteristicsSet(float accuracy=NaN, float range=NaN, float penetration=NaN, float fireWait=NaN, float kickForce=NaN, float weight=NaN, float defaultval=0f)
        {
            Accuracy = UnNaNify(accuracy, defaultval);
            Range = UnNaNify(range, defaultval);
            Penetration = UnNaNify(penetration, defaultval);
            FireWait = UnNaNify(fireWait, defaultval);
            KickForce = UnNaNify(kickForce, defaultval);
            Weight = UnNaNify(weight, defaultval);
        }

        public static CharacteristicsSet operator +(CharacteristicsSet cs1, CharacteristicsSet cs2)
        {
            return new CharacteristicsSet(cs1.Accuracy + cs2.Accuracy,
                                      cs1.Range + cs2.Range,
                                      cs1.Penetration + cs2.Penetration,
                                      cs1.FireWait + cs2.FireWait,
                                      cs1.KickForce + cs2.KickForce,
                                      cs1.Weight + cs2.Weight);
        }

        public static CharacteristicsSet operator *(CharacteristicsSet cs1, CharacteristicsSet cs2)
        {
            return new CharacteristicsSet(cs1.Accuracy * cs2.Accuracy,
                cs1.Range * cs2.Range,
                cs1.Penetration * cs2.Penetration,
                cs1.FireWait * cs2.FireWait,
                cs1.KickForce * cs2.KickForce,
                cs1.Weight * cs2.Weight);
        }

        public static int Compare(CharacteristicsSet cs1, CharacteristicsSet cs2)
        {
            if (cs1.Accuracy < cs2.Accuracy) return -1;
            if (cs1.Accuracy > cs2.Accuracy) return 1;
            if (cs1.Range < cs2.Range) return -1;
            if (cs1.Range > cs2.Range) return 1;
            if (cs1.Penetration < cs2.Penetration) return -1;
            if (cs1.Penetration > cs2.Penetration) return 1;
            if (cs1.FireWait < cs2.FireWait) return -1;
            if (cs1.FireWait > cs2.FireWait) return 1;
            if (cs1.KickForce < cs2.KickForce) return -1;
            if (cs1.KickForce > cs2.KickForce) return 1;
            if (cs1.Weight < cs2.Weight) return -1;
            if (cs1.Weight > cs2.Weight) return 1;
            return 0;
        }

        public static CharacteristicsSet Extract(BaseWeapon baseWeapon)
        {
            return new CharacteristicsSet(baseWeapon.ammoType.accuracy,
                baseWeapon.ammoType.range,
                baseWeapon.ammoType.penetration,
                baseWeapon._fireWait,
                baseWeapon.KickForce,
                baseWeapon.weight);
        }
    }
}