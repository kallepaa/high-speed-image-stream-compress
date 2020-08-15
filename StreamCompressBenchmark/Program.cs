using BenchmarkDotNet.Running;

namespace StreamCompressBenchmark {
	class Program {
		static void Main(string[] args)
				=> BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
	}
}
