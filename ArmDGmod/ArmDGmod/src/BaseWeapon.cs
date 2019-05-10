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

        public Vec2 DefBarrOffTl { get; protected set; }
        public Vec2 BarrelOffsetTl
        {
            get => _barrelOffsetTL;
            set => _barrelOffsetTL = value;
        }
        protected BaseWeapon(float xval, float yval, CharacteristicsSet characteristics) : base(xval, yval)
        {
            Defaults = new CharAppliable(characteristics);
        }

        public override void Initialize()
        {
            InitObstructors();
            DefBarrOffTl = BarrelOffsetTl;
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
            base.Draw();
            DrawModules();
        }

        public Vec2 Offdirify(Vec2 v)
        {
            v = new Vec2(v);
            v.x *= offDir;
            return v;
        }

        public void Draw(Sprite spr, Vec2 pos, float d = 1)
        {
            Vec2 vec2 = Offset(pos);
            spr.flipH = graphic.flipH;
            spr.angle = angle;
            spr.alpha = alpha;
            spr.depth = depth.value + d;
            spr.scale = scale;
            Graphics.Draw(spr, vec2.x, vec2.y);
        }
    }
}