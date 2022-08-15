using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IStrategy
    {
        void Config (bool needReturn, object data);
        object ReturnFromConfig (object data);
        
    }
}