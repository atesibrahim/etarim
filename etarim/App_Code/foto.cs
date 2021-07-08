using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Drawing;


/// <summary>
/// Summary description for foto
/// </summary>
public class foto
{


    public void Kaydet(HttpPostedFile Dosya, int genislik, int yukseklik, string yol)
    {
        Bitmap resim = new Bitmap(Dosya.InputStream);
        //resmin boyutu bizim vermiş olduğumuz genişlik veya yükseklikten büyükse boyutlandırma yapıyoruz.
        if (resim.Width > genislik || resim.Height > yukseklik)
        {
            Size ebatlar = new Size(resim.Width, resim.Height);
            //resmin genişlik ve yükseklik oranını alıyoruz.
            double oran = ((double)resim.Width / (double)resim.Height);
            if (resim.Width > genislik && genislik > 0)
            {
                //burada genişlik parametresi 0 olarak verilmişse boyutlandırma yapılmayacak. Yani resim orijinal genişliğinde kalacak.
                ebatlar.Width = genislik;
                ebatlar.Height = (int)((double)genislik / oran);
            }
            if (ebatlar.Height > yukseklik && yukseklik > 0)
            {//burada yükseklik parametresi 0 olarak verilmişse boyutlandırma yapılmayacak. Yani resim orijinal yükseklikte kalacak.
                ebatlar.Height = yukseklik;
                ebatlar.Width = (int)((double)yukseklik * oran);
            }
            resim = new Bitmap(resim, ebatlar);
        }


        //dosyanın türüne göre de kayıt işlemini yaptırıyoruz.
        if (Dosya.ContentType == "image/jpeg" || Dosya.ContentType == "image/pjpeg")
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Jpeg);
        else if (Dosya.ContentType == "image/gif")
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Gif);
        else if (Dosya.ContentType == "image/png" || Dosya.ContentType == "image/x-png")
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Png);
        resim.Dispose();
    
}
    public void Kaydet(HttpPostedFile Dosya, string yol)
    {
        Bitmap resim = new Bitmap(Dosya.InputStream);
        //resmin boyutu bizim vermiş olduğumuz genişlik veya yükseklikten büyükse boyutlandırma yapıyoruz.
        //dosyanın türüne göre de kayıt işlemini yaptırıyoruz.
        if (Dosya.ContentType == "image/jpeg" || Dosya.ContentType == "image/pjpeg")
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Jpeg);
        else if (Dosya.ContentType == "image/gif")
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Gif);
        else if (Dosya.ContentType == "image/png" || Dosya.ContentType == "image/x-png")
            resim.Save(yol, System.Drawing.Imaging.ImageFormat.Png);
        resim.Dispose();

    }

}