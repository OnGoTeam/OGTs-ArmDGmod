using ArmDGmod.Characteristics;

namespace ArmDGmod.Modules
{
    public abstract class WeaponModule<T> : WeaponModuleB where T : ISupportModule
    {
        protected WeaponModule(float priority) : base(priority)
        {
        }

        public override bool AtoAttach(BaseWeapon baseWeapon)
        {
            return baseWeapon is T;
        }
    }

    public abstract class WeaponModuleB
    {
        private BaseWeapon _attachedWeapon;

        internal BaseWeapon AttachedWeapon => _attachedWeapon;
        private readonly float _priority;
        protected CharacteristicsSet CharLinMod;
        protected CharacteristicsSet CharExpMod = new CharacteristicsSet(defaultval:1f);

        protected WeaponModuleB(float priority)
        {
            _priority = priority;
        }

        public static int ComparePrior<T1, T2>(WeaponModule<T1> wm1, WeaponModule<T2> wm2)
            where T1: ISupportModule where T2: ISupportModule
        {
            return wm1._priority < wm2._priority ? -1 : wm1._priority > wm2._priority ? 1 : 0;
        }

        public static int CompareChars<T1, T2>(WeaponModule<T1> wm1, WeaponModule<T2> wm2)
            where T1 : ISupportModule where T2 : ISupportModule
        {
            var c1 = CharacteristicsSet.Compare(wm1.CharExpMod, wm2.CharExpMod);
            return c1 != 0 ? c1 : CharacteristicsSet.Compare(wm1.CharLinMod, wm2.CharLinMod);
        }

        /// <summary>
        /// Is Able to Add (Attach) to
        /// </summary>
        /// <param name="baseWeapon"></param>
        /// <returns></returns>
        public virtual bool AtoAttach(BaseWeapon baseWeapon)
        {
            return true;
        }

        protected virtual void AttachToWeapon() { }

        internal bool Attach(BaseWeapon baseWeapon)
        {
            var ata = AtoAttach(baseWeapon);
            if (!ata) return false;
            _attachedWeapon = baseWeapon;
            AttachToWeapon();
            return true;
        }

        internal bool Detach()
        {
            if (_attachedWeapon is null) return true;
            var ata = AtoDetach();
            if (!ata) return false;
            DetachFromWeapon();
            _attachedWeapon = null;
            return true;
        }
        protected virtual void DetachFromWeapon() { }

        protected virtual bool AtoDetach()
        {
            return true;
        }

        protected virtual void UpdateChars(ref CharacteristicsSet applied) { }
        public virtual void OnUpdate() { }

        public void Apply(ref CharacteristicsSet applied)
        {
            applied += CharLinMod;
            applied *= CharExpMod;
            UpdateChars(ref applied);
        }
    }
}