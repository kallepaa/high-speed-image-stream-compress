
namespace StreamCompress.Utils {

	/// <summary>
	/// Interface for saving and opening saveable domain objects in project
	/// </summary>
	/// <typeparam name="T">Type of domain object</typeparam>
	public interface ISaveable<T> {
		/// <summary>
		/// Saves object to given file
		/// </summary>
		/// <param name="path">File path</param>
		/// <returns></returns>
		T Save(string path);
		/// <summary>
		/// Reads object from given file
		/// </summary>
		/// <param name="path">File name</param>
		/// <returns>Object</returns>
		T Open(string path);
	}
}
