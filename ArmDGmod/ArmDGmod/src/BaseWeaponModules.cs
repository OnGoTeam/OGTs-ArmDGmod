using System.Collections.Generic;
using ArmDGmod.Characteristics;
using ArmDGmod.Modules;
using JetBrains.Annotations;

namespace ArmDGmod
{
    public partial class BaseWeapon
    {
        private List<WeaponModuleB> CurrModules { get; } = new List<WeaponModuleB>();

        [PublicAPI]
        public List<WeaponModuleB> CurrModulesP
        {
            get => new List<WeaponModuleB>(CurrModules);
            set
            {
                foreach (var module in CurrModules)
                {
                    if (!value.Contains(module)) RemoveModule(module);
                }
                foreach (var module in value)
                {
                    if (!CurrModules.Contains(module)) AddModule(module);
                }
            }
        }

        partial void UpdateModules()
        {
            if (sleeping) return;
            BarrelOffsetTl = DefBarrOffTl;
            ResetChars();
            var applied = Defaults.CharSet;
            foreach (var module in CurrModules)
            {
                module.Apply(ref applied);
            }
            CurrChar = new CharAppliable(applied);
        }

        public bool AddModule(WeaponModuleB module)
        {
            CurrModules.Sort(WeaponModuleB.CompareChars);
            CurrModules.Sort(WeaponModuleB.ComparePrior);
            if (CurrModules.Contains(module)) return false;
            var attached = module.Attach(this);
            if (!attached) return false;
            CurrModules.Add(module);
            return true;
        }

        public bool RemoveModule(WeaponModuleB module)
        {
            if (!CurrModules.Contains(module)) return false;
            var detached = module.Detach();
            if (!detached) return false;
            CurrModules.Remove(module);
            return true;
        }

        partial void DrawModules()
        {
            foreach (var module in CurrModules)
            {
                if (module is IDrawnModule drawn) drawn.Draw();
            }
        }
    }
}