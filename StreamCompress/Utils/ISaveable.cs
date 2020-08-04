
namespace StreamCompress.Utils {

	/// <summary>
	/// Interface for saving and opening saveable domain objects in project
	/// </summary>
	/// <typeparam name="T">Type of domain object</typeparam>
	public interface ISaveable<T> {
		T Save(string path);
		T Open(string path);
	}
}
