
namespace StreamCompress {
	public interface ISaveable<T> {
		T Save(string path);
	}
}
