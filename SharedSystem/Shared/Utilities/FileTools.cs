using FluentResults;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Drawing;
using System.Drawing.Imaging;


namespace Utilities;

public static class FileTools
{
    static FileTools()
    {
    }

    // **************************************************
    // V 0.1
    public static byte[] Base64ToByteArray(this string? base64)
    {
        if (string.IsNullOrEmpty(base64) == true)
        {
            return Array.Empty<byte>();
        }

        byte[] result = Convert.FromBase64String(base64);

        return result;
    }

    // V 0.2
    //public static byte[] Base64ToByteArray(this string? base64)
    //{
    //	byte[] result = Convert.FromBase64String(base64 ?? string.Empty);

    //	return result;
    //}

    // V 0.3
    // Not Recommanded !
    //public static byte[] Base64ToByteArray(this string? base64)
    //	=> string.IsNullOrEmpty(base64) ? Array.Empty<byte>() : Convert.FromBase64String(base64);

    // V 0.4
    // Not Recommanded !
    //public static byte[] Base64ToByteArray(this string? base64)
    //	=> Convert.FromBase64String(base64 ?? string.Empty);
    // **************************************************

    // **************************************************
    public static void SaveByteArrayToFile(this byte[] data, string filePath)
    {
        using var stream = File.Create(filePath);
        stream.Write(data, 0, data.Length);
    }
    // **************************************************

    // **************************************************
    public static byte[] IFormFileToByte(this IFormFile file)
    {
        var buffer = new byte[file.Length];

        file.OpenReadStream().Read(buffer: buffer, 0, buffer.Length);

        return buffer;
    }
    // **************************************************

    // **************************************************
    public static byte[] FileToByte(string path)
    {
        byte[] arrayByte = File.ReadAllBytes(path);

        return arrayByte;
    }
    // **************************************************

