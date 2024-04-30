using Microsoft.AspNetCore.Mvc;

namespace DicleAcademyV2
{
    public class FileManagerAsycn
    {
        public async Task<string> PostFileAsycn(IFormFile formFile)
        {
            try
            {
                if (formFile != null)
                {
                    string urlReuest = "https://localhost:7191/" + "File/FileUpload";
                    using var content = new MultipartFormDataContent();
                    content.Add(new StreamContent(formFile.OpenReadStream()), "images", formFile.FileName);
                    HttpResponseMessage responce = await GenerateClient.Client.PostAsync(urlReuest, content);
                    string data = await responce.Content.ReadAsStringAsync();
                    return data;
                }
                else return "null";

            }
            catch (Exception ex) { return "null"; }

        }
        public async Task<string> UpdateFileAsycn(string? images, IFormFile formFile)
        {
            try
            {

                if (formFile != null)
                {
                    string urlReuest = "https://localhost:7191/" + "File/FileUpdate";
                    using var content = new MultipartFormDataContent();
                    content.Add(new StringContent(images), "images");
                    content.Add(new StreamContent(formFile.OpenReadStream()), "file", formFile.FileName);
                    HttpResponseMessage responce = await GenerateClient.Client.PostAsync(urlReuest, content);
                    string data = await responce.Content.ReadAsStringAsync();
                    return data;
                }
                else return "null";

            }
            catch (Exception e)
            {
                return "null";
            }
        }
        public async Task DeleteFileAsycn(string images)
        {
            try
            {
                if (!string.IsNullOrEmpty(images))
                {
                    string urlReuest = "https://localhost:7191/" + "File/FileDelete";
                    using var content = new MultipartFormDataContent();
                    content.Add(new StringContent(images), "images");
                    HttpResponseMessage responce = await GenerateClient.Client.PostAsync(urlReuest, content);
                }
 
            }
            catch (Exception ex)
            {
               
            }
        }
    }
}
