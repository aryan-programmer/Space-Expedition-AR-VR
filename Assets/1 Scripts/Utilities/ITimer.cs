namespace Utilities.Timers
{
	/// <summary>
	/// Standard Timer Implementation Interface
	/// </summary>
	/// <typeparam name="T">
	/// Pass in the value returned by the start function, idealy the timer itself
	/// </typeparam>
	interface ITimer<T> : System.IDisposable
	{
		/// <summary>
		/// Starts the timer and idealy returns the timer
		/// </summary>
		/// <returns>
		/// Idealy returns the timer
		/// </returns>
		T Start( );

		bool Stopped { get; set; }
		System.Action FunctionToCallEachTick { get; set; }

		void OnUpdate( float deltaTime );
	}
}