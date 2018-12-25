using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Extensions
{
    /// <summary>
    /// The main utilities extension class
    /// </summary>
    public static class UtilsExtension
    {

        /// <summary>
        /// Exension Of An Array
        /// As In If you have an array and you are "using Utilities;"
        /// and if you have an array called "Array"(Any name will work though)
        /// now to shuffle it you can type "Array.ShuffleArray();"
        /// to shuffle the array. WARNING: this function changes the original array
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array
        /// </typeparam>
        /// <param name="array">
        /// (Hidden parameter due to being extension parameter)
        /// </param>
        /// <returns>
        /// Another array that has all the elements as the orignal array but just shuffeed
        /// </returns>
        public static T[] ShuffleArray<T> ( this T[] array )
        {
            System.Random prng = new System.Random ();

            for ( int i = 0 ;
                i < array.Length - 1 ;
                i++ )
            {
                int randomIndex = prng.Next ( i , array.Length );
                T tempItem = array[ randomIndex ];
                array[ randomIndex ] = array[ i ];
                array[ i ] = tempItem;
            }

            return array;
        }

        /// <summary>
        /// Extension of an array
        /// As In If you have an array and you are "using Utilities;"
        /// and if you have an array called "Array"(Any name will work though)
        /// now to shuffle it you can type "Array.ShuffleArray();"
        /// to shuffle the array. WARNING: this function changes the original array
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array
        /// </typeparam>
        /// <param name="array">
        /// (Hidden parameter due to being extension parameter)
        /// </param>
        /// <param name="seed">
        /// The seed value for the random generator
        /// </param>
        /// <returns>
        /// Another array that has all the elements as the orignal array but just shuffeed
        /// </returns>
        public static T[] ShuffleArray<T> ( this T[] array , int seed )
        {
            System.Random prng = new System.Random ( seed );

            for ( int i = 0 ;
                i < array.Length - 1 ;
                i++ )
            {
                int randomIndex = prng.Next ( i , array.Length );
                T tempItem = array[ randomIndex ];
                array[ randomIndex ] = array[ i ];
                array[ i ] = tempItem;
            }

            return array;
        }


        /// <summary>
        /// Extension of an array
        /// Gets a random element from the array where you had written
        /// n.GetRandomElement();
        /// (n is the name of the array)
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array
        /// </typeparam>
        /// <param name="array">
        /// (Hidden due to being extension parameter)
        /// The array from which to extract random element
        /// </param>
        /// <returns>
        /// A random element from the array
        /// </returns>
        public static T GetRandomElement<T> ( this T[] array )
        { return array[ Random.Range ( 0 , array.Length ) ]; }

        /// <summary>
        /// Extension of an array
        /// Returns a new array in a different memory location,
        /// the new array being identical to the array you passed in as a parameter.
        /// (Refer at C or C++ pointers to know why arrays are like this)
        /// </summary>
        /// <typeparam name="T">
        /// The type of the array you want to duplicate
        /// </typeparam>
        /// <param name="arrayToDuplicate">
        /// (Hidden due to being extension parameter)
        /// The array you want to duplicate
        /// </param>
        /// <returns>
        /// A new array in a different memory location,
        /// the new array being identical to the array you passed in as a parameter.
        /// (Again Refer at C or C++ pointers to know why arrays are like this)
        /// </returns>
        public static T[] Duplicate<T> ( this T[] arrayToDuplicate )
        {
            T[] array;

            {
                List<T> temp = new List<T> ();
                foreach ( T tempItem in arrayToDuplicate )
                {
                    temp.Add ( tempItem );
                }
                array = temp.ToArray ();
            }

            return array;
        }

        /// <summary>
        /// Extension of vector 2
        /// Returns a random value between Vector 2 Bounds
        /// </summary>
        /// <param name="V2">
        /// The bounds
        /// (Hidden due to being extension parameter)
        /// </param>
        /// <returns>
        /// Returns a random value between Vector 2 Bounds
        /// </returns>
        public static float RandomBetweenBounds ( this Vector2 V2 )
        {
            return Random.Range ( V2.x , V2.y );
        }
    }
}