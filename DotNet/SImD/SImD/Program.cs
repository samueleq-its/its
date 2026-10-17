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

            #region PARALLEL2_FIXED
            {
                float[] result = new float[ARRAY_SIZE];

                var sw = System.Diagnostics.Stopwatch.StartNew();

                if (Avx.IsSupported)
                {
                    int i = 0;
                    const int vecSize = 8; // 256 bits / 32 bits (float) = 8 floats

                    for (; i <= ARRAY_SIZE - vecSize; i += vecSize)
                    {
                        // Direct intrinsic vector load from array reference
                        var va = Vector256.LoadUnsafe(ref a[i]);
                        var vb = Vector256.LoadUnsafe(ref b[i]);

                        var vr = Avx.Add(va, vb);

                        // Direct intrinsic vector store to array reference
                        vr.StoreUnsafe(ref result[i]);
                    }

                    // Remainder loop
                    for (; i < ARRAY_SIZE; i++)
                    {
                        result[i] = a[i] + b[i];
                    }
                }

                sw.Stop();
                Console.WriteLine($"parallel2 (fixed): {sw.ElapsedTicks} ticks");
            }
            #endregion

        }
    }
}
