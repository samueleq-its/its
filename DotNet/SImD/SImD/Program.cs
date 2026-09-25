using System.Numerics;
using System.Runtime.Intrinsics;
using System.Runtime.Intrinsics.X86;

namespace SImD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int ARRAY_SIZE = 1_000_000;

            float[] a = new float[ARRAY_SIZE];
            float[] b = new float[ARRAY_SIZE];
            //float[] result = new float[ARRAY_SIZE];

            var rng = new Random();

            for (int i = 0; i < ARRAY_SIZE; i++)
            {
                a[i] = (float)rng.NextDouble();
                b[i] = (float)rng.NextDouble();
            }

            #region SEQUENTIAL
            {
                float[] result = new float[ARRAY_SIZE];

                var startTime = DateTime.Now.Ticks;
                for (int i = 0; i < ARRAY_SIZE; i++)
                {
                    result[i] = a[i] + b[i];
                }
                var endTime = DateTime.Now.Ticks;

                Console.WriteLine("sequential: " + (endTime - startTime) + " ticks");
            }
            #endregion

            #region PARALLEL1
            {
                float[] result = new float[ARRAY_SIZE];

                var startTime = DateTime.Now.Ticks;

                int vecSize = Vector<float>.Count;
                var i = 0;
                for (; i <= ARRAY_SIZE - vecSize; i += vecSize)
                {
                    var va = new Vector<float>(a, i);
                    var vb = new Vector<float>(b, i);
                    (va + vb).CopyTo(result, i);

                }

                for (; i < ARRAY_SIZE; i++)
                {
                    result[i] = a[i] + b[i];
                }

                var endTime = DateTime.Now.Ticks;
                Console.WriteLine("parallel1: " + (endTime - startTime) + " ticks");

            }
            #endregion

            #region PARALLEL2
            {
                float[] result = new float[ARRAY_SIZE];

                var startTime = DateTime.Now.Ticks;

                int vecSize = Vector<float>.Count;
                var i = 0;
                if (Avx2.IsSupported)
                {
                    for (; i <= ARRAY_SIZE - vecSize; i += vecSize)
                    {
                        var va = Vector256.Create(a.AsSpan(i, 8));
                        var vb = Vector256.Create(b.AsSpan(i, 8));
                        var vr = Avx.Add(va,vb);
                        vr.CopyTo(result.AsSpan(i,8));

                    }

                    for (; i < ARRAY_SIZE; i++)
                    {
                        result[i] = a[i] + b[i];
                    }

                    var endTime = DateTime.Now.Ticks;
                    Console.WriteLine("parallel2: " + (endTime - startTime) + " ticks");

                }

            }
            #endregion
        }
    }
}
