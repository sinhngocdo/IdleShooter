

namespace _Data.Object.Bullet
{
    public class BulletFly : ObjParentFly
    {
        protected override void ResetValue()
        {
            base.ResetValue();
            this.moveSpeed = 7f;
        }
    }
}
