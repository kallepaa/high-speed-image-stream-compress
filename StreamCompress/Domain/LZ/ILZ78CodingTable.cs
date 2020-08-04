
namespace StreamCompress.Domain.LZ {

	/// <summary>
	/// Interface for dictionary implementatio used in LZ compression
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ILZ78CodingTable<T> {
		int Count { get; }
		void Insert(byte[] searchKey, T codeWord);
		ILZ78CodingTableItem<T> Search(byte[] searchKey);
	}

	/// <summary>
	/// Presents item in dictionary
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ILZ78CodingTableItem<T> {

		public T CodeWord { get; }

		public ILZ78CodingTableItem(T codeWord) {
			CodeWord = codeWord;
		}
	}
}
