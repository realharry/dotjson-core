using System.IO;
using System.Threading.Tasks;


namespace HoloJson.Core
{
	public interface LiteJsonParser
	{
		Task<object> ParseAsync(string jsonStr);
        Task<object> ParseAsync(TextReader reader);
        // Task<object> ParseAsync(IStorageFile jsonFile);
    }
}
