using UnityEngine;

namespace _Data.Level
{
    public class LevelByItem : LevelAbstract
    {
        protected override int GetCurrentExp()
        {
            return 0;
        }

        protected override bool DeductExp(int exp)
        {
            return false;
        }
    }
}