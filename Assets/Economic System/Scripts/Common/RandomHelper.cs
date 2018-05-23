using UnityEngine;

public class RandomHelper
{
    public static int RandomSeed { get; private set; }

    public static void ResetRandomSeed(int seed)
    {
        RandomSeed = seed;
        Random.InitState(seed);
    }
}

