<h1 align="center">🛒 BerkayShop - Modern Mikroservis E-Ticaret Platformu</h1>

<p align="center">
  ASP.NET Core, Ocelot API Gateway, IdentityServer4, RabbitMQ ve gRPC teknolojileriyle geliştirilmiş,<br/>
  gerçek dünya senaryolarını yansıtan kapsamlı bir mikroservis e-ticaret sistemi
</p>

<p align="center">
  <img src="https://img.shields.io/badge/.NET-8.0-512BD4?style=flat-square&logo=dotnet&logoColor=white"/>
  <img src="https://img.shields.io/badge/C%23-239120?style=flat-square&logo=csharp&logoColor=white"/>
  <img src="https://img.shields.io/badge/Ocelot-Gateway-0078D7?style=flat-square"/>
  <img src="https://img.shields.io/badge/IdentityServer-Auth-FF6600?style=flat-square"/>
  <img src="https://img.shields.io/badge/Redis-DC382D?style=flat-square&logo=redis&logoColor=white"/>
  <img src="https://img.shields.io/badge/RabbitMQ-FF6600?style=flat-square&logo=rabbitmq&logoColor=white"/>
  <img src="https://img.shields.io/badge/Docker-2496ED?style=flat-square&logo=docker&logoColor=white"/>
</p>

---

## 🧾 Proje Tanıtımı

**BerkayShop**, modern yazılım mimarileri kullanılarak geliştirilmiş, ölçeklenebilir ve modüler bir e-ticaret platformu altyapısıdır. Proje, mikroservisler arası iletişim, merkezi kimlik doğrulama ve API yönetimi gibi karmaşık süreçleri yönetmek üzere tasarlanmıştır.

Bu proje sayesinde:

**Müşteriler:**
- Ürün kataloğunu kolayca inceleyebilir ve listeleyebilir
- Seçtikleri ürünleri sepete ekleyip yönetebilir
- Kupon/indirim kodlarını sepetlerine uygulayabilir
- Online sipariş oluşturabilir ve sipariş geçmişini takip edebilir
- Güvenli kimlik doğrulama ile hesaplarını yönetebilir

**Geliştiriciler için:**
- Mikroservis mimarisinin pratik uygulamasını inceleyebilir
- CQRS, MediatR, Repository Pattern, DDD gibi desenleri görebilir
- Ocelot Gateway, IdentityServer, RabbitMQ, gRPC entegrasyonlarını öğrenebilir
- Polyglot Persistence (çoklu veritabanı) yaklaşımını gözlemleyebilir

---

## 🚀 Kullanılan Teknolojiler

| Katman | Teknolojiler |
|--------|-------------|
| **Backend** | `ASP.NET Core 8.0 Web API`, `C#`, `Entity Framework Core`, `Dapper`, `MediatR`, `FluentValidation`, `AutoMapper` |
| **Gateway** | `Ocelot`, `JWT Token Doğrulama`, `Rate Limiting`, `Load Balancing` |
| **Kimlik** | `IdentityServer4 / Duende`, `OAuth 2.0`, `OpenID Connect`, `JWT` |
| **Mesajlaşma** | `RabbitMQ`, `MassTransit`, `Event-Driven Architecture` |
| **Cache** | `Redis`, `StackExchange.Redis` |
| **Veritabanı** | `MongoDB`, `Redis`, `PostgreSQL`, `SQL Server` |
| **İletişim** | `gRPC`, `HTTP/REST`, `Protobuf` |
| **Frontend** | `ASP.NET Core MVC`, `HTML5`, `CSS3`, `SCSS`, `JavaScript`, `Bootstrap` |
| **Mimari** | `Mikroservis`, `CQRS`, `DDD`, `Repository Pattern`, `Clean Architecture` |
| **Araçlar** | `Docker`, `Postman`, `Swagger` |

---

## 🧱 Proje Mimarisi

<img width="827" height="907" alt="image" src="https://github.com/user-attachments/assets/c46c58ac-ccbf-4fd2-9aca-cf6cb07c9e57" />


---

## 💾 Servis - Veritabanı Eşleşmeleri

Proje, **Polyglot Persistence** yaklaşımını benimseyerek her servise en uygun veritabanı teknolojisini kullanır.

| Servis | Veritabanı | Neden? |
|--------|-----------|--------|
| **Catalog Service** | MongoDB | Esnek şema, ürün verileri için uygun |
| **Basket Service** | Redis | Geçici veri, hızlı okuma/yazma |
| **Discount Service** | PostgreSQL | İlişkisel kupon verileri |
| **Order Service** | SQL Server | ACID uyumlu sipariş kayıtları |
| **Identity Server** | SQL Server | Kullanıcı ve rol yönetimi |

