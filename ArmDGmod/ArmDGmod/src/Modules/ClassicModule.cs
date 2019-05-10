using DuckGame;

namespace ArmDGmod.Modules
{
    public abstract class ClassicModule<T>:WeaponModule<T>, IDrawnModule where T: ISupportClassicModule
    {
        protected readonly ModuleLocation ModLoc;
        protected ClassicModule(float priority, ModuleLocation modloc) : base(priority)
        {
            ModLoc = modloc;
        }

        public void Draw()
        {
            DrawAt(((ISupportClassicModule)AttachedWeapon).GetOffset(ModLoc));
        }
        protected abstract void DrawAt(Vec2 pos);
    }
}