using System.Collections.Generic;
using UnityEngine;

namespace Utilities
{
	/// <summary>
	/// The main utilities class.
	/// </summary>
	public static class Utils
	{
		public static int? CompareState<T, TCompRet>(
			this T val ,
			System.Func<T , T , TCompRet> comparer ,
			TCompRet expectedValue ,
			params T[] args )
			where T : System.IComparable<T>
			where TCompRet : System.IComparable<TCompRet>
		{
			for ( int i = 0; i < args.Length; i++ )
				if (comparer( val , args[ i ] ).
					CompareTo( expectedValue ) == 0 )
					return i;
			return null;
		}
		public static int? CompareState<T, TCompRet>(
			this T val ,
			System.Func<T , T , T , TCompRet> comparer ,
			TCompRet expectedValue ,
			params (T, T)[] args )
			where T : System.IComparable<T>
			where TCompRet : System.IComparable<TCompRet>
		{
			for ( int i = 0; i < args.Length; i++ )
				if (
					comparer(
						val,
						args[ i ].Item1 ,
						args[ i ].Item2 ).
						CompareTo( expectedValue ) == 0 )
					return i;
			return null;
		}

		#region IsBetween
		public static bool IsBetween<T>( this T value , T lower , T upper )
			where T : System.IComparable<T> =>
				value.CompareTo( lower ) > 0 &&
				value.CompareTo( upper ) < 0;
		public static bool IsBetweenUpperIncl<T>(
			this T value ,
			T lower ,
			T upper )
			where T : System.IComparable<T> =>
			value.CompareTo( lower ) > 0 &&
			value.CompareTo( upper ) <= 0;
		public static bool IsBetweenLowerIncl<T>(
			this T value ,
			T lower ,
			T upper )
			where T : System.IComparable<T> =>
			value.CompareTo( lower ) >= 0 &&
			value.CompareTo( upper ) < 0;
		public static bool IsBetweenIncl<T>( this T value , T lower , T upper )
			where T : System.IComparable<T> =>
			value.CompareTo( lower ) >= 0 &&
			value.CompareTo( upper ) <= 0;
		#endregion

		#region Randomize Array
		/// <summary>
		/// Shuffles the array you passed in and returns it.
		/// Along with keeping the array you passed in as a parameter intact.
		/// </summary>
		/// <typeparam name="T">
		/// The type of the array
		/// </typeparam>
		/// <param name="arrayParam">
		/// The array that will be copied and shuffled
		/// </param>
		/// <returns>
		/// Another array that has all the elements as the orignal array but just shuffeed
		/// </returns>
		public static T[] ShuffleArray<T>( T[] arrayParam )
		{
			T[] array = DuplicateArray( arrayParam );
			System.Random prng = new System.Random();

			for ( int i = 0;
				i < array.Length - 1;
				i++ )
			{
				int randomIndex = prng.Next( i , array.Length );
				T tempItem = array[ randomIndex ];
				array[ randomIndex ] = array[ i ];
				array[ i ] = tempItem;
			}

			return array; ;
		}

		/// <summary>
		/// Shuffles the array you passed in and returns it.
		/// Along with keeping the array you passed in as a parameter intact.
		/// </summary>
		/// <typeparam name="T">
		/// The type of the array
		/// </typeparam>
		/// <param name="arrayParam">
		/// The array that will be copied and shuffled
		/// </param>
		/// <param name="seed">
		/// The seed value for the random generator
		/// </param>
		/// <returns>
		/// Another array that has all the elements as the orignal array but just shuffeed
		/// </returns>
		public static T[] ShuffleArray<T>( T[] arrayParam , int seed )
		{
			T[] array = DuplicateArray( arrayParam );
			System.Random prng = new System.Random();

			for ( int i = 0;
				i < array.Length - 1;
				i++ )
			{
				int randomIndex = prng.Next( i , array.Length );
				T tempItem = array[ randomIndex ];
				array[ randomIndex ] = array[ i ];
				array[ i ] = tempItem;
			}

			return array; ;
		}

		/// <summary>
		/// Gets a random element from the array you passed in and returns it
		/// </summary>
		/// <typeparam name="T">
		/// The type of the array
		/// </typeparam>
		/// <param name="array">
		/// The array from which to extract random element
		/// </param>
		/// <returns>
		/// A random element from the array you passed in
		/// </returns>
		public static T GetRandomElementFromArray<T>( T[] array )
		{ return array[ Random.Range( 0 , array.Length ) ]; }
		#endregion

		#region Random Between Vector 2 and 4
		/// <summary>
		/// Returns a random value between Vector 2 Bounds
		/// </summary>
		/// <param name="V2">
		/// (Hidden due to being extension parameter)
		/// The bounds
		/// </param>
		/// <returns>
		/// Returns a random value between Vector 2 Bounds
		/// </returns>
		public static float RandomBetweenV2Bounds( Vector2 V2 )
		{
			return Random.Range( V2.x , V2.y );
		}

		/// <summary>
		/// Returns a random Vector 2 between Vector 4 Bounds
		/// </summary>
		/// <param name="V4">
		/// The bounds
		/// </param>
		/// <returns>
		/// Returns a random Vector 2 between Vector 4 Bounds
		/// </returns>
		public static Vector2 RandomBetweenV4( Vector4 V4 )
		{
			Vector2 v = new Vector2( V4.x , V4.y );
			Vector2 v2 = new Vector2( V4.z , V4.w );
			return new Vector2( RandomBetweenV2Bounds( v ) , RandomBetweenV2Bounds( v2 ) );
		}
		#endregion

