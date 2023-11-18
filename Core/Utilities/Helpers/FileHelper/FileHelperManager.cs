using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Helpers.FileHelper
{
    public class FileHelperManager:IFileHelper
    {
        public void Delete(string filePath)//Burada ki string filePath, 'CarImageManager'dan gelen dosyamın kaydedildiği adres ve adı 
        {
            if (File.Exists(filePath))//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }

        public string Update(IFormFile file, string filePath, string root)//Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        {
            if (File.Exists(filePath))// Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }

        public string Upload(IFormFile file, string root) // file => yüklenecek olan dosyanın kendisidir 
        {
            if (file.Length > 0) // file.length yüklenecek dosyanın uzunluğu anlamına gelmektedir. Eğer 0dan büyükse bu ife girecektir
            {
                if (!Directory.Exists(root)) // Directory.Exists dosya var mı yok mu diye kontrol eder burda root adında dosya varsa buraya girmez yok ise aşağı satıra iner ve oluşturur
                {
                    //Directory=>System.IO'nın bir class'ı.
                    //CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath* böyle bir şey gönderilidğini görürsünüz. PathConstants clası içerisine girdiğinizde string bir ifadeyle bir dizin adresi var
                    //O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur

                    Directory.CreateDirectory(root); // Root => Oluşturulacak dosyanın yolu
                }
                string extension = Path.GetExtension(file.FileName); //Extension => uzantı demektir. burda girilen dosyanın uzantısının .filename diyerek bir alanını alıyoruz
                string guid = Guid.NewGuid().ToString(); //Dosyaya eşsiz bir isim belirledik
                string filePath = guid + extension;//Dosyanın oluşturduğum adını ve uzantısını yan yana getiriyorum. Mesela metin dosyası ise .txt gibi bu projemizde resim yükyeceğimiz için .jpg olacak uzantılar
                // filePath = dosyanın tam adı (Oluşan guid + dozya uzantısı)

                using (FileStream fileStream = File.Create(root + filePath))//Burada en başta FileStrem class'ının bir örneği oluşturulu.,
                //sonrasında File.Create(root + newPath(filePath))=>Belirtilen yolda bir dosya oluşturur veya üzerine yazar. (root + newPath(filePath))=>Oluşturulacak dosyanın yolu ve adı.
                {
                    file.CopyTo(fileStream);//Kopyalanacak dosyanın kopyalanacağı akışı belirtti. yani yukarıda gelen IFromFile türündeki file dosyasınınnereye kopyalacağını söyledik.
                    fileStream.Flush();//arabellekten siler.
                    return filePath;//burada dosyamızın tam adını geri gönderiyoruz sebebide sql servere dosya eklenirken adı ile eklenmesi için.
                }

            }
            return null;
        }
    }
}
