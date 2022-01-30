using UnityEngine;

namespace ElementalDamage.StatManagement
{
    public class DemoStatDisplay : StatDisplay
    {
        public void Increase()
        {
            int value = 1;
            if (Input.GetKey(KeyCode.LeftControl))
                value *= 5;
            if (Input.GetKey(KeyCode.LeftShift))
                value *= 20;

            if (Stat is PointStat pointStat)
                pointStat.MaxValue += value;
            else
                Stat.Value += value;
        }

        public void Decrease()
        {
            int value = 1;
            if (Input.GetKey(KeyCode.LeftControl))
                value *= 5;
            if (Input.GetKey(KeyCode.LeftShift))
                value *= 20;

            if (Stat is PointStat pointStat)
                pointStat.MaxValue -= value;
            else
                Stat.Value -= value;
        }
    }
}