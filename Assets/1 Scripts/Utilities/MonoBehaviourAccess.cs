using UnityEngine;
namespace Utilities
{
	/// <summary>
	/// Used To get access to MonoBehaviour functions from non-MonoBehavior classes
	/// </summary>
	public class MonoBehaviourAccess : MonoBehaviour
	{
		#region Statics
		static MonoBehaviourAccess staticInstanceHolder;
		static MonoBehaviourAccess instance
		{
			get
			{
				if ( staticInstanceHolder == null )
					if ( FindObjectOfType<MonoBehaviourAccess>() != null ) staticInstanceHolder = FindObjectOfType<MonoBehaviourAccess>();
					else staticInstanceHolder = new GameObject( "MonoBehaviourAccess" ).AddComponent<MonoBehaviourAccess>();
				return staticInstanceHolder;
			}
		}

		/// <summary>
		/// Runs an IEnumerator Coroutine in a non-MonoBehavior class
		/// </summary>
		/// <param name="iEnumeratorCorutine">
		/// The IEnumerator value that you usually pass into StartCoroutine
		/// </param>
		/// <returns>
		/// The Coroutine thats usually returned by StartCoroutine
		/// </returns>
		public static Coroutine RunTimerCoroutine( System.Collections.IEnumerator iEnumeratorCorutine ) => instance.StartCoroutine( iEnumeratorCorutine );

		/// <summary>
		/// Returns a static MonoBehavior
		/// </summary>
		/// <returns></returns>
		public static MonoBehaviour I => instance;

		/// <summary>
		/// Remember that you can't instantiate a MonoBehavior using the new keyword
		/// This function can help you to instantiate a new MonoBehavior
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T NewMonoBehaviour<T>( ) where T : MonoBehaviour
		{
			GameObject gameObject = new GameObject( "Instantiated MonoBehavior No." +
				( instance.transform.childCount + 1 ).ToString() );
			gameObject.transform.parent = instance.transform;
			return gameObject.AddComponent<T>();
		}

		/// <summary>
		/// Remember that you can't instantiate a MonoBehavior using the new keyword
		/// This function can help you to instantiate a new MonoBehavior
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="parent">
		/// The Parent of the instantiated MonoBehavior
		/// </param>
		/// <returns></returns>
		public static T NewMonoBehaviour<T>( Transform parent ) where T : MonoBehaviour
		{
			GameObject gameObject = new GameObject( "Instantiated MonoBehavior No." +
				( instance.transform.childCount + 1 ).ToString() );
			gameObject.transform.parent = parent;
			return gameObject.AddComponent<T>();
		}

		/// <summary>
		/// Remember that you can't instantiate a MonoBehavior using the new keyword
		/// This function can help you to instantiate a new MonoBehavior
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="name">
		/// The name you want to give to the gameObject on which the instantiated monoBehavior is
		/// </param>
		/// <returns></returns>
		public static T NewMonoBehaviour<T>( string name ) where T : MonoBehaviour
		{
			GameObject gameObject = new GameObject( name );
			gameObject.transform.parent = instance.transform;
			return gameObject.AddComponent<T>();
		}

		/// <summary>
		/// Remember that you can't instantiate a MonoBehavior using the new keyword
		/// This function can help you to instantiate a new MonoBehavior
		/// </summary>
		/// <typeparam name="T"></typeparam>
		/// <param name="parent">
		/// The Parent of the instantiated MonoBehavior
		/// </param>
		/// <param name="name">
		/// The name you want to give to the gameObject on which the instantiated monoBehavior is
		/// </param>
		/// <returns></returns>
		public static T NewMonoBehaviour<T>( Transform parent , string name ) where T : MonoBehaviour
		{
			GameObject gameObject = new GameObject( name );
			gameObject.transform.parent = parent;
			return gameObject.AddComponent<T>();
		}
		#endregion
	}
}