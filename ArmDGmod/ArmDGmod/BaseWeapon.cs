using DuckGame;
using JetBrains.Annotations;

namespace ArmDGmod
{
    [PublicAPI]
    public abstract partial class BaseWeapon:Gun
    {
        protected BaseWeapon(float xval, float yval) : base(xval, yval)
        {
        }

        partial void AddObstructor();
        partial void UpdateModules();
        partial void ResetChars();
    }
}