using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constans
{
   public  static class Messages
    {
        public static string CarAdded = "Araba Başarıyla Eklendi";       
        public static string CarDelete = "Araba Başarıyla Silindi";
        public static string CarUpdate = "Araba Başarıyla Güncellendi";
        public static string ColorAdded = "Renk Başarıyla Eklendi";
        public static string ColorDelete = "Renk Başarıyla Silindi";
        public static string ColorUpdate = "Renk Başarıyla Güncellendi";
        public static string BrandAdded = "Marka Başarıyla Eklendi";
        public static string BrandDelete = "Marka Başarıyla Silindi";
        public static string BrandUpdate= "Marka Başarıyla Güncellendi";
        public static string Listed = "Başarıyla Listelendi";
        public static string ErrorMessage = "Hata Mesajı";
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Update = "Güncellendi";
        public static string Imagefull="Resim En Fazla 5 Adet Olabilir";
        public static string ImageNotFound="Arabaya Ait Resim Bulunamadı";
        public static string NotFound="Öğe Bulunamadı";
        public static string UserNotFound="Kullanıcı Bulunamadı";
        public static string UserRegistered="Kullanıcı Kaydedildi";
        public static string PasswordError="Parola Hatası";
        public static string SuccessfulLogin="Giriş Yapıldı";
        public static string UserAlreadyExists="Kayıtlı Kullanıcı";
        public static string AccessTokenCreated="Token";
        public static string AuthorizationDenied="Yetkiniz Yok";
        public static string CarRented="Araba Kiralada";

        public static string PaymentAdded = "Payment Eklendi";
        public static string PaymentDelete = "Payment Silindi";
        public static string PaymentUpdate = "Payment Güncellendi";

        public static string CreditCardAdded="Kredi Kartı Eklendi";
        public static string CreditCardDelete = "Kredi Kartı Silindi";
        public static string CreditCardUpdate = "Kredi Kartı Güncellendi";
        public static string NoEmptyCreditCard = "Geçerli Kredi Kartı Bulunamadı";
        public static string InsBalance = "Yetersiz Bakiye";
        public static string Succes = "Ödeme Gerçekleştirildi";

    }
}
