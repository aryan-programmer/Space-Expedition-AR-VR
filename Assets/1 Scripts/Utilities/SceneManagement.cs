using UnityEngine.SceneManagement;
using UnityEngine;

namespace Utilities
{
    /// <summary>
    /// The scene management class
    /// </summary>
    public static class SceneManagemant
    {
        # region Load Level Overloads
        /// <summary>
        /// Reloads the current level or scene
        /// </summary>
        public static void LoadLevel ()
        {
            SceneManager.LoadScene ( SceneManager.GetActiveScene ().buildIndex );
        }

        /// <summary>
        /// Loads the scene or level with the build index
        /// </summary>
        /// <param name="buildIndex">
        /// The build index of the level you want to load
        /// </param>
        public static void LoadLevel ( int buildIndex )
        {
            SceneManager.LoadScene ( buildIndex );
        }

        /// <summary>
        /// Loads the scene or level with the name you pass in
        /// </summary>
        /// <param name="sceneName">
        /// The name of the level you want to load
        /// </param>
        public static void LoadLevel ( string sceneName )
        {
            SceneManager.LoadScene ( sceneName );
        }
        # endregion

        /// <summary>
        /// Returns the number of the type of object 
        /// that you passed in that are in the scene
        /// </summary>
        /// <typeparam name="T">
        /// The type of the number of objects you want to get
        /// </typeparam>
        /// <returns>
        /// The number of the type of objects in the scene
        /// </returns>
        public static int ObjsOfTypeInScreen<T> () where T : Object
        {
            return GameObject.FindObjectsOfType<T> ().Length;
        }

        /// <summary>
        /// Quits the application
        /// </summary>
        public static void Quit ()
        {
            Application.Quit ();
        }
    }
}
