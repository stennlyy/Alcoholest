using Alcoholest.Data;
using Alcoholest.Input_Models.Whiskey_Input_Model;
using Alcoholest.Models;
using Alcoholest.Services.AlcoholServices;
using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Alcoholest.Services.AlcoholsService
{
    public class WhiskeysService : IWhiskeysService
    {
        private readonly ApplicationDbContext context;
        private readonly IWebHostEnvironment webHostEnvironment;

        public WhiskeysService(
            ApplicationDbContext context,
            IWebHostEnvironment webHostEnvironment)
        {
            this.context = context;
            this.webHostEnvironment = webHostEnvironment;
        }

        public async Task AddWhiskeyAsync(WhiskeyInputModel whiskeyInputModel)
        {
            var whiskey = this.context
                .Whiskeys
                .Where(x => x.Brand == whiskeyInputModel.Brand)
                .FirstOrDefault();
                
            if(whiskey == null)
            {
                string image = await this.UploadImageAsync(whiskeyInputModel);

                var whiskeyToAdd = new Whiskey()
                {
                    Image = image,
                    Brand = whiskeyInputModel.Brand,
                    Year = whiskeyInputModel.Year,
                    Quantity = whiskeyInputModel.Quantity,
                };

                await this.context.Whiskeys.AddAsync(whiskeyToAdd);
                await this.context.SaveChangesAsync();
            }
        }

        private async Task<string> UploadImageAsync(WhiskeyInputModel whiskeyInputModel)
        {
            string fileName = null;

            if (whiskeyInputModel.Image != null)
            {
                string uploadDirectory = Path.Combine(this.webHostEnvironment.WebRootPath, "images", "whiskeyImages");

                fileName = Guid.NewGuid().ToString() + "-" + whiskeyInputModel.Image.FileName;

                string filePath = Path.Combine(uploadDirectory, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await whiskeyInputModel.Image.CopyToAsync(fileStream);
                }
            }

            return fileName;
        }
    }
}
