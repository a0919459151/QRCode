var imgDir = $"{Directory.GetCurrentDirectory()}/Images";
string saveQRCodePath = $"{imgDir}/qrCode.jpg";
var ytUrl = "https://www.youtube.com/";
var searchJPG = "YTLogoImg.jpg";
var ytLogoImagePath = FileHelper.GetYTLogoImagePath(imgDir, searchJPG);
var imageData = QRCodeHelper.GenQRCode(ytUrl);
FileHelper.WriteImgFile(imageData, saveQRCodePath, ytLogoImagePath);
