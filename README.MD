# Identity Data Protection API

Bu proje, ASP.NET Core ile kullanıcı yönetimi, şifreleme (Data Protection) ve API doğrulama işlemlerini içeren bir uygulamadır. Swagger entegrasyonu ile API dokümantasyonu ve test işlemleri yapılabilir.

## Proje Özellikleri

- **Kullanıcı Yönetimi**: Kullanıcı e-posta ve şifre bilgileriyle kaydedilir.
- **Data Protection**: Şifreler, `Microsoft.AspNetCore.DataProtection` kullanılarak şifrelenir.
- **Entity Framework Core**: Code First yaklaşımı ile veritabanı oluşturulur.
- **Swagger**: API dokümantasyonu ve testi için Swagger UI entegrasyonu.
- **Model Validation**: E-posta ve şifre doğrulaması için `[Required]` ve benzeri validasyonlar kullanılır.

---

## Kullanılan Teknolojiler

- **ASP.NET Core 7**
- **Entity Framework Core**
- **Data Protection**
- **Swagger UI**

---

## Başlangıç

### 1. Gerekli NuGet Paketlerini Yükleyin

Proje dizininde aşağıdaki komutları çalıştırarak gerekli NuGet paketlerini yükleyin:

```bash
dotnet add package Microsoft.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package Microsoft.AspNetCore.DataProtection
dotnet add package Swashbuckle.AspNetCore
```

---

### 2. Veritabanı Ayarları

**appsettings.json** dosyasına aşağıdaki bağlantı dizesini ekleyin:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=IdentityDb;Trusted_Connection=True;"
}
```

---

### 3. Veritabanı Migrasyonları

Entity Framework komutlarını kullanarak veritabanını oluşturun:

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 4. Swagger Entegrasyonu

Swagger entegrasyonu, `Program.cs` dosyasına aşağıdaki kod ile eklenmiştir:

```csharp
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Identity Data Protection API",
        Version = "v1",
        Description = "API for managing users with encryption and validation.",
        Contact = new OpenApiContact
        {
            Name = "Ahmet Emre Arı",
            Email = "info@aemreari.com",
            Url = new Uri("https://www.aemreari.com")
        }
    });
});
```

Proje çalıştırıldıktan sonra Swagger arayüzüne aşağıdaki URL'den erişebilirsiniz:

```
http://localhost:5000/
```

---

## API Kullanımı

### **Kullanıcı Kaydı (Register)**

Endpoint: `POST /api/auth/register`

#### Giriş Parametreleri:

| Alan    | Tip    | Zorunlu | Açıklama               |
|---------|--------|---------|-----------------------|
| Email   | String | Evet    | Kullanıcı e-posta adresi. |
| Password| String | Evet    | Şifre (min. 6 karakter). |

#### Örnek İstek:

```json
{
  "email": "test@example.com",
  "password": "Test@123"
}
```

#### Örnek Yanıt:

```json
{
  "message": "User registered successfully!"
}
```

---

## Proje Yapısı

```plaintext
IdentityDataProtectionApp/
│
├── Controllers/
│   └── AuthController.cs
│
├── Data/
│   └── ApplicationDbContext.cs
│
├── Models/
│   └── User.cs
│   └── RegisterUserDto.cs
│
├── Services/
│   └── EncryptionService.cs
│
├── appsettings.json
│
└── Program.cs
```

---

## Geliştirme ve Test

1. Projeyi çalıştırmak için terminalde şu komutu çalıştırın:
   ```bash
   dotnet run
   ```
2. API'yi test etmek için Swagger arayüzünü kullanabilirsiniz:
   ```
   http://localhost:5000/
   ```

---

## İletişim

- **Geliştirici**: Ahmet Emre Arı
- **E-posta**: [info@aemreari.com](mailto:info@aemreari.com)
- **Web Sitesi**: [www.aemreari.com](https://www.aemreari.com)

---

## Lisans

Bu proje MIT Lisansı ile lisanslanmıştır. Daha fazla bilgi için [LICENSE](LICENSE) dosyasına bakabilirsiniz.
