
using Entities.ModelsDto;
using Microsoft.IdentityModel.Protocols.WSFederation.Metadata;
using System;

namespace DicleAcademyV2
{
    public class GenericRequests<T>
    {

        public async Task<List<T>> GetHttpRequest(string url)
        {
            string ProductCategoryUrl = GenerateClient.Client.BaseAddress + url;
            HttpResponseMessage ProductCategoryResponce = await GenerateClient.Client.GetAsync($"{ProductCategoryUrl}");
            switch (((int)ProductCategoryResponce.StatusCode)) 
            {
               case 401:
                    bool again = await Refresh();
                    if (again)
                    {
                        var agn = await GetHttpRequest(url);
                        return agn;
                    }
                    else {
                        return new List<T>();
                    }
                        
                case 200:
                        List<T> ProductCategoryApi = await ProductCategoryResponce.Content.ReadFromJsonAsync<List<T>>();
                        return ProductCategoryApi;
                default: return new List<T>();
            }
        }
        public async Task<string> PostRequestGeneric(string Url, T entity)
        {
            string url = GenerateClient.Client.BaseAddress + Url;
            var data = await GenerateClient.Client.PostAsJsonAsync(url, entity);

            switch (((int)data.StatusCode)) 
            {
                case 200: return "Başarılı";
                case 401:
                    bool again = await Refresh();
                    if (again)
                    {
                        var agn = await PostRequestGeneric(url, entity);
                        return agn;
                    }
                    else {
                        return "Başarısız";
                    }
                        
                default: return "Başarısız";
            }
        }
    
        public async Task<string> UpdateRequestGeneric(string url, T entity)
        {
            string urlUpdate = GenerateClient.Client.BaseAddress + url;
            var data = await GenerateClient.Client.PutAsJsonAsync(urlUpdate, entity);

            switch (((int)data.StatusCode)) 
            {
                case 200: return "UpdateBaşarılı";
                case 401:
                    bool again = await Refresh();
                    if (again)
                    {
                        var agn = await UpdateRequestGeneric(url, entity);
                        return agn;
                    }
                    else {
                        return "Başarısız";
                    }
                         
                default: return "Başarısız";
            
                }
        }
        public  async Task<T> GetByIdGeneric(string url , int id)
        {
            string urlReuest = GenerateClient.Client.BaseAddress + url;
            HttpResponseMessage responce = await GenerateClient.Client.GetAsync($"{urlReuest}?id={id}");
            switch (((int)responce.StatusCode)) 
            {
                case 200:
                    T dto = await responce.Content.ReadFromJsonAsync<T>();
                    return dto; ;
                case 401:
                    bool again = await Refresh();
                    if (again)
                    {
                        var agn = await GetByIdGeneric(url, id);
                        return agn;
                    }
                    else {
                        T obj = new List<T>().First();
                        return obj;
                    }
                   
                   
                default:
                    T objd = new List<T>().First();
                    return objd; ;
            }
        }
        public async Task<bool> Refresh()
        {
            var urlRef = GenerateClient.Client.BaseAddress + "TokenCheck/RefteshToken";
            TokenDto tokenDto = new TokenDto();
            tokenDto.RefreshToken = ClientTokenDto.RefreshToken;
            tokenDto.AccessToken = ClientTokenDto.AccessToken;
            var token = await GenerateClient.Client.PostAsJsonAsync(urlRef, tokenDto);
            if (token.IsSuccessStatusCode)
            {
                TokenDto newToken = await token.Content.ReadFromJsonAsync<TokenDto>();
                GenerateClient.Client.DefaultRequestHeaders.Remove("Authorization");
                GenerateClient.Client.DefaultRequestHeaders.Add("Authorization", "Bearer " + newToken.AccessToken);
                ClientTokenDto.AccessToken = newToken.AccessToken;
                ClientTokenDto.RefreshToken = newToken.RefreshToken;
                return true;
            }
            return false;
        }
    }
}