---

## ✨ Temel Özellikler

### 🎯 Kullanıcı Tarafı
- 🛍️ **Ürün Listeleme** — Kategori ve filtre desteğiyle tüm ürün kataloğu
- 🛒 **Sepet Yönetimi** — Ürün ekleme, çıkarma ve güncelleme
- 💸 **Kupon Sistemi** — Sepete indirim kodu uygulama (gRPC ile anlık doğrulama)
- 📦 **Sipariş Akışı** — Güvenli checkout ve sipariş geçmişi
- 🔐 **Kimlik Doğrulama** — OAuth 2.0 ile güvenli giriş/kayıt

### 🛡️ Teknik Özellikler
- 🌐 **API Gateway** — Tüm trafik tek noktadan yönetilir
- 📨 **Event-Driven** — Sepet → Sipariş geçişi RabbitMQ ile asenkron
- ⚡ **gRPC İletişim** — Basket → Discount arası düşük gecikmeli iletişim
- 🔑 **JWT Auth** — Token tabanlı güvenlik her serviste
- 🐳 **Docker Ready** — Tüm bağımlılıklar container ile çalışır

---


## 🖥️ Servis Detayları ve Sayfalar

---

## 🔐 Kimlik Doğrulama — Identity Server

### 1. Giriş Yap (Login)

**URL:** `http://localhost:5001/Account/Login`

**Açıklama:** Tüm platformun kimlik doğrulama merkezidir. Kullanıcılar bu ekran üzerinden sisteme giriş yapar. Başarılı girişin ardından JWT token üretilir ve kullanıcı uygulamaya yönlendirilir.

**Form Alanları:**
- Kullanıcı Adı
- Şifre
- Beni Hatırla

**Kimlik Doğrulama Akışı:**
- ASP.NET Identity ile kullanıcı doğrulama
- OAuth 2.0 Authorization Code Flow
- JWT Access Token + Refresh Token üretimi

<!-- Ekran görüntüsü: Identity Server Login Sayfası -->
<img width="1918" height="946" alt="image" src="https://github.com/user-attachments/assets/b3eaf164-ceed-442a-969b-f020343ca522" />


---

### 2. Kayıt Ol (Register)

**URL:** `http://localhost:5001/Account/Register`

**Açıklama:** Yeni kullanıcıların sisteme kayıt olmasını sağlar. Kayıt sonrasında kullanıcı doğrudan giriş sayfasına yönlendirilir.

**Form Alanları:**
- Ad, Soyad
- Kullanıcı Adı
- E-posta
- Şifre / Şifre Tekrar

<!-- Ekran görüntüsü: Identity Server Register Sayfası -->
<img width="1920" height="951" alt="image" src="https://github.com/user-attachments/assets/5ce6de33-11c0-475b-a65e-e6b5ed4a69cb" />

---

## 📄 Kullanıcı Sayfaları (Frontend)

---

### 3. Ana Sayfa (Home)

**URL:** `http://localhost:5000`

**Açıklama:** Uygulamanın vitrin sayfasıdır. Kullanıcıyı karşılayan ilk ekrandır.

**Bileşenler:**
- 🎯 Hero Banner — Karşılama görseli ve CTA butonları
- 🛍️ Öne Çıkan Ürünler — Katalogdan en güncel ürünler
- 📦 Kategori Özeti — Ürün kategorilerine hızlı erişim
- ℹ️ Platform Hakkında — Kısa tanıtım bölümü
- 📊 İstatistikler — Toplam ürün, kategori, müşteri sayısı

<!-- Ekran görüntüsü: Ana Sayfa -->
<img width="1920" height="912" alt="image" src="https://github.com/user-attachments/assets/fdae9a8d-43c5-49e2-9f94-0d01d3acb9c0" />
<img width="1920" height="683" alt="image" src="https://github.com/user-attachments/assets/035c433e-08d1-4dbe-9074-4995a5f66d2f" />
<img width="1919" height="679" alt="image" src="https://github.com/user-attachments/assets/1ac259aa-6f85-4a3d-86b1-703dbd597353" />
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/151c0050-2733-468f-9cf2-12eb8c6fd848" />
<img width="1920" height="947" alt="image" src="https://github.com/user-attachments/assets/8fe7a7b5-b362-4f1e-9437-4bcb8a131675" />
<img width="1920" height="951" alt="image" src="https://github.com/user-attachments/assets/fb5ebaf4-2b14-4256-ba47-908ece3b59cf" />


