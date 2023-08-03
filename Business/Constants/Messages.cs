using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string CarAdded = " Car added";
        public static string CarNameInvalid = " Car name is invalid";
        public static string CarPriceInvalid = " Car price is invalid";
        public static string MaintenanceTime = "System in maintenance";
        public static string CarListed = "Cars are listed" ;
        public static string CarDeleted = "Car deleted";
        public static string CarUpdated = "Car updated";
        public static string BrandAdded ="Brand added";
        public static string BrandDeleted = "Brand deleted";
        public static string BrandUpdated = "Brand updated";
        public static string BrandsListed = "Brands listed";
        public static string ColorAdded = " Color added";
        public static string ColorDeleted = " Color deleted";
        public static string ColorUpdated = " Color updated";
        public static string UserAdded = " User added";
        public static string UserDeleted = "User deleted" ;
        public static string UserUpdated= "User updated";
        public static string RentalAdded = "Rental added";
        public static string RentalDeleted = "Rental deleted";
        public static string RentalUpdated = "Rental updated";
        public static string CustomerAdded = "Customer added";
        public static string CustomerDeleted = "Customer deleted";
        public static string CustomerUpdated = "Customer updated";
        public static string RentalNotAdded = "Rental not added";
        public static string CarImageAdded ="Car image added";
        public static string CarImageDeleted ="Car image deleted";
        public static string CarImagesListed = "Car image listed";
        public static string CarImageUpdated = "Car image updated";
        public static string CarImageLimitExpired = "Resim yükleme limiti aşıldı";
        public static string AccessTokenCreated = "Erişim tokeni oluşturuldu";
        public static string UserAlreadyExist = "Kullanıcı adı kullanılmakta";
        public static string UserRegistered="Kullanıcı kaydedildi ";
        public static string UserNotFound= "Kullanıcı bulunmadı";
        public static string PasswordError = "Şifre hatalı";
        public static string SuccessfulLogin =" Başarılı giriş";
        public static string? AuthorizationDenied="Yetkiniz yok";
        public static string RepeatPasswordError ="Tekrar edilen şifre yanlış!";
        public static string PasswordChanged ="Şifre değiştirildi.";
    }
}
