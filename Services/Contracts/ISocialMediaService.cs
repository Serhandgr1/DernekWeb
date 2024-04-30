using Entities.Models;
using Entities.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contracts
{
    public interface ISocialMediaService
    {
        IEnumerable<SocialMediaDto> GetAllSocialMedia();
        SocialMediaDto GetByIdSocialMedia(int id);
        SocialMediaDto CreateSocialMedia(SocialMediaDto socialMediaDto);
        void UpdateSocialMedia(SocialMediaDto socialMediaDto);
        void DeleteSocialMedia(int id);
    }
}
