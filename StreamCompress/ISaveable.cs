
namespace StreamCompress {
	public interface ISaveable<T> {
		T Save(string path);
		T Open(string path);
	}
}
