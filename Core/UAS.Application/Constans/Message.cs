using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAS.Application.Constans
{
    public static class Message
    {
        public readonly static string UserNameOrEmailAndPasswordFailed = "Kullanıcı adı veya şifre hatalı";
        public readonly static string LoginSuccess = "Giriş başarılı";
        public readonly static string LoginFailed = "Giriş başarısız";
        public readonly static string UserCreateFailed = "Kullanıcı ekleme işlemi başarısız";
        public readonly static string UserNotFound = "Kullanıcı bulunamadı";
        public readonly static string UserCreatedIsSuccess = "Kullanıcı oluşturma işlemi başarılı";
        public readonly static string NotificationIsListed = "Bildirim listeleme işlemi başarılı";
        public readonly static string NotificationCreatedIsSuccess = "Bildirim oluşturma işlemi başarılı";
        public readonly static string NotificationCreatedIsFailed = "Aynı text'de bildirim olduğu için, işlem başarısız";
        public readonly static string NotificationRemoveIsSuccesss = "Bildirim silme işlemi başarılı.";
        public readonly static string NotificationRemoveIsFailed = "Veri tabanında böyle bir bildirim olmadığı için, işlem başarısız.";
        public readonly static string NotificationGetByIdIsSuccess = "Bildiri ekrana getirildi, işlem başarılı";
        public readonly static string NotificationGetByIdIsFailed = "Veri tabanında böyle bir bildiri yoktur.";
        public readonly static string NotificationIsUpdatedSuccess = "Bildiri güncelleme işlemi başarılı";
        public readonly static string NotificationIsUpdatedFail = "Veri tabanında böyle bir bildirim olmadığı için, işlem başarısız.";
        public readonly static string GetAllUserSuccess = "Bütün kullanıcılar başarıyla listelendi";
    }
}
