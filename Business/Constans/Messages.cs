using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constans
{
    public static class Messages
    {
        public static string CarAdded = "Araba Eklendi";
        public static string CarDeleted = "Araba Silindi";
        public static string CarUpdated = "Araba Güncellendi";
        public static string AddError = "Ekleme Başarısız Oldu";
        public static string CarsListed = "Arabalar listelendi";
        public static string CarDetails = "Araba Detayları Listelendi";
        public static string CarDailyPrice = "Günlük fiyat 0' dan küçük olamaz";
        public static string CarNameError = "Araba ismi minimum 2 karakter olmalıdır.";

        public static string BrandAdded = "Marka Eklendi";
        public static string BrandDeleted = "Marka Silindi";
        public static string BrandUpdated = "Marka Güncellendi";
        public static string BrandListed = "Markalar Listelendi";
        public static string BrandError = "Marka Eklenemedi";
        public static string BrandUpdateError = "Marka Güncellenemedi";
        public static string BrandNameNull = "Marka ismi boş olamaz";

        public static string ColorAdded = "Renk Eklendi";
        public static string ColorDeleted = "Renk Silindi";
        public static string ColorUpdated = "Renk Güncellendi";
        public static string ColorListed = "Renkler Listelendi";
        public static string ColorAddError = "Renk Eklenemedi";

        internal static string UserAdded = "Kullanıcı başarıyla sisteme eklendi.";
        internal static string UserDeleted = "Kullanıcı başarıyla sistemden silindi.";
        internal static string UsersListed = "Kullanıcı başarıyla listelendi.";
        internal static string UserUpdated = "Kullanıcı bilgileri başarıyla güncellendi.";

        internal static string RentalAdded = "Kiralama işlemi başarıyla gerçekleşti.";
        internal static string RentalDeleted = "Kiralama işlemi başarıyla silindi.";
        internal static string RentalUpdated = "Kiralama işlemi başarıyla güncellendi.";
        internal static string RentalUpdateError = "Kiralama Güncellenemedi.";
        internal static string RentalsListed = "Kiralamalar başarıyla listelendi.";
        internal static string RentalError = "Bu araç şuan kirada.";

        public static string MaintenanceTime = "Sistem Şuan Bakımda.";
        public static string Added = "Eklendi";
        public static string Deleted = "Silindi";
        public static string Updated = "Güncellendi";
        public static string Rented = "Kiralandı";
        public static string InActiveUse = "Araba Kullanımda";
        internal static string ImageLimitOver = "Her Arabanın en fazla 5 Fotoğrafı Olabilir";
        internal static string ImageAdded = "Fotoğraf Yüklendi";
        internal static string CarImageUpdated = "Fotoğraf Güncellendi";
        internal static string CarImageNotFound = "Fotoğraf Bulunamadı";
        internal static string CarImageDeleted = "Fotoğraf Silindi";
        public static string ReturnDateInvalid = "Kiralama başarısız! Araç müsait değil.";
    }
}
