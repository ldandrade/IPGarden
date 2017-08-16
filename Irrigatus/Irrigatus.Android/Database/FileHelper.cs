using Irrigatus.Database;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Irrigatus.Droid.Database.FileHelper))]
namespace Irrigatus.Droid.Database
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            //string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            //return Path.Combine(documentsPath, filename);
            return Path.Combine("/mnt/sdcard", filename);
        }
    }
}