
namespace _Scripts.Interfaces
{
    public interface ILayzLogger
    {
        public void Log(string message);
        public void LogWarning(string message);
        public void LogError(string message);
    }
}