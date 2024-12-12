using System;

namespace Code.Gameplay.Common.Random
{
    public class UnityRandomService : IRandomService
    {
        public float Range(float min, float max)=>
        UnityEngine.Random.Range(min, max);
        
        public int Range(int min, int max)=>
            UnityEngine.Random.Range(min, max);

        public T EnumValue<T>() where T : Enum
        {
            T[] values = Enum.GetValues(typeof(T)) as T[];
            return values[UnityEngine.Random.Range(0, values.Length)];
        }
    }
}