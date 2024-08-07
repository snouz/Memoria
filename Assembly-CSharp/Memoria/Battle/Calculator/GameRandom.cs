using System;
using Random = UnityEngine.Random;

namespace Memoria
{
    public static class GameRandom
    {
        public static Int32 Next8()
        {
            return Random.Range(0, 256); // UnityEngine.Random.Range(min [inclusive], max [exclusive])
        }

        public static Int32 Next16()
        {
            return Random.Range(0, 65536);
        }

        public static Int32 RandomInt(Int32 minInclusive, Int32 maxExclusive)
        {
            return Random.Range(minInclusive, maxExclusive);
        }

        public static Single RandomSingle(Single min, Single max)
        {
            return Random.Range(min, max);
        }
    }
}
