using System.Collections;
using UnityEngine;

namespace Utilities.Timers
{
	[System.Serializable]
	public class TimerWithExtraWaiting
	{
		float secondsBetweenTicks,
			  currentTimerValue;
		System.Func<float> functionToCallEachTick;
		System.Action postFunc;
		bool stopped;

		public bool Stopped { get => stopped; set => stopped = value; }
		public System.Func<float> FunctionToCallEachTick { get => functionToCallEachTick; set => functionToCallEachTick = value; }
		public System.Action PostFunc { get => postFunc; set => postFunc = value; }

		[System.Serializable]
		public struct Initializer
		{
			public float secondsBetweenTicks;
		}

		/// <summary>
		/// Creates a new Timer
		/// </summary>
		/// <param name="_secondsBetweenTicks">
		/// The time between every "tick"
		/// </param>
		/// <param name="_functionToCallEachTick">
		/// The function that is called every "tick"
		/// </param>
		public TimerWithExtraWaiting( 
			float _secondsBetweenTicks ,
			System.Func<float> _functionToCallEachTick ,
			System.Action postFunc = null )
		{
			secondsBetweenTicks = _secondsBetweenTicks;
			functionToCallEachTick = _functionToCallEachTick;
			stopped = true;
			this.postFunc = postFunc;
			currentTimerValue = secondsBetweenTicks;
		}

		public TimerWithExtraWaiting(
			Initializer initializer ,
			System.Func<float> _functionToCallEachTick ,
			System.Action postFunc = null ) :
			this( initializer.secondsBetweenTicks , _functionToCallEachTick , postFunc )
		{ }

		/// <summary>
		/// Starts the Timer
		/// </summary>
		/// <returns>
		/// Itself
		/// </returns>
		public TimerWithExtraWaiting Start( )
		{
			MonoBehaviourAccess.RunTimerCoroutine( StartIEnumeratorTimer() );
			return this;
		}

