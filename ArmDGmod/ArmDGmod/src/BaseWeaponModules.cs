using System.Collections.Generic;
using ArmDGmod.Modules;

namespace ArmDGmod
{
    public partial class BaseWeapon
    {
        public List<Module> CurrModules { get; private set; }

        partial void UpdateModules()
        {
            ResetChars();
            foreach (var module in CurrModules)
            {
                module.AttachedWeapon = this;
                module.UpdateChars();
                module.OnUpdate();
            }
        }

        public bool AddModule(Module module)
        {
            if (module.AttachedWeapon != null) return false;
            if (CurrModules.Contains(module)) return false;
            if (!module.IsAbleToAdd(this)) return false;
            CurrModules.Add(module);
            module.AttachedWeapon = this;
            module.AddToWeapon(this);
            return true;
        }

        public bool RemoveModule(Module module)
        {
            if (!CurrModules.Contains(module)) return false;
            if (module.AttachedWeapon is null)
            {
                CurrModules.Remove(module);
                return false;
            }
            if (!module.IsAbleToRemove()) return false;
            module.RemoveFromWeapon();
            module.AttachedWeapon = null;
            CurrModules.Remove(module);
            return true;
        }
    }
}