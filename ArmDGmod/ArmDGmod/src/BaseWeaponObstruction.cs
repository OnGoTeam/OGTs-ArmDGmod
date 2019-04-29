using System.Collections.Generic;
using ArmDGmod.Obstruction;
using DuckGame;
using JetBrains.Annotations;

namespace ArmDGmod
{
    public partial class BaseWeapon
    {
        public List<Obstructor<MaterialThing>> Obstructors = new List<Obstructor<MaterialThing>>();
        public List<Obstructor<IPlatform>> PlatformObstructors = new List<Obstructor<IPlatform>>();

        protected void InitObstructors()
        {
            AddObstructor(new Vec2(2, 2), new Vec2(0, 0));
        }
        private void AddObstructor(Vec2 size, Vec2 offset)
        {
            var o1 = new Obstructor<MaterialThing>(size, position + Offdirify(offset), this);
            Obstructors.Add(o1);
            //AutoUpdatables.Add(o1);
        }
        [UsedImplicitly]
        private void AddPlatformObstructor(Vec2 size, Vec2 offset)
        {
            var o1 = new Obstructor<IPlatform>(size, position + Offdirify(offset), this);
            PlatformObstructors.Add(o1);
            //AutoUpdatables.Add(o1);
        }

        public bool Receiving => !_destroyed && duck != null && !_raised;

        public void Receive<T>(Obstructor<T> obstructor) where T: class
        {
        }
    }
}