    // **************************************************
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility",
        Justification = "<Pending>")]
    public static Image ByteArrayToImage(this byte[] data)
    {
        Image image;
        using (MemoryStream ms = new MemoryStream(data))
        {
            image = Image.FromStream(ms);
        }

        return image;
    }
    // **************************************************

    // **************************************************
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility",
        Justification = "<Pending>")]
    public static string SaveImageInDirectory
        (this Image image, string directoryPath, string? fileName = null)
    {
        var name = $"{Guid.NewGuid()}.Jpeg";

        if (string.IsNullOrEmpty(fileName) == false)
        {
            name = fileName;
        }

        var path = Path.Combine(directoryPath, name);
        try
        {
            if (Directory.Exists(directoryPath) == false)
            {
                Directory.CreateDirectory(directoryPath);
            }

            image.Save(path, ImageFormat.Jpeg);

            return name;
        }
        catch (Exception)
        {
            // Try HU's method: Convert it to a Bitmap first
            image = new Bitmap(image);

            // This is always successful
            image.Save(path, ImageFormat.Jpeg);

            return name;
        }
    }
    // **************************************************

    // **************************************************
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Interoperability", "CA1416:Validate platform compatibility",
        Justification = "<Pending>")]
    public static (byte[] byteImage, byte[] byteThumbnail)
        ChangeFormatImageToJpegWithThumbnail(this byte[] data)
    {
        MemoryStream stream = new(data);

        Image image = Image.FromStream(stream);

        Bitmap bitmapImage = new(image);

        int widthThumbnail = image.Width / 3;
        int heightThumbnail = image.Height / 3;

        Bitmap thumbnailResult =
            new(image, widthThumbnail, heightThumbnail);

        MemoryStream saveImageStream = new();
        MemoryStream saveThumbnailStream = new();


        bitmapImage.Save(saveImageStream, ImageFormat.Jpeg);
        thumbnailResult.Save(saveThumbnailStream, ImageFormat.Jpeg);

        byte[] resultImage = saveImageStream.ToArray();
        byte[] resultThumbnail = saveThumbnailStream.ToArray();

        return (resultImage, resultThumbnail);
    }
    // **************************************************

    // **************************************************
    public async static Task<FluentResults.Result<string>>
        SaveIFormFileInDirAsync(this IFormFile file, string path)
    {
        if (file is null)
        {
            throw new ArgumentNullException(nameof(file));
        }

        if (path is null)
        {
            throw new ArgumentNullException(nameof(path));
        }

        var result = new FluentResults.Result<string>();

        if (file.Length <= 0)
        {
            return result.WithError
                (errorMessage: Resources.Messages.ErroZiroByteFile);
        }

        if (string.IsNullOrEmpty(path) == true)
        {
            return result.WithError
                (errorMessage: Resources.Messages.ErrorPathFile);
        }

        string ext = Path.GetExtension(file.FileName).ToLower();

        if (FileConstant.ExtensionsImages.Contains(ext) == true)
        {
            if (file.IsValidFileSize(FileConstant.MaxSizeImage) == false)
            {
                return result.WithError
                (errorMessage: string.Format
                (Resources.Messages.ErrorSizeFile,
                    Resources.DataDictionary.Image, FileConstant.MaxSizeImage));
            }
        }
        else if (FileConstant.ExtensionsPodcast.Contains(ext) == true)
        {
            if (file.IsValidFileSize(FileConstant.MaxSizePodcast) == false)
            {
                return result.WithError
                (errorMessage: string.Format
                (Resources.Messages.ErrorSizeFile,
                    Resources.DataDictionary.Podcast, FileConstant.MaxSizePodcast));
            }
        }
        else if (FileConstant.ExtensionsVideo.Contains(ext) == true)
        {
            if (file.IsValidFileSize(FileConstant.MaxSizeVideo) == false)
            {
                return result.WithError
                (errorMessage: string.Format
                (Resources.Messages.ErrorSizeFile,
                    Resources.DataDictionary.Video, FileConstant.MaxSizeVideo));
            }
        }
        else if (FileConstant.ExtensionsDocument.Contains(ext) == true)
        {
            if (file.IsValidFileSize(FileConstant.MaxSizeDocument) == false)
            {
                return result.WithError
                (errorMessage: string.Format
                (Resources.Messages.ErrorSizeFile,
                    Resources.DataDictionary.Document, FileConstant.MaxSizeDocument));
            }
        }
        else if (FileConstant.ExtensionsApp.Contains(ext) == true)
        {
            if (file.IsValidFileSize(FileConstant.MaxSizeApp) == false)
            {
                return result.WithError
                (errorMessage: string.Format
                (Resources.Messages.ErrorSizeFile,
                    Resources.DataDictionary.Document, FileConstant.ExtensionsApp));
            }
        }
        else
        {
            //return result.WithError
            //	(errorMessage: string.Format
            //		(Resources.Messages.ErrorSizeFile,
            //			Resources.DataDictionary.Video, FileConstant.MaxSizeVideo));

            return result.WithError
                (errorMessage: Resources.Messages.ErroZiroByteFile);
        }

        string fileName = Guid.NewGuid().ToString() + ext;

        using (FileStream fileStream =
               new(Path.Combine(path, fileName), FileMode.Create))
        {
            await file.CopyToAsync(fileStream);

            result.WithValue(fileName);
        }

        return result;
    }
    // **************************************************

    // **************************************************
    public async static Task<Result<string>> SaveBase64InDirAsync(
        string base64Data, string fileName, string path)
    {
        if (string.IsNullOrWhiteSpace(base64Data))
        {
            throw new ArgumentNullException(nameof(base64Data));
        }

        if (string.IsNullOrWhiteSpace(fileName))
        {
            throw new ArgumentNullException(nameof(fileName));
        }

        if (string.IsNullOrWhiteSpace(path))
        {
            throw new ArgumentNullException(nameof(path));
        }

        var result = new Result<string>();

        byte[] fileBytes;

        try
        {
            // تبدیل رشته Base64 به آرایه بایت
            fileBytes = Convert.FromBase64String(base64Data);
        }
        catch (FormatException)
        {
            return result.WithError("Invalid Base64 string.");
        }

        if (fileBytes.Length <= 0)
        {
            return result.WithError(Resources.Messages.ErroZiroByteFile);
        }

        string? ext = Path.GetExtension(fileName)?.ToLower();

        // اعتبارسنجی نوع فایل
        if (FileConstant.ExtensionsImages.Contains(ext))
        {
            if (fileBytes.Length > FileConstant.MaxSizeImage * 1024 * 1024)
            {
                return result.WithError(
                    string.Format(Resources.Messages.ErrorSizeFile,
                        Resources.DataDictionary.Image, FileConstant.MaxSizeImage));
            }
        }
        else if (FileConstant.ExtensionsPodcast.Contains(ext))
        {
            if (fileBytes.Length > FileConstant.MaxSizePodcast * 1024 * 1024)
            {
                return result.WithError(
                    string.Format(Resources.Messages.ErrorSizeFile,
                        Resources.DataDictionary.Podcast, FileConstant.MaxSizePodcast));
            }
        }
        else if (FileConstant.ExtensionsVideo.Contains(ext))
        {
            if (fileBytes.Length > FileConstant.MaxSizeVideo * 1024 * 1024)
            {
                return result.WithError(
                    string.Format(Resources.Messages.ErrorSizeFile,
                        Resources.DataDictionary.Video, FileConstant.MaxSizeVideo));
            }
        }
        else if (FileConstant.ExtensionsDocument.Contains(ext))
        {
            if (fileBytes.Length > FileConstant.MaxSizeDocument * 1024 * 1024)
            {
                return result.WithError(
                    string.Format(Resources.Messages.ErrorSizeFile,
                        Resources.DataDictionary.Document, FileConstant.MaxSizeDocument));
            }
        }
        else
        {
            return result.WithError("Invalid Base64 string.");
        }

        string newFileName = Guid.NewGuid().ToString() + ext;

        try
        {
            string fullPath = Path.Combine(path, newFileName);

            // ذخیره فایل در مسیر مشخص شده
            await File.WriteAllBytesAsync(fullPath, fileBytes);

            result = result.WithValue(newFileName);
        }
        catch (Exception ex)
        {
            return result.WithError($"Error saving file: {ex.Message}");
        }

        return result;
    }
    // **************************************************

    // **************************************************
    public static (string NameImage, string NameImageThumbnail)
        IFormFileImageToDirectoryWithThumbnail(this IFormFile file, string directoryPath)
    {
        byte[] imageBytes = file.IFormFileToByte();

        (byte[] byteImage, byte[] byteThumbnail) =
            imageBytes.ChangeFormatImageToJpegWithThumbnail();

        Image img = byteImage.ByteArrayToImage();
        string nameImg = img.SaveImageInDirectory(directoryPath);

        Image imgTh = byteThumbnail.ByteArrayToImage();
        string nameImgTh = imgTh.SaveImageInDirectory(directoryPath);

        return (nameImg, nameImgTh);
    }
    // **************************************************

    // **************************************************
    // public static IFormFile ConvertByteArrayToFormFile(
    //     this byte[] fileBytes,
    //     string fileName,
    //     string contentType = "application/octet-stream")
    // {
    //     var stream = new MemoryStream(fileBytes);
    //
    //     var result = new FormFile(stream, 0, fileBytes.Length, "file", fileName)
    //     {
    //         Headers = new HeaderDictionary(),
    //         ContentType = contentType
    //     };
    //     
    //     return result;
    // }


    public static IFormFile ConvertByteArrayToFormFile(
        this byte[] fileBytes,
        string fileName,
        string contentType = "application/octet-stream")
    {
        var stream = new MemoryStream(fileBytes);

        // توجه داشته باشید که کلاس FormFile همچنان در فضای نام Microsoft.AspNetCore.Http وجود دارد
        var result = new FormFile(stream, 0, fileBytes.Length, "file", fileName)
        {
            Headers = new HeaderDictionary(),
            ContentType = contentType
        };

        return result;
    }
    // **************************************************
}