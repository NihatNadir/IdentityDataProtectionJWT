# IdentityDataProtectionJWT

## Entity Framework Code First yaklaşımını kullanarak veritabanını oluştup bu tabloya kullanıcı kayıtları ekleyiniz.

- Api için Model Validation yapmayı unutmayınız. ( [Required] ve benzeri )
- Kayıt işlemi sırasında Password alanının şifrelenmesi gerekmektedir.

## User sınıfı 
- Id (int, anahtar)
- Email (string, benzersiz)
- Password (string)

## Veritabanı Ayarları
- Entity Framework kullanarak bir DbContext sınıfı oluşturun ve yukarıda tanımladığınız User modelini bu sınıfa ekleyin.

## JWT Oluşturma
### AuthController sınıfı
- Kullanıcının kimliğini doğrulamak için bir Login metodu yazın. Bu metot, Email ve Password almalı ve geçerli bir kullanıcı ise JWT oluşturmalıdır.
- Oluşturulan JWT, kullanıcıya döndürülmelidir.

## JWT Doğrulama
- JWT’nin her istekte doğrulanabilmesi için gerekli ayarları yapın. İsteklerde JWT doğrulaması yapmak üzere bir Authorize niteliği kullanın.
