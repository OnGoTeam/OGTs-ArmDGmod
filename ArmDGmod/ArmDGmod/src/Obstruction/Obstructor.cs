using System;
using DuckGame;
using JetBrains.Annotations;

namespace ArmDGmod.Obstruction
{
    [PublicAPI]
    public struct Obstructor<T> where T: class
    {
        public readonly Vec2 Size;
        public Vec2 Position;
        public readonly WeakReference<IReceiveObstruction> Iro;
        private int _ticks;

        public Vec2 TopLeft => Position - Size / 2;

        public Vec2 BottomRight => Position + Size / 2;

        public Obstructor(Vec2 size, Vec2 position, IReceiveObstruction iro)
        {
            size = new Vec2(Math.Abs(size.x), Math.Abs(size.y));
            Size = size;
            Position = position;
            Iro = new WeakReference<IReceiveObstruction>(iro);
            _ticks = 0;
        }

        public static Obstructor<T> operator +(Obstructor<T> o1, Vec2 v1)
        {
            o1.Iro.TryGetTarget(out var iro);
            return new Obstructor<T>(o1.Size, o1.Position + v1, iro);
        }

        public static Obstructor<T> operator +(Vec2 v1, Obstructor<T> o1)
        {
            return o1 + v1;
        }

        public static bool Overlapping(Obstructor<T> o1, Obstructor<T> o2)
        {
            return o1.TopLeft.x < o2.BottomRight.x &&
                   o2.TopLeft.x < o1.BottomRight.x &&
                   o1.TopLeft.y < o2.BottomRight.y &&
                   o2.TopLeft.y < o1.BottomRight.y;
        }
        public bool Check()
        {
            return Level.CheckRect<T>(TopLeft, BottomRight) != null;
        }
        
        public void Update()
        {
            Iro.TryGetTarget(out var iro);
            if (iro != null && iro.Receiving && Check())
            {
                iro.Receive(this);
            }
        }
    }
}