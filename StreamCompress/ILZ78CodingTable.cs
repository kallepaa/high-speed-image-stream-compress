
namespace StreamCompress {
	public interface ILZ78CodingTable<T> {
		int Count { get; }
		void Insert(byte[] searchKey, T codeWord);
		ILZ78CodingTableItem<T> Search(byte[] searchKey);
	}

	public class ILZ78CodingTableItem<T> {

		public T CodeWord { get; }

		public ILZ78CodingTableItem(T codeWord) {
			CodeWord = codeWord;
		}
	}
}
