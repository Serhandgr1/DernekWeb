namespace DicleAcademyV2
{
    public class UploadFiles
    {
        public string UploadFile(IFormFile ImageName)
        {
            var extension = Path.GetExtension(ImageName.FileName);
            var newimagename = Guid.NewGuid() + extension;
            var location = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Society/images/", newimagename);
            var stream = new FileStream(location, FileMode.Create);
            ImageName.CopyTo(stream);
            return newimagename;
        }
    }
}
