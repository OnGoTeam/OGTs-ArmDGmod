using System;
using ArmDGmod.Characteristics;
using ArmDGmod.Obstruction;
using DuckGame;

namespace ArmDGmod
{
    public abstract partial class BaseWeapon:Gun, IReceiveObstruction
    {
        public const int TpS = 60;
        public const int Tick = 1;
        public const int Sec = TpS * Tick;
        public const float Hz = 1f / Sec;
        public const float FwTick = 0.15f;
        public const float FwSec = TpS * FwTick;
        public const float Epsilon = 1e-4f;
        protected uint ModuleUpdTicks;
        private uint _ticks;
        internal float KickForce
        {
            get => _kickForce;
            set => _kickForce = value;
        }
        protected BaseWeapon(float xval, float yval, CharacteristicsSet characteristics) : base(xval, yval)
        {
            Defaults = new CharAppliable(characteristics);
        }

        public override void Initialize()
        {
            InitObstructors();
            base.Initialize();
        }

        partial void UpdateModules();
        partial void ResetChars();

        public override void Update()
        {
            if (duck != null)
            {
                if (duck.inputProfile.Pressed("QUACK")) OnQuackPress();
                if (duck.inputProfile.Down("QUACK")) OnQuackHold();
            }
            _ticks += 1;
            if (_ticks % ModuleUpdTicks == 0)
            {
                UpdateModules();
            }

            base.Update();

            foreach (var obstructor in Obstructors)
            {
                obstructor.Update();
            }

            foreach (var obstructor in PlatformObstructors)
            {
                obstructor.Update();
            }
        }

        public virtual void OnQuackPress()
        {
        }

        public virtual void OnQuackHold()
        {
        }

        partial void DrawModules();

        public override void Draw()
        {
            DrawModules();
            base.Draw();
        }

        public Vec2 Offdirify(Vec2 v)
        {
            v = new Vec2(v);
            v.x *= offDir;
            return v;
        }

        public Vec2 Anglify(Vec2 v)
        {
            var av = new Vec2((float)Math.Cos(angle), (float)Math.Sin(angle));
            var ov = new Vec2 {
                x = v.x * av.x - v.y * av.y,
                y = v.x * av.y + v.y * av.x
            };
            return ov;
        }
    }
}