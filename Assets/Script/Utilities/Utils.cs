using UnityEngine;

public static class Utils
{
    // Modulo operator
    // The % operator might give a negative number, modulo shall always give a positive one
    public static int Mod(int m, int n)
    {
        return ((m % n) + n) % n;
    }
}
