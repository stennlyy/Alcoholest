using Alcoholest.Input_Models.Whiskey_Input_Model;
using System.Threading.Tasks;

namespace Alcoholest.Services.AlcoholServices
{
    public interface IWhiskeysService
    {
        public Task AddWhiskeyAsync(WhiskeyInputModel whiskeyInputModel);
    }
}
