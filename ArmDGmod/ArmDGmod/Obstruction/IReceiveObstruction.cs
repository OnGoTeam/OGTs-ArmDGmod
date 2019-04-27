namespace ArmDGmod.Obstruction
{
    public interface IReceiveObstruction
    {
        void Receive<T>(Obstructor<T> obstructor);
    }
}