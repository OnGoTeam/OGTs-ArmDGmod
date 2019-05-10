namespace ArmDGmod.Modules.Barrels
{
    public abstract class BarrelModule<T>:ClassicModule<T> where T: ISupportBarrel
    {
        protected BarrelModule(float priority) : base(priority, ModuleLocation.Barrel)
        {
        }
    }
}