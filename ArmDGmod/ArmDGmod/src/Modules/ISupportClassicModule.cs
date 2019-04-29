using DuckGame;

namespace ArmDGmod.Modules
{
    public interface ISupportClassicModule:ISupportModule
    {
        Vec2 GetOffset(ModuleLocation modloc);
    }
}