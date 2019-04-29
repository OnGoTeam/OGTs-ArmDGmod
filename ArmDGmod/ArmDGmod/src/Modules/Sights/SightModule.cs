namespace ArmDGmod.Modules.Sights
{
    public abstract class SightModule<T>:ClassicModule<T> where T: ISupportSight
    {
        protected SightModule(float priority) : base(priority, ModuleLocation.Sight)
        {
        }
    }
}