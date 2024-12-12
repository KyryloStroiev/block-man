using System;

namespace Code.Gameplay.Common.Random
{
    public interface IRandomService
    {
        float Range(float min, float max);
        int Range(int min, int max);
        T EnumValue<T>() where T : Enum;
    }
}