		#region Swapping and Array Duplication
		/// <summary>
		/// Swaps the values the variables you passed in
		/// </summary>
		/// <typeparam name="T">
		/// The type of the variables you pass in
		/// </typeparam>
		/// <param name="variable1">
		/// The variable whose value you want to replace with the second variable
		/// </param>
		/// <param name="variable2">
		/// The variable whose value you want to replace with the first variable
		/// </param>
		public static void Swap<T>( ref T variable1 , ref T variable2 )
		{
			T temp = variable1;
			variable1 = variable2;
			variable2 = temp;
		}

		/// <summary>
		/// Returns a new array in a different memory location,
		/// the new array being identical to the array you passed in as a parameter.
		/// (Refer at C or C++ pointers to know why arrays are like this)
		/// </summary>
		/// <typeparam name="T">
		/// The type of the array you want to duplicate
		/// </typeparam>
		/// <param name="arrayToDuplicate">
		/// The array you want to duplicate
		/// </param>
		/// <returns>
		/// A new array in a different memory location,
		/// the new array being identical to the array you passed in as a parameter.
		/// (Again Refer at C or C++ pointers to know why arrays are like this)
		/// </returns>
		public static T[] DuplicateArray<T>( T[] arrayToDuplicate )
		{
			T[] array;

			{
				List<T> temp = new List<T>();
				foreach ( T tempItem in arrayToDuplicate )
				{
					temp.Add( tempItem );
				}
				array = temp.ToArray();
			}

			return array;
		}
		#endregion

		#region Average
		public static float Average( IEnumerator<float> enumerator )
		{
			uint sz = 0;
			float avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return avg / sz;
		}
		public static double Average( IEnumerator<double> enumerator )
		{
			uint sz = 0;
			double avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return avg / sz;
		}
		public static short Average( IEnumerator<short> enumerator )
		{
			uint sz = 0;
			short avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return ( short ) ( avg / sz );
		}
		public static int Average( IEnumerator<int> enumerator )
		{
			uint sz = 0;
			int avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return ( int ) ( avg / sz );
		}
		public static long Average( IEnumerator<long> enumerator )
		{
			uint sz = 0;
			long avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return avg / sz;
		}
		public static decimal Average( IEnumerator<decimal> enumerator )
		{
			uint sz = 0;
			decimal avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return avg / sz;
		}
		public static ushort Average( IEnumerator<ushort> enumerator )
		{
			uint sz = 0;
			ushort avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return ( ushort ) ( avg / sz );
		}
		public static uint Average( IEnumerator<uint> enumerator )
		{
			uint sz = 0;
			uint avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return avg / sz;
		}
		public static ulong Average( IEnumerator<ulong> enumerator )
		{
			uint sz = 0;
			ulong avg = 0;
			while ( enumerator.MoveNext() )
			{
				avg += enumerator.Current;
				++sz;
			}
			return avg / sz;
		}

		public static float Average( params float[] vals )
		{
			float avg = 0;
			foreach ( var val in vals )
				avg += val;
			return avg / vals.Length;
		}
		public static double Average( params double[] vals )
		{
			double avg = 0;
			foreach ( var val in vals )
				avg += val;
			return avg / vals.Length;
		}
		public static short Average( params short[] vals )
		{
			short avg = 0;
			foreach ( var val in vals )
				avg += val;
			return ( short ) ( avg / vals.Length );
		}
		public static int Average( params int[] vals )
		{
			int avg = 0;
			foreach ( var val in vals )
				avg += val;
			return avg / vals.Length;
		}
		public static long Average( params long[] vals )
		{
			long avg = 0;
			foreach ( var val in vals )
				avg += val;
			return avg / vals.Length;
		}
		public static decimal Average( params decimal[] vals )
		{
			decimal avg = 0;
			foreach ( var val in vals )
				avg += val;
			return avg / vals.Length;
		}
		public static ushort Average( params ushort[] vals )
		{
			ushort avg = 0;
			foreach ( var val in vals )
				avg += val;
			return ( ushort ) ( avg / vals.Length );
		}
		public static uint Average( params uint[] vals )
		{
			uint avg = 0;
			foreach ( var val in vals )
				avg += val;
			return ( uint ) ( avg / vals.Length );
		}
		public static ulong Average( params ulong[] vals )
		{
			ulong avg = 0;
			foreach ( var val in vals )
				avg += val;
			return avg / ( uint ) vals.Length;
		}
		#endregion

		public static TReturn[] Zip<T1, TReturn>(
			T1[] t1s ,
			System.Func<T1 , TReturn> func )
		{
			TReturn[] returns = new TReturn[ t1s.Length ];
			for ( int i = 0; i < t1s.Length; i++ )
				returns[ i ] = func( t1s[ i ] );
			return returns;
		}

		public static TReturn[] Zip<T1, T2, TReturn>(
			T1[] t1s, 
			T2[] t2s, 
			System.Func<T1,T2,TReturn> func )
		{
			var lowerLength = Mathf.Min( t1s.Length , t2s.Length );
			TReturn[] returns = new TReturn[ lowerLength ];
			for ( int i = 0; i < lowerLength; i++ )
				returns[ i ] = func( t1s[ i ] , t2s[ i ] );
			return returns;
		}
	}
}