		IEnumerator StartIEnumeratorTimer( )
		{
			stopped = false;
			while ( !stopped )
			{
				currentTimerValue -= Time.deltaTime;
				if ( currentTimerValue <= 0 )
				{
					yield return new WaitForSeconds( functionToCallEachTick() );
					if ( stopped ) yield break;
					postFunc?.Invoke();
					currentTimerValue = secondsBetweenTicks;
				}
				yield return null;
			}
			yield break;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose( bool disposing )
		{
			if ( !disposedValue )
			{
				if ( disposing )
				{
					stopped = true;
					currentTimerValue = secondsBetweenTicks = 0;
					functionToCallEachTick = null;
				}
				disposedValue = true;
			}
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose( ) =>
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose( true );
		#endregion
	}

	/// <summary>
	/// Your normal , everyday constantly ticking timer with a fixed time between "tick"s.
	/// </summary>
	[System.Serializable]
	public class Timer : ITimer<Timer>
	{
		float secondsBetweenTicks,
			  currentTimerValue;
		System.Action functionToCallEachTick;
		bool stopped;

		public bool Stopped { get => stopped; set => stopped = value; }
		public System.Action FunctionToCallEachTick { get => functionToCallEachTick; set => functionToCallEachTick = value; }

		[System.Serializable]
		public struct Initializer
		{
			public float secondsBetweenTicks;
		}

		/// <summary>
		/// Creates a new Timer
		/// </summary>
		/// <param name="_secondsBetweenTicks">
		/// The time between every "tick"
		/// </param>
		/// <param name="_functionToCallEachTick">
		/// The function that is called every "tick"
		/// </param>
		public Timer( float _secondsBetweenTicks ,
					   System.Action _functionToCallEachTick )
		{
			secondsBetweenTicks = _secondsBetweenTicks;
			functionToCallEachTick = _functionToCallEachTick;
			stopped = true;
			currentTimerValue = secondsBetweenTicks;
		}

		public Timer(
			Initializer initializer ,
			System.Action _functionToCallEachTick ) :
			this( initializer.secondsBetweenTicks , _functionToCallEachTick )
		{ }

		/// <summary>
		/// Starts the Timer
		/// </summary>
		/// <returns>
		/// Itself
		/// </returns>
		public Timer Start( )
		{
			MonoBehaviourAccess.RunTimerCoroutine( StartIEnumeratorTimer() );
			return this;
		}

		public void OnUpdate( float deltaTime )
		{
			if ( !stopped ) return;
			ManualCheckAndRun( deltaTime );
		}

		void ManualCheckAndRun( float deltaTime )
		{
			currentTimerValue -= deltaTime;
			if ( currentTimerValue <= 0 )
			{
				functionToCallEachTick();
				currentTimerValue = secondsBetweenTicks;
			}
		}

		IEnumerator StartIEnumeratorTimer( )
		{
			stopped = false;
			while ( !stopped )
			{
				ManualCheckAndRun( Time.deltaTime );
				yield return null;
			}
			yield break;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose( bool disposing )
		{
			if ( !disposedValue )
			{
				if ( disposing )
				{
					stopped = true;
					currentTimerValue = secondsBetweenTicks = 0;
					functionToCallEachTick = null;
				}
				disposedValue = true;
			}
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose( ) =>
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose( true );
		#endregion
	}

	/// <summary>
	/// A timer that is slightly different from the normal Timer.
	/// This one has a random range that determines the time between "tick"s
	/// </summary>
	[System.Serializable]
	public class RandomizedTimer : ITimer<RandomizedTimer>
	{
		float secondsBetweenTicksMin,
			  secondsBetweenTicksMax,
			  currentTimerValue;
		System.Action functionToCallEachTick;
		bool stopped;

		public bool Stopped { get => stopped; set => stopped = value; }
		public System.Action FunctionToCallEachTick { get => functionToCallEachTick; set => functionToCallEachTick = value; }

		[System.Serializable]
		public struct Initializer
		{
			public float
				secondsBetweenTicksMin,
				secondsBetweenTicksMax;
		}

		/// <summary>
		/// Creates a new RandomizedTimer
		/// </summary>
		/// <param name="_secondsBetweenTicksMin">
		/// The lower range of the random time between "tick"s
		/// </param>
		/// <param name="_secondsBetweenTicksMax">
		/// The upper range of the random time between "tick"s
		/// </param>
		/// <param name="_functionToCallEachTick">
		/// The function that is called every "tick"
		/// </param>
		public RandomizedTimer( float _secondsBetweenTicksMin ,
								 float _secondsBetweenTicksMax ,
								 System.Action _functionToCallEachTick )
		{
			secondsBetweenTicksMin = _secondsBetweenTicksMin;
			secondsBetweenTicksMax = _secondsBetweenTicksMax;
			FunctionToCallEachTick = _functionToCallEachTick;
			stopped = true;
			currentTimerValue = Random.Range( secondsBetweenTicksMin , secondsBetweenTicksMax );
		}

		public RandomizedTimer( Initializer initializer ,
								 System.Action _functionToCallEachTick ) :
			this(
				initializer.secondsBetweenTicksMin ,
				initializer.secondsBetweenTicksMax ,
				_functionToCallEachTick )
		{ }

		/// <summary>
		/// Starts the Timer
		/// </summary>
		/// <returns>
		/// Itself
		/// </returns>
		public RandomizedTimer Start( )
		{
			MonoBehaviourAccess.RunTimerCoroutine( StartIEnumeratorTimer() );
			return this;
		}

		public void OnUpdate( float deltaTime )
		{
			if ( !Stopped ) return;
			ManualCheckAndRun( deltaTime );
		}

		void ManualCheckAndRun( float deltaTime )
		{
			currentTimerValue -= Time.deltaTime;
			if ( currentTimerValue <= 0 )
			{
				FunctionToCallEachTick();
				currentTimerValue = Random.Range( secondsBetweenTicksMin , secondsBetweenTicksMax );
			}
		}

		IEnumerator StartIEnumeratorTimer( )
		{
			stopped = false;
			while ( !stopped )
			{
				ManualCheckAndRun( Time.deltaTime );
				yield return null;
			}
			yield return null;
			yield break;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose( bool disposing )
		{
			if ( !disposedValue )
			{
				if ( disposing )
				{
					stopped = true;
					secondsBetweenTicksMin =
						secondsBetweenTicksMax =
						currentTimerValue = 0;
					FunctionToCallEachTick = null;
				}
				disposedValue = true;
			}
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose( ) => Dispose( true );
		#endregion
	}

	/// <summary>
	/// A timer that is slightly different from the RandomizedTimer.
	/// This one has a random range that determines the time between "tick"s
	/// and has another Random.Range that determines by how much does
	/// it lower the upper range of the Random.Range that determines the time between "tick"s.
	/// And the class decreases it every "tick"
	/// </summary>
	[System.Serializable]
	public class RandomizedIncreaseingTimer : ITimer<RandomizedIncreaseingTimer>
	{
		float secondsBetweenTicksMin,
			  secondsBetweenTicksMax,
			  decreaseInSecondsBetweenTicksMaxMin,
			  decreaseInSecondsBetweenTicksMaxMax,
			  currentTimerValue,
			  startSecondsBetweenTicksMin;
		System.Action functionToCallEachTick;
		bool stopped;

		public bool Stopped { get => stopped; set => stopped = value; }
		public System.Action FunctionToCallEachTick { get => functionToCallEachTick; set => functionToCallEachTick = value; }

		[System.Serializable]
		public struct Initializer
		{
			public float secondsBetweenTicksMin,
			  secondsBetweenTicksMax,
			  decreaseInSecondsBetweenTicksMaxMin,
			  decreaseInSecondsBetweenTicksMaxMax;
		}

		/// <summary>
		/// Creates a new RandomizedIncreaseingTimer
		/// </summary>
		/// <param name="_secondsBetweenTicksMin">
		/// The lower range of the random time between "tick"s
		/// </param>
		/// <param name="_secondsBetweenTicksMax">
		/// The upper range of the random time between "tick"s
		/// </param>
		/// <param name="_decreaseInSecondsBetweenTicksMaxMin">
		/// The lower range of the Random.Range that decreases the upper range of the random time between "tick"s
		/// </param>
		/// <param name="_decreaseInSecondsBetweenTicksMaxMax">
		/// The upper range of the Random.Range that decreases the upper range of the random time between "tick"s
		/// </param>
		/// <param name="_functionToCallEachTick">
		/// The function that is called every "tick"
		/// </param>
		public RandomizedIncreaseingTimer(
			float _secondsBetweenTicksMin ,
			float _secondsBetweenTicksMax ,
			float _decreaseInSecondsBetweenTicksMaxMin ,
			float _decreaseInSecondsBetweenTicksMaxMax ,
			System.Action _functionToCallEachTick )
		{
			startSecondsBetweenTicksMin = _secondsBetweenTicksMin;
			secondsBetweenTicksMin = _secondsBetweenTicksMin;
			secondsBetweenTicksMax = _secondsBetweenTicksMax;
			decreaseInSecondsBetweenTicksMaxMin = _decreaseInSecondsBetweenTicksMaxMin;
			decreaseInSecondsBetweenTicksMaxMax = _decreaseInSecondsBetweenTicksMaxMax;
			functionToCallEachTick = _functionToCallEachTick;
			Stopped = true;
			currentTimerValue = Random.Range( secondsBetweenTicksMin , secondsBetweenTicksMax );
		}

		public RandomizedIncreaseingTimer(
			Initializer initializer ,
			System.Action _functionToCallEachTick ) :
			this(
				initializer.secondsBetweenTicksMin ,
				initializer.secondsBetweenTicksMin ,
				initializer.decreaseInSecondsBetweenTicksMaxMin ,
				initializer.decreaseInSecondsBetweenTicksMaxMax ,
				_functionToCallEachTick )
		{ }

		/// <summary>
		/// Starts the Timer
		/// </summary>
		/// <returns>
		/// Itself
		/// </returns>
		public RandomizedIncreaseingTimer Start( )
		{
			MonoBehaviourAccess.RunTimerCoroutine( StartIEnumeratorTimer() );
			return this;
		}

		public void OnUpdate( float deltaTime )
		{
			if ( !Stopped ) return;
			ManualCheckAndRun( deltaTime );
		}

		void ManualCheckAndRun( float deltaTime )
		{
			currentTimerValue -= Time.deltaTime;
			if ( currentTimerValue <= 0 )
			{
				functionToCallEachTick();
				currentTimerValue = Random.Range( secondsBetweenTicksMin , secondsBetweenTicksMax );
				secondsBetweenTicksMax -= Random.Range( decreaseInSecondsBetweenTicksMaxMin , decreaseInSecondsBetweenTicksMaxMax );
				if ( secondsBetweenTicksMin >= secondsBetweenTicksMax )
					secondsBetweenTicksMax = startSecondsBetweenTicksMin;
			}
		}

		IEnumerator StartIEnumeratorTimer( )
		{
			stopped = false;
			while ( !stopped )
			{
				ManualCheckAndRun( Time.deltaTime );
				yield return null;
			}
			yield return null;
			yield break;
		}

		#region IDisposable Support
		private bool disposedValue = false; // To detect redundant calls

		protected virtual void Dispose( bool disposing )
		{
			if ( !disposedValue )
			{
				if ( disposing )
				{
					stopped = true;
					secondsBetweenTicksMin =
						secondsBetweenTicksMax =
						decreaseInSecondsBetweenTicksMaxMin =
						decreaseInSecondsBetweenTicksMaxMax =
						currentTimerValue =
						startSecondsBetweenTicksMin = 0;
					functionToCallEachTick = null;
				}
				disposedValue = true;
			}
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose( ) => Dispose( true );
		#endregion
	}
}
