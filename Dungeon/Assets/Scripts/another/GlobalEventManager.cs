using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts
{
    internal class GlobalEventManager
    {
        public static Action PanelActive;
        public static Action EnemyKilled;
        public static Action EnemyCounter;

        public static void EnemyCount()
        {
            EnemyKilled?.Invoke();
            
        }

        public static void SetImprovePanel()
        {
            PanelActive?.Invoke();
        }
        public static void OnMapEnemyCount()
        {
            EnemyCounter?.Invoke();
            
        }
}
    }