---

### 4. Ürün Listeleme Sayfası (Catalog)

**URL:** `http://localhost:5000/Catalog`

**Açıklama:** Tüm ürünlerin listelendiği ve filtrelenebildiği ana katalog sayfasıdır. Catalog Service'den Gateway üzerinden çekilen veriler görüntülenir.

**Özellikler:**
- 🏷️ Ürün adı ve görseli
- 💰 Birim fiyat
- 📂 Kategori bilgisi
- 🛒 Sepete ekle butonu
- 🔍 Kategoriye göre filtreleme

<!-- Ekran görüntüsü: Ürün Listeleme -->
<img width="1920" height="952" alt="image" src="https://github.com/user-attachments/assets/b562d21f-7869-4aaa-a7df-48570d447e67" />


<!-- Ekran görüntüsü: Ürün Listeleme Filtreli -->
<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/674a0e87-23ea-4a22-9993-6f63891288e8" />


---

### 5. Ürün Detay Sayfası

**URL:** `http://localhost:5000/Catalog/Detail/{id}`

**Açıklama:** Seçilen ürünün tüm detaylarını gösteren sayfa.

**Bileşenler:**
- 📸 Büyük ürün görseli
- 📋 Ürün adı, açıklaması, kategorisi
- 💰 Fiyat bilgisi
- 🛒 Sepete ekle formu (adet seçimi)
- 🔗 Benzer ürünler bölümü

<!-- Ekran görüntüsü: Ürün Detay -->
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/dc977ad9-6a64-43a4-b927-84cc0bf6ff8b" />
<img width="1901" height="867" alt="image" src="https://github.com/user-attachments/assets/c3692e0d-c500-4253-aca2-c9b36b011a9a" />
<img width="1920" height="871" alt="image" src="https://github.com/user-attachments/assets/40a64840-3e67-45f5-abf4-d11bb8faed9f" />
<img width="1913" height="857" alt="image" src="https://github.com/user-attachments/assets/650b0d99-b1c5-4663-bfb6-673b0a23d205" />


---

### 6. Sepet Sayfası (Basket)

**URL:** `http://localhost:5000/Basket`

**Açıklama:** Kullanıcının sepetini görüntülediği ve yönettiği sayfadır. Redis üzerinde her kullanıcıya özel saklanan sepet verisi gösterilir.

**Özellikler:**
- 📋 Sepetteki ürünlerin listesi
- 🔢 Adet güncelleme
- ❌ Ürün çıkarma
- 💸 **Kupon Kodu Alanı** — Discount Service'e gRPC ile sorgu yapılır
- 💰 Ara toplam, indirim ve genel toplam
- ✅ Siparişe geç (Checkout) butonu

**Sepet → Discount Service Akışı:**
```
Kullanıcı kupon kodu girer
       ↓
Basket Service → gRPC → Discount Service
       ↓
Kupon geçerliyse indirim tutarı döner
       ↓
Toplam fiyat güncellenir
```

<!-- Ekran görüntüsü: Sepet Sayfası -->
<img width="1920" height="948" alt="image" src="https://github.com/user-attachments/assets/36fe24b7-95ce-4cfd-a019-fc52b18b0fa0" />


<!-- Ekran görüntüsü: Sepet Kupon Uygulandı -->
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/b2b461ab-03bf-4205-bcc9-59c80b383939" />


---

### 7. Checkout / Sipariş Tamamlama

**URL:** `http://localhost:5000/Basket/Checkout`

**Açıklama:** Siparişin tamamlandığı son adım. Form doldurulduktan sonra `BasketCheckoutEvent` RabbitMQ'ya yayınlanır ve Order Service siparişi oluşturur.

**Form Alanları:**
- 👤 Ad, Soyad
- 📧 E-posta
- 📍 Adres (Sokak, Şehir, Ülke, Posta Kodu)
- 💳 Kart bilgileri (Kart adı, Numarası, Son Kullanma, CVV)

**Checkout Akışı:**
```
Kullanıcı formu doldurup onaylar
         ↓
Basket Service → BasketCheckoutEvent → RabbitMQ
         ↓
Sepet Redis'ten silinir
         ↓
Order Service Event'i tüketir → SQL Server'a sipariş kaydedilir
```

<!-- Ekran görüntüsü: Checkout Formu -->
<img width="1920" height="931" alt="image" src="https://github.com/user-attachments/assets/73414f01-47d7-4ccd-8156-bac25ab89b42" />


