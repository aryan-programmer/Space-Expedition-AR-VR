using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Utilities.Extensions
{
	/// <summary>
	/// Extension library for Components and GameObjects
	/// </summary>
	public static class GameObjectShorteningExtensions
	{
		#region Legendary quick Accessing Of Components
		/// <summary>
		/// Returns The rigidbody on the component
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The rigidbody on the component
		/// </returns>
		public static Rigidbody GetRigidbody<T>( this T gameObject ) where T : Component
		{
			try
			{
				return gameObject.GetComponent<Rigidbody>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The animation on the component
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The animation on the component
		/// </returns>
		public static Animation GetAnimation<T>( this T gameObject ) where T : Component
		{
			try
			{
				return gameObject.GetComponent<Animation>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The animator on the component
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The animator on the component
		/// </returns>
		public static Animator GetAnimator<T>( this T gameObject ) where T : Component
		{
			try
			{
				return gameObject.GetComponent<Animator>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The collider on the component
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The collider on the component
		/// </returns>
		public static Collider GetCollider<T>( this T gameObject ) where T : Component
		{
			try
			{
				return gameObject.GetComponent<Collider>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The 2d collider on the component
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The 2d collider on the component
		/// </returns>
		public static Collider2D GetCollider2D<T>( this T gameObject ) where T : Component
		{
			try
			{
				return gameObject.GetComponent<Collider2D>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The renderer on the component
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The renderer on the component
		/// </returns>
		public static Renderer GetRenderer<T>( this T gameObject ) where T : Component
		{
			try
			{
				return gameObject.GetComponent<Renderer>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The 2d rigidbody on the component
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The 2d rigidbody on the component
		/// </returns>
		public static Rigidbody2D GetRigidbody2D<T>( this T gameObject ) where T : Component
		{
			try
			{
				return gameObject.GetComponent<Rigidbody2D>();
			}
			catch { return null; }
		}
		#endregion

		#region Legendary quick Accessing Of Components
		/// <summary>
		/// Returns The rigidbody on the gameObject
		/// </summary>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The rigidbody on the gameObject
		/// </returns>
		public static Rigidbody GetRigidbody( this GameObject gameObject )
		{
			try
			{
				return gameObject.GetComponent<Rigidbody>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The animation on the gameObject
		/// </summary>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The animation on the gameObject
		/// </returns>
		public static Animation GetAnimation( this GameObject gameObject )
		{
			try
			{
				return gameObject.GetComponent<Animation>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The animator on the gameObject
		/// </summary>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The animator on the gameObject
		/// </returns>
		public static Animator GetAnimator( this GameObject gameObject )
		{
			try
			{
				return gameObject.GetComponent<Animator>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The collider on the gameObject
		/// </summary>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The collider on the gameObject
		/// </returns>
		public static Collider GetCollider( this GameObject gameObject )
		{
			try
			{
				return gameObject.GetComponent<Collider>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The 2d collider on the gameObject
		/// </summary>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The 2d collider on the gameObject
		/// </returns>
		public static Collider2D GetCollider2D( this GameObject gameObject )
		{
			try
			{
				return gameObject.GetComponent<Collider2D>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The renderer on the gameObject
		/// </summary>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The renderer on the gameObject
		/// </returns>
		public static Renderer GetRenderer( this GameObject gameObject )
		{
			try
			{
				return gameObject.GetComponent<Renderer>();
			}
			catch { return null; }
		}

		/// <summary>
		/// Returns The 2d rigidbody on the gameObject
		/// </summary>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns>
		/// The 2d rigidbody on the gameObject
		/// </returns>
		public static Rigidbody2D GetRigidbody2D( this GameObject gameObject )
		{
			try
			{
				return gameObject.GetComponent<Rigidbody2D>();
			}
			catch { return null; }
		}
		#endregion

		/// <summary>
		/// Extension to component
		/// Shortened Version of GetComponent();
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns></returns>
		public static TToReturn Get<TToReturn, TToExtendTo>( this TToExtendTo gameObject )
			where TToExtendTo : Component
			where TToReturn : Object
		{
			try
			{
				return gameObject.GetComponent<TToReturn>();
			}
			catch { return null; }
		}

		public static T GetAdd<T>( this GameObject gameObject )
			where T : Component
		{
			T component = gameObject.GetComponent<T>();
			if ( component == null ) return gameObject.AddComponent<T>();
			else return component;
		}

		/// <summary>
		/// Extension to GameObject
		/// Shortened Version of GetComponent();
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns></returns>
		public static T Get<T>( this GameObject gameObject ) where T : Object
		{
			try
			{
				return gameObject.GetComponent<T>();
			}
			catch { return null; }
		}

		public static T GetAdd<T>( this MonoBehaviour gameObject )
	where T : Component
		{
			T component = gameObject.GetComponent<T>();
			if ( component == null ) return gameObject.gameObject.AddComponent<T>();
			else return component;
		}

		/// <summary>
		/// Extension to GameObject
		/// Shortened Version of GetComponent();
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns></returns>
		public static T Get<T>( this MonoBehaviour gameObject ) where T : Object
		{
			try
			{
				return gameObject.GetComponent<T>();
			}
			catch { return null; }
		}

/// <summary>
		/// Extension to GameObject
		/// Shortened Version of GameObject.FindObjectOfType();
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns></returns>
		public static T Find<T>( this GameObject gameObject ) where T : Object
		{
			return GameObject.FindObjectOfType<T>();
		}

		/// <summary>
		/// Extension to component
		/// Shortened Version of GameObject.FindObjectOfType();
		/// </summary>
		/// <typeparam name="T">(Hidden)</typeparam>
		/// <param name="gameObject">(Hidden)</param>
		/// <returns></returns>
		public static TToReturn Find<TToReturn, TToExtendTo>( this TToExtendTo gameObject )
			where TToExtendTo : Component
			where TToReturn : Object
		{
			try
			{
				return GameObject.FindObjectOfType<TToReturn>();
			}
			catch { return null; }
		}
	}
}
