using Microsoft.AspNetCore.Http;

namespace Alcoholest.Input_Models.Whiskey_Input_Model
{
    public class WhiskeyInputModel
    {
        public int? Year { get; set; }

        public string Brand { get; set; }

        public int Quantity { get; set; }

        public IFormFile Image { get; set; }
    }
}
