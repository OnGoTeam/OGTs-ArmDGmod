using System;
using DuckGame;
using JetBrains.Annotations;

namespace ArmDGmod.Obstruction
{
    [PublicAPI]
    public struct Obstructor<T>: IAutoUpdate
    {
        public bool Equals(Obstructor<T> other)
        {
            return Size.Equals(other.Size) && Position.Equals(other.Position) && Equals(Iro, other.Iro);
        }

        public override bool Equals(object obj)
        {
            if (obj is null) return false;
            return obj is Obstructor<T> other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Size.GetHashCode();
                hashCode = (hashCode * 397) ^ Position.GetHashCode();
                hashCode = (hashCode * 397) ^ (Iro != null ? Iro.GetHashCode() : 0);
                return hashCode;
            }
        }

        public readonly Vec2 Size;
        public readonly Vec2 Position;
        public readonly IReceiveObstruction Iro;
        private const float EpsilonO = 0.000001f;

        public Vec2 TopLeft
        {
            get => Position - Size / 2;
        }

        public Vec2 BottomRight
        {
            get => Position + Size / 2;
        }

        public Obstructor(Vec2 size, Vec2 position, IReceiveObstruction iro)
        {
            size = new Vec2(Math.Abs(size.x), Math.Abs(size.y));
            Size = size;
            Position = position;
            Iro = iro;
        }

        public static Obstructor<T> operator +(Obstructor<T> o1, Vec2 v1)
        {
            return new Obstructor<T>(o1.Size, o1.Position + v1, o1.Iro);
        }

        public static Obstructor<T> operator +(Vec2 v1, Obstructor<T> o1)
        {
            return o1 + v1;
        }

        public static bool operator ==(Obstructor<T> o1, Obstructor<T> o2)
        {
            return o1.Size == o2.Size &&
                   o1.Position == o2.Position &&
                   o1.Iro == o2.Iro;
        }

        public static bool operator !=(Obstructor<T> o1, Obstructor<T> o2)
        {
            return !(o1 == o2);
        }

        public static bool Overlapping(Obstructor<T> o1, Obstructor<T> o2)
        {
            return o1.TopLeft.x < o2.BottomRight.x &&
                   o2.TopLeft.x < o1.BottomRight.x &&
                   o1.TopLeft.y < o2.BottomRight.y &&
                   o2.TopLeft.y < o1.BottomRight.y;
        }

        public static bool Coinciding(Obstructor<T> o1, Obstructor<T> o2)
        {
            return o1.Size == o2.Size &&
                   Math.Abs(o1.Position.x - o2.Position.x) < EpsilonO &&
                   Math.Abs(o1.Position.y - o2.Position.y) < EpsilonO;
        }

        public bool Check()
        {
            return Level.CheckRect<T>(TopLeft, BottomRight) != null;
        }
        
        public void Update()
        {
            if (Iro != null && Iro.Receiving && Check())
            {
                Iro.Receive(this);
            }
        }
    }
}