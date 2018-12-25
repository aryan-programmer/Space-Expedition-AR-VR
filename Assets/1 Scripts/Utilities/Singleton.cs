using UnityEngine;

public abstract class Singleton_<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T I
	{
		get
		{
			//Check if instance already exists
			if ( instance == null )
			{
				//if not, set instance to of type T
				instance = FindObjectOfType<T>();
				//If instance already exists and it's not this:
			}
			else if ( instance != FindObjectOfType<T>() )
			{
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy( FindObjectOfType<T>() );
			}
			//Sets this to not be destroyed when reloading scene
			// DontDestroyOnLoad(FindObjectOfType<T>());
			return instance;
		}
	}
}

public abstract class SingletonNotDestroyOnLoad<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	public static T I
	{
		get
		{
			//Check if instance already exists
			if ( instance == null )
			{
				//if not, set instance to of type T
				instance = FindObjectOfType<T>();
				//If instance already exists and it's not this:
			}
			else if ( instance != FindObjectOfType<T>() )
			{
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy( FindObjectOfType<T>() );
			}
			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad(FindObjectOfType<T>());
			return instance;
		}
	}
}

public abstract class ProtectedSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	protected static T I
	{
		get
		{
			//Check if instance already exists
			if ( instance == null )
			{
				//if not, set instance to of type T
				instance = FindObjectOfType<T>();
				//If instance already exists and it's not this:
			}
			else if ( instance != FindObjectOfType<T>() )
			{
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy( FindObjectOfType<T>() );
			}
			//Sets this to not be destroyed when reloading scene
			// DontDestroyOnLoad(FindObjectOfType<T>());
			return instance;
		}
	}
}

public abstract class ProtectedSingletonNotDestroyOnLoad<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T instance;

	protected static T I
	{
		get
		{
			//Check if instance already exists
			if ( instance == null )
			{
				//if not, set instance to of type T
				instance = FindObjectOfType<T>();
				//If instance already exists and it's not this:
			}
			else if ( instance != FindObjectOfType<T>() )
			{
				//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
				Destroy( FindObjectOfType<T>() );
			}
			//Sets this to not be destroyed when reloading scene
			DontDestroyOnLoad( FindObjectOfType<T>() );
			return instance;
		}
	}
}
