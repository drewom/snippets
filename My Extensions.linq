void Main()
{
	// Write code to test your extensions here. Press F5 to compile and run.
}

public static class MyExtensions
{
	// Write custom extension methods here. They will be available to all queries.	
	public static void Shuffle<T>(this IList<T> list)  
	{  
		var rng = new Random();  
	    int n = list.Count;  
	    while (n > 1) {  
	        n--;  
	        int k = rng.Next(n + 1);  
	        T value = list[k];  
	        list[k] = list[n];  
	        list[n] = value;  
	    }  
	}
	
	// Create Pairs from a list. If the list is odd add a default value for the final pair. 
	public static IEnumerable<Tuple<T, T>> AsPairs<T>(this List<T> list)
	{
		int index = 0;
		
		while (index < list.Count())
		{
			if (index + 1 > list.Count())
				yield break;
			
			if (index + 1 == list.Count())    
				yield return new Tuple<T,T>(list[index++],  default(T));
			else
				yield return new Tuple<T,T>(list[index++],  list[index++]);
		}
	}
}
/// <summary>
/// Compile time check, used to check if a type is considered blittable
/// </summary>
public static class BlittableCheck<T>
{
    // ReSharper disable once StaticMemberInGenericType
    /// <summary>
    /// Generic compile time constant.
    /// </summary>
    public static readonly bool Blittable;
    
    static BlittableCheck()
    {
        Blittable = false;
        // classes are by definition non-blittable
        if (default(T) == null)
        {
            return;
        }
        // can we pin an instance of it?
        try
        {
            // throws ArgumentException for an instance with non-primitive (non-blittable) members
            System.Runtime.InteropServices.GCHandle
                .Alloc(default(T), System.Runtime.InteropServices.GCHandleType.Pinned)
                .Free();

            // this type is blittable
            Blittable = true;
        }
        catch (ArgumentException){ /* Blittable = false; */}
    }
}


public static class Maths
{
    /// <summary>
    /// standard deviation of range (√(Σ(x-x̅)²) / (n-1)))
    /// </summary>
    /// <returns></returns>
    public static decimal StandardDeviation(this IEnumerable<decimal> range, 
        StandardDeviationOptions options = StandardDeviationOptions.Defaults)
    {
        var enumerable = range as decimal[] ?? range?.ToArray();

        if (enumerable == null || enumerable.Length <= 1) // need 2 or more samples to not get zero
        {
            if ((options & StandardDeviationOptions.ThrowOnScalar) == StandardDeviationOptions.ThrowOnScalar)
            {
                throw new OverflowException("StandardDeviation, ThrowOnScalar");
            }
            return 0;
        }
        // Bessel's Correction? https://en.wikipedia.org/wiki/Bessel%27s_correction
        var biasCorrection = ((options & StandardDeviationOptions.Biased) == StandardDeviationOptions.Biased) ? 0 : 1;
        // Compute mean_x      
        var mean = enumerable.Average();
        // sum((xn-mean_x)^2)      
        var sum = enumerable.Sum(x => (x - mean) * (x - mean));
        // sqrt(sum((xn-mean_x)^2)/(n[ - 1?]))
        var result = Sqrt(sum / (enumerable.Length-biasCorrection)); 

        return result;
    }
    [Flags]
    public enum StandardDeviationOptions : int
    {
        /// <summary>
        /// Defines if Maths.StandardDeviation should throw on IEnumerable of less then 2 values, else return 0M
        /// </summary>
        ThrowOnScalar = 0x40000000,
        /// <summary>
        /// Do not use Bessel's Correction 
        /// </summary>
        Biased = 0x20000000,
        /// <summary>
        /// Default behaviour, throw on scalar or null. Use Bessel's Correction
        /// </summary>
        Defaults = ThrowOnScalar

    }

    /// <summary>
    /// Calculate √(value) as decimal, within epsilon of real value 
    /// </summary>
    /// <param name="value"></param>
    /// <param name="epsilon"></param>
    /// <returns></returns>
    public static decimal Sqrt(decimal value, decimal epsilon = 0.0M)
    {
        if (value < 0) throw new OverflowException($"√{value} == i√{-value}, decimal only allows real finite numbers.");

        decimal difference;
        decimal current = (decimal)Math.Sqrt((double)value); // good starting approximate
        do
        {
            if (current == 0.0M)
            {
                return 0; // dev zero guard, if zero then we are not going to get closer
            }
            var previous = current;
            // Newton's iterative square root method https://en.wikipedia.org/wiki/Newton%27s_method
            current = (previous + value / previous) / 2; 
            difference = (previous - current);
        } while (difference > epsilon    // is difference within tolerance? 
              && difference < epsilon ); // Should loop no more then three times
        return current;
    }
}