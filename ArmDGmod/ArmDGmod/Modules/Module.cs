namespace ArmDGmod.Modules
{
    public abstract class Module
    {
        internal BaseWeapon AttachedWeapon;
        public abstract bool IsAbleToAdd(BaseWeapon baseWeapon);
        public abstract void AddToWeapon(BaseWeapon baseWeapon);
        public abstract bool IsAbleToRemove();
        public abstract void RemoveFromWeapon();
        public abstract void UpdateChars();
        public abstract void OnUpdate();
    }
}