namespace UniqueCharFinder
{
	internal class Program
	{
		static void Main()
		{
			string inputText = @"The Tao gave birth to machine language.  Machine language gave birth
                            to the assembler.
                            The assembler gave birth to the compiler.  Now there are ten thousand
                            languages.
                            Each language has its purpose, however humble.  Each language
                            expresses the Yin and Yang of software.  Each language has its place within
                            the Tao.
                            But do not program in COBOL if you can avoid it.
                            -- Geoffrey James, ""The Tao of Programming""";

			string inputText2 = @"C makes it easy for you to shoot yourself in the foot. C++ makes that harder, but when you do, it blows away your whole leg. (с) Bjarne Stroustrup";

			char result = FindFirstUniqueCharacter(inputText2);

			Console.WriteLine(result == '\0' ? "No unique character" : $"The first unique character is: {result}");
		}

		static char FindFirstUniqueCharacter(string text)
		{
			var uniqueChars = text
				.Where(c => char.IsLetter(c))
				.GroupBy(c => c, (key, group) => new { Character = key, Count = group.Count() })
				.Where(x => x.Count == 1)
				.Select(x => x.Character);

			return uniqueChars.FirstOrDefault();
		}
	}
}