<!-- Ekran görüntüsü: Checkout Ödeme Bilgileri -->
<img width="1919" height="928" alt="image" src="https://github.com/user-attachments/assets/f912c261-fcdd-47b3-930b-f9ed5f3acf65" />
<img width="1910" height="914" alt="image" src="https://github.com/user-attachments/assets/f6d7cc6b-4540-46b4-90c3-f5b30a42b8a2" />


---

### 8. Sipariş Geçmişi

**URL:** `http://localhost:5000/Order`

**Açıklama:** Giriş yapmış kullanıcının geçmiş siparişlerini listeleyen sayfa. Order Service'den kullanıcı adına göre filtrelenerek getirilir.

**Tablo Kolonları:**
- 📅 Sipariş tarihi
- 💰 Toplam tutar
- 📍 Teslimat adresi
- 🔢 Sipariş ID

<!-- Ekran görüntüsü: Sipariş Geçmişi -->
<img width="1901" height="945" alt="image" src="https://github.com/user-attachments/assets/fd0227ba-6425-4a5f-ba4c-c29a25f4dd22" />
<img width="1920" height="944" alt="image" src="https://github.com/user-attachments/assets/6719ba98-41e3-4b72-9adc-f39d62dc6efc" />
<img width="1918" height="944" alt="image" src="https://github.com/user-attachments/assets/69ec6262-603c-4afd-8ddf-fbb4bef96f17" />
<img width="1917" height="855" alt="image" src="https://github.com/user-attachments/assets/704b3f81-107c-4807-9b78-290b2b965c72" />


---

## 🛡️ Admin Paneli

Admin paneli, **Area** yapısı ile ayrılmıştır. Yalnızca **Admin** rolüne sahip kullanıcılar erişebilir.

**Giriş URL'i:** `http://localhost:5000/Admin`

**Erişim:** Identity Server üzerinden Admin rolüyle giriş yapılır.

---

### 17. Dashboard (Admin Ana Sayfa)

**URL:** `/Admin/Dashboard/Index`

**Açıklama:** Admin panelinin kontrol merkezidir. Tüm servislerdeki anlık verileri bir arada gösterir.

**İstatistikler:**
- 🚗 Toplam Ürün Sayısı
- 📦 Toplam Sipariş Sayısı
- 👤 Toplam Kullanıcı Sayısı
- 💰 Toplam Satış Tutarı
- 🏷️ Toplam Kategori Sayısı
- 💸 Aktif Kupon Sayısı

<!-- Ekran görüntüsü: Admin Dashboard 1 -->
![Admin Dashboard 1](ekran-goruntuleri/admin-dashboard-1.png)

<!-- Ekran görüntüsü: Admin Dashboard 2 -->
![Admin Dashboard 2](ekran-goruntuleri/admin-dashboard-2.png)

---

### 18. Ürün Yönetimi (Admin — Catalog)

**URL:** `/Admin/Catalog/Index`

**Açıklama:** Tüm ürünlerin listelendiği, eklendiği, düzenlendiği ve silindiği yönetim sayfasıdır. Catalog Service API'si üzerinden işlemler gerçekleştirilir.

**Tablo Kolonları:**
- ID, Ürün Adı, Kategori, Fiyat, Görsel, İşlemler

**İşlemler:**
- ➕ Yeni ürün ekleme
- ✏️ Ürün düzenleme
- 🗑️ Ürün silme

<!-- Ekran görüntüsü: Admin Ürün Listesi -->
![Admin Ürün Listesi](ekran-goruntuleri/admin-urun-listesi.png)

**Ürün Ekleme Formu:**

**Form Alanları:**
- Ürün adı
- Açıklama
- Fiyat
- Görsel URL
- Kategori seçimi

<!-- Ekran görüntüsü: Admin Ürün Ekleme -->
![Admin Ürün Ekleme](ekran-goruntuleri/admin-urun-ekle.png)

**Ürün Güncelleme:**

<!-- Ekran görüntüsü: Admin Ürün Güncelleme -->
![Admin Ürün Güncelleme](ekran-goruntuleri/admin-urun-guncelle.png)

---

### 19. Kategori Yönetimi (Admin — Category)

**URL:** `/Admin/Category/Index`

**Açıklama:** Ürün kategorilerini yönetme sayfasıdır. Catalog Service'e bağlıdır.

**İşlemler:**
- Kategori listesi görüntüleme
- Yeni kategori ekleme
- Kategori düzenleme ve silme

