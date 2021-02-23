using System;
using Random = UnityEngine.Random;

public static class IDGenerator
{
    public static string Get(int length)
    {
        string result = string.Empty;
        for (int i = 0; i < length; i++)
        {
            var number = Random.Range(48, 57);
            var upperChar = Random.Range(65, 90);
            var lowerChar = Random.Range(97, 122);

            var rd = Random.value;
            if (rd < 0.333f)
            {
                result += (char)number;
                continue;
            }

            if (rd < 0.667f)
            {
                result += (char)upperChar;
                continue;
            }

            result += (char)lowerChar;
        }
        return result;
    }
}