
namespace StreamCompress.Domain.LZ {

	/// <summary>
	/// Interface for dictionary implementatio used in LZ compression
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public interface ILZ78CodingTable<T> {
		/// <summary>
		/// Items count in dictionary
		/// </summary>
		int Count { get; }
		/// <summary>
		/// Insert new item to dictionary
		/// </summary>
		/// <param name="searchKey">Item key</param>
		/// <param name="codeWord">Item value</param>
		void Insert(byte[] searchKey, T codeWord);
		/// <summary>
		/// Search item from disctionary
		/// </summary>
		/// <param name="searchKey">Search key</param>
		/// <returns>Existing item or null</returns>
		ILZ78CodingTableItem<T> Search(byte[] searchKey);
	}

	/// <summary>
	/// Presents item in dictionary
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public class ILZ78CodingTableItem<T> {

		/// <summary>
		/// Item code word
		/// </summary>
		public T CodeWord { get; }

		/// <summary>
		/// Item constructor
		/// </summary>
		/// <param name="codeWord">Item code word</param>
		public ILZ78CodingTableItem(T codeWord) {
			CodeWord = codeWord;
		}
	}
}