**Form Alanları:**
- Kategori adı

<!-- Ekran görüntüsü: Admin Kategori Listesi -->
![Admin Kategori Listesi](ekran-goruntuleri/admin-kategori-listesi.png)

<!-- Ekran görüntüsü: Admin Kategori Ekleme -->
![Admin Kategori Ekleme](ekran-goruntuleri/admin-kategori-ekle.png)

---

### 20. Sipariş Yönetimi (Admin — Orders)

**URL:** `/Admin/Order/Index`

**Açıklama:** Tüm kullanıcılara ait siparişlerin listelendiği ve yönetildiği sayfadır. Order Service API'si üzerinden veriler çekilir.

**Tablo Kolonları:**
- Sipariş ID
- Kullanıcı Adı
- Ad Soyad
- E-posta
- Toplam Tutar
- Adres
- Tarih
- İşlemler

**İşlemler:**
- 👁️ Sipariş detayı görüntüleme
- ✏️ Sipariş güncelleme
- 🗑️ Sipariş silme

<!-- Ekran görüntüsü: Admin Sipariş Listesi -->
![Admin Sipariş Listesi](ekran-goruntuleri/admin-siparis-listesi.png)

<!-- Ekran görüntüsü: Admin Sipariş Detay -->
![Admin Sipariş Detay](ekran-goruntuleri/admin-siparis-detay.png)

---

### 21. İndirim / Kupon Yönetimi (Admin — Discount)

**URL:** `/Admin/Discount/Index`

**Açıklama:** Kupon kodlarının oluşturulduğu, güncellendiği ve silindiği yönetim sayfasıdır. Discount Service API'si üzerinden işlem yapılır.

**Tablo Kolonları:**
- ID, Ürün Adı, Açıklama, İndirim Tutarı, İşlemler

**İşlemler:**
- ➕ Yeni kupon oluşturma
- ✏️ Kupon düzenleme
- 🗑️ Kupon silme

**Form Alanları:**
- Ürün adı (hangi ürüne kupon uygulanacak)
- Açıklama
- İndirim tutarı (TL)

<!-- Ekran görüntüsü: Admin Kupon Listesi -->
![Admin Kupon Listesi](ekran-goruntuleri/admin-kupon-listesi.png)

<!-- Ekran görüntüsü: Admin Kupon Ekleme -->
![Admin Kupon Ekleme](ekran-goruntuleri/admin-kupon-ekle.png)

<!-- Ekran görüntüsü: Admin Kupon Güncelleme -->
![Admin Kupon Güncelleme](ekran-goruntuleri/admin-kupon-guncelle.png)

---

### 22. Kullanıcı Yönetimi (Admin — Users)

**URL:** `/Admin/User/Index`

**Açıklama:** Identity Server üzerinde kayıtlı tüm kullanıcıların listelendiği ve rol yönetiminin yapıldığı sayfadır.

**Tablo Kolonları:**
- Kullanıcı Adı, Ad Soyad, E-posta, Rol, İşlemler

**İşlemler:**
- 👁️ Kullanıcı bilgilerini görüntüleme
- 🔑 Rol atama / kaldırma (Admin / User)
- 🗑️ Kullanıcı silme

<!-- Ekran görüntüsü: Admin Kullanıcı Listesi -->
![Admin Kullanıcı Listesi](ekran-goruntuleri/admin-kullanici-listesi.png)

<!-- Ekran görüntüsü: Admin Kullanıcı Rol Atama -->
![Admin Kullanıcı Rol](ekran-goruntuleri/admin-kullanici-rol.png)

---


## 👤 Geliştirici

**Berkay Gençeroğlu**

- GitHub: [@BerkayGenceroglu](https://github.com/BerkayGenceroglu)
- LinkedIn: [Berkay Gençeroğlu](https://www.linkedin.com/in/berkay-gencero%C4%9Flu-586b52331/)

---

## 📫 İletişim

Proje hakkında sorularınız veya önerileriniz için benimle iletişime geçebilirsiniz:

- 📧 E-posta: **berkaygenceroglu6@gmail.com**
- 🔗 LinkedIn: [Berkay Gençeroğlu](https://www.linkedin.com/in/berkay-gencero%C4%9Flu-586b52331/)

---

## 💬 Son Söz

Teşekkürler! Bu projeyi incelediğiniz için memnuniyet duyarım.
Her türlü geri bildirime açığım.

**İyi kodlamalar! 🚀**

<p align="center">
  ⭐ Beğendiyseniz yıldız vermeyi unutmayın!
</p>
