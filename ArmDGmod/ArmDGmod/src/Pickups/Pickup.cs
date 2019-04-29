using DuckGame;

namespace ArmDGmod.Pickups
{
    public abstract class Pickup:Holdable
    {
        private readonly string _pickSound;
        private uint _cooldown;
        protected Pickup(float xval, float yval, string pickSound, uint cooldown) : base(xval, yval)
        {
            _pickSound = pickSound;
            canPickUp = false;
            _cooldown = cooldown;
        }

        protected abstract bool TryPick(Duck duck);

        public override void Touch(MaterialThing with)
        {
            base.Touch(with);
            if (_cooldown > 0) return;
            if (!(with is Duck duck1)) return;
            if (!TryPick(duck1)) return;
            SFX.Play(_pickSound);
            Level.Remove(this);
        }

        public override void Update()
        {
            if (_cooldown > 0) _cooldown -= 1;
            base.Update();
        }
    }
}