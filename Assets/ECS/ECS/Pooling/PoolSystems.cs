using System.Collections.Generic;

namespace ME.ECS {

    public static class PoolSystems {

        private static PoolInternalBase pool = new PoolInternalBase(null, null);
	    
        public static T Spawn<T>() where T : class, ISystemBase, new() {
            
            var obj = PoolSystems.pool.Spawn();
            if (obj == null) return new T();
            return (T)obj;

        }

        public static void Recycle<T>(ref T system) where T : class, ISystemBase {

            PoolSystems.pool.Recycle(system);
            system = null;

        }

        public static void Recycle<T>(T system) where T : class, ISystemBase {

            PoolSystems.pool.Recycle(system);

        }

    }

}