using UnityEngine;

namespace Utilities
{
	/// <summary>
	/// The class for easy hard disk data access(PlayerPrefs)
	/// </summary>
	public static class PlayerPrefsManager
	{
		#region PlayerPrefs Constants
		// The constant string data keys for data access
		const string HASH_DELIM = "$hsh$";
		static string[] KEY_TEXTS =
			new string[]{
				"MASTER_VOLUME" ,
				"SURVIVAL_HIGHSCORE" ,
				"NUMBER_OF_PROJECTILES" ,
				"NUMBER_OF_MAXIMUM_PROJECTILE_CLASSES_IDX",
				"PYTHON_DIR"};
		static string[] KEYS =
			Utils.Zip( KEY_TEXTS , ( k ) => k + HASH_DELIM + k.GetHashCode() );
		const int
			MASTER_VOLUME_IDX = 0,
			SURVIVAL_HIGHSCORE_IDX = 1,
			NUMBER_OF_PROJECTILES_IDX = 2,
			NUMBER_OF_MAXIMUM_PROJECTILE_CLASSES_IDX = 3,
			PYTHON_DIR_IDX = 4;
		#endregion

		#region Volume Functions
		public static float MasterVolume
		{
			get => PlayerPrefs.GetFloat( KEYS[ MASTER_VOLUME_IDX ] , 1 );
			set
			{
				PlayerPrefs.SetFloat( KEYS[ MASTER_VOLUME_IDX ] , value );
				PlayerPrefs.Save();
			}
		}
		#endregion

		#region HighScore Functions
		/// <summary>
		/// Checks if the value you passed in is a new highscore.
		/// If it is then it sets the highscore to the value you passed in and returns true.
		/// If not the it just returns false.
		/// </summary>
		/// <param name="value">
		/// The value to check and set highscore
		/// </param>
		/// <returns>
		/// If the value you passed in is greater than the old highscore then it
		/// sets the highscore to the value you passed in and returns true.
		/// If not the it just returns false.
		/// </returns>
		public static bool SetIfIsNewSurvivalHighscore( float value )
		{
			if ( value > SurvivalHighscore )
			{
				SurvivalHighscore = value;
				return true;
			}
			return false;
		}

		/// <summary>
		/// Resets the highscore
		/// </summary>
		public static void ResetSurvivalHighscore( ) => SurvivalHighscore = 0;

		/// <summary>
		/// The highscore value
		/// </summary>
		public static float SurvivalHighscore
		{
			get => PlayerPrefs.GetFloat( KEYS[ SURVIVAL_HIGHSCORE_IDX ] , 0 );
			private set
			{
				PlayerPrefs.SetFloat( KEYS[ SURVIVAL_HIGHSCORE_IDX ] , value );
				PlayerPrefs.Save();
			}
		}
		#endregion

		public static int NumProjectiles
		{
			get => PlayerPrefs.GetInt( KEYS[ NUMBER_OF_PROJECTILES_IDX ] , 1 );
			set
			{
				PlayerPrefs.GetInt( KEYS[ NUMBER_OF_PROJECTILES_IDX ] , value );
				PlayerPrefs.Save();
			}
		}
		public static int NumMaxProjectilesClasses
		{
			get => PlayerPrefs.GetInt( KEYS[ NUMBER_OF_MAXIMUM_PROJECTILE_CLASSES_IDX ] , 1 );
			set
			{
				PlayerPrefs.GetInt( KEYS[ NUMBER_OF_MAXIMUM_PROJECTILE_CLASSES_IDX ] , value );
				PlayerPrefs.Save();
			}
		}

		public static string PythonDir
		{
			get => PlayerPrefs.GetString( KEYS[ PYTHON_DIR_IDX ],@"C:\Python37" );
			set
			{
				PlayerPrefs.SetString( KEYS[ PYTHON_DIR_IDX ] , value );
				PlayerPrefs.Save();
			}
		}
	}

	/// <summary>
	/// This class helps you to save boolean values
	/// and retrieve them. And it saves the values right when you set them.
	/// <para>So you wont have to write:</para>
	/// <para>BoolPlayerPrefs.SetBool(x,true);</para>
	/// <para>PlayerPrefs.Save ();</para>
	/// You can just write:
	/// <para>BoolPlayerPrefs.SetBool(x,true);</para>
	/// </summary>
	public sealed class BoolPlayerPrefs
	{
		/// <summary>
		/// Sets the boolean value with the key you passed in.
		/// </summary>
		/// <param name="key">
		/// The key, tag of the boolean value you want to save to or edit.
		/// </param>
		/// <param name="value">
		/// The value you want to set to the corresponding key you passed in.
		/// </param>
		public static void SetBool( string key , bool value )
		{
			PlayerPrefs.SetString( key , value.ToString() );
			PlayerPrefs.Save();
		}

		/// <summary>
		/// Gets the boolean value with the key you passed in.
		/// </summary>
		/// <param name="key">
		/// The key, tag of the boolean value you want to read.
		/// </param>
		/// <param name="defaultValue">
		/// The defaule value return value you want to get if the actual value isn't set.
		/// </param>
		/// <returns>
		/// The boolean value with the key you passed in.
		/// </returns>
		public static bool GetBool( string key , bool defaultValue = false )
		{
			string v = PlayerPrefs.GetString( key , defaultValue.ToString() );
			if ( v == true.ToString() ) return true;
			else return false;
		}
	}
}
