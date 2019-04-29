using DuckGame;

namespace ArmDGmod.Modules
{
    public abstract class ClassicModule<T>:WeaponModule<T>, IDrawnModule where T: ISupportClassicModule
    {
        protected ModuleLocation ModLoc;
        protected ClassicModule(float priority, ModuleLocation modloc) : base(priority)
        {
            ModLoc = modloc;
        }

        public void Draw()
        {
            var offset = ((ISupportClassicModule) AttachedWeapon).GetOffset(ModLoc);
            var flipH = AttachedWeapon.offDir < 0;
            offset = AttachedWeapon.Anglify(offset);
            offset = AttachedWeapon.Offdirify(offset);
            var v = AttachedWeapon.position + offset;
            DrawAt(v, AttachedWeapon.angle, flipH);

        }
        protected abstract void DrawAt(Vec2 pos, float angle, bool flipH);
    }
}