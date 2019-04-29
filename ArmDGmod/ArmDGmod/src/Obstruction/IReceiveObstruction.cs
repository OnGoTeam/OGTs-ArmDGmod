namespace ArmDGmod.Obstruction
{
    public interface IReceiveObstruction
    {
        bool Receiving { get; }
        void Receive<T>(Obstructor<T> obstructor) where T: class;
    }
}