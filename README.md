<h1 align="center"> BerkayShop - Modern Mikroservis E-Ticaret Platformu</h1>
<img width="1003" height="233" alt="image" src="https://github.com/user-attachments/assets/54af7c48-1e79-4b58-bc24-6f7f366f3aee" />

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

## 🐳 Docker - Veritabanı ve Port Yönetimi

Bu proje, mikroservis mimarisinin temel prensiplerinden biri olan servis izolasyonu ilkesini korumak amacıyla Docker altyapısı kullanılarak geliştirilmiştir. Her mikroservis bağımsız bir konteyner içerisinde çalışır ve kendi veritabanı ile haberleşir.
**🎯 Amaç:**
-Servisler arası bağımlılığı minimuma indirmek
-Ortam bağımsız (environment-agnostic) kurulum sağlamak
-Hızlı geliştirme ve dağıtım (deployment) süreci oluşturmak
-Port çakışmalarını ve konfigürasyon karmaşasını önlemek

<!-- Ekran görüntüsü: Docker Container  -->
<img width="1920" height="601" alt="image" src="https://github.com/user-attachments/assets/d4c9fd3b-efd8-454b-a5c6-ba08fdacee3f" />


<img width="223" height="240" alt="image" src="https://github.com/user-attachments/assets/82f1268f-898e-439b-a1fa-ea9bcf12a953" />

---

## Service – Port Configuration
Aşşağıdaki tabloda her mikroservisin dış dünyaya açıldığı port numaraları belirtilmiştir.Ocelot (API Gateway) tüm istemci (client) isteklerini 5000 portu üzerinden karşılar ve ilgili mikroservise yönlendirir.
Diğer servisler (Identity, Catalog, Order, Basket vb.) kendi özel portlarında izole şekilde çalışır.UI uygulaması 7144 portu üzerinden erişilebilir durumdadır.
**🎯 Bu yapı sayesinde:**
-Servisler bağımsız olarak çalıştırılabilir.
-Port çakışmaları engellenir.
-Gateway üzerinden merkezi yönlendirme sağlanır.
-Geliştirme ve test süreçleri daha kontrollü ilerler.

<img width="223" height="240" alt="image" src="https://github.com/user-attachments/assets/3e49a5df-5de7-4db4-85df-be4717b2f890" />



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

**URL:** `Default/DefaultPage`

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

**URL:** `ProductList/AllProductList?categoryId`

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

<!-- Ekran görüntüsü: Ürün Listeleme Filtreli -->
<img width="1918" height="957" alt="image" src="https://github.com/user-attachments/assets/2bc9fe41-8f29-47bb-bea5-ab0c45e504f4" />

---

### 5. Ürün Detay Sayfası

**URL:** `ProductList/ProductDetail?productId`

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

**URL:** `ShoppingCart/BasketPage`

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

**URL:** `Order/Index?LastPriceAfterDiscount=`

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
<img width="1920" height="946" alt="image" src="https://github.com/user-attachments/assets/162bc2de-a960-4e70-8345-69869c7926c8" />


**URL:** `Payment/PaymentPage`

<!-- Ekran görüntüsü: Checkout Ödeme Bilgileri -->
<img width="1919" height="928" alt="image" src="https://github.com/user-attachments/assets/f912c261-fcdd-47b3-930b-f9ed5f3acf65" />
<img width="1910" height="914" alt="image" src="https://github.com/user-attachments/assets/f6d7cc6b-4540-46b4-90c3-f5b30a42b8a2" />


---

### 8. Sipariş Geçmişi

**URL:** `User/MyOrder/Index`

**Açıklama:** Giriş yapmış kullanıcının geçmiş siparişlerini listeleyen sayfa. Order Service'den kullanıcı adına göre filtrelenerek getirilir.

**Tablo Kolonları:**
- 📅 Sipariş tarihi
- 💰 Toplam tutar
- 📍 Teslimat adresi
- 🔢 Sipariş ID

<!-- Ekran görüntüsü: Sipariş Geçmişi -->
Profilim:<img width="1901" height="945" alt="image" src="https://github.com/user-attachments/assets/fd0227ba-6425-4a5f-ba4c-c29a25f4dd22" />
Siparişlerim:<img width="1920" height="944" alt="image" src="https://github.com/user-attachments/assets/6719ba98-41e3-4b72-9adc-f39d62dc6efc" />
Gelen Mesaj: <img width="1918" height="944" alt="image" src="https://github.com/user-attachments/assets/69ec6262-603c-4afd-8ddf-fbb4bef96f17" />
Giden Mesaj:<img width="1917" height="855" alt="image" src="https://github.com/user-attachments/assets/704b3f81-107c-4807-9b78-290b2b965c72" />


---

## 🛡️ Admin Paneli

Admin paneli, **Area** yapısı ile ayrılmıştır. Yalnızca **Admin** rolüne sahip kullanıcılar erişebilir.

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
<img width="1920" height="950" alt="image" src="https://github.com/user-attachments/assets/6a86d6e3-bbe8-4033-9e53-f7c92e3cf201" />

### 18. Rapid Api Veri Araması 

**URL:** `/Admin/Dashboard/Index`

**Açıklama:**  Admin Paneli içinde entegre edilmiş Rapid API bileşenidir. Dış kaynaklı verilerle admin panelini zenginleştirir. API sorguları anlık olarak çalışır ve sonuçlar ekranda listelenir.

<!-- Ekran görüntüsü: Admin Rapid Api  -->
<img width="1918" height="943" alt="image" src="https://github.com/user-attachments/assets/a5b82da2-cbe0-4f61-9c7a-d9a21332fdee" />
<img width="1917" height="953" alt="image" src="https://github.com/user-attachments/assets/7c1deeba-1d45-4495-8103-7e54b9b910a3" />
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/b45d6d9a-b94d-4a7e-923d-ebac2a2682c0" />
<img width="1920" height="951" alt="image" src="https://github.com/user-attachments/assets/7f137b84-1b9d-4fa3-a1cf-05538ca199d3" />
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/eabe8e8b-d12e-4a60-be09-eeaae6df3023" />
<img width="1920" height="948" alt="image" src="https://github.com/user-attachments/assets/daf9e322-0563-4dba-8778-82b29988ed46" />

---

### 18. Ürün Yönetimi (Admin — Catalog)

**URL:** `Admin/Product/ProductListWithCategory`

**Açıklama:** Tüm ürünlerin listelendiği, eklendiği, düzenlendiği ve silindiği yönetim sayfasıdır. Catalog Service API'si üzerinden işlemler gerçekleştirilir.

**Tablo Kolonları:**
- ID, Ürün Adı, Kategori, Fiyat, Görsel, İşlemler

**İşlemler:**
- ➕ Yeni ürün ekleme
- ✏️ Ürün düzenleme
- 🗑️ Ürün silme

<!-- Ekran görüntüsü: Admin Ürün Listesi -->
<img width="1920" height="956" alt="image" src="https://github.com/user-attachments/assets/73c415c9-8377-4604-9436-cfce0f719a05" />
<img width="1920" height="952" alt="image" src="https://github.com/user-attachments/assets/79166ea5-0943-435e-b261-473c201dba65" />
<img width="1919" height="950" alt="image" src="https://github.com/user-attachments/assets/390d9866-1644-4730-8aae-1b20339763ca" />
<img width="1916" height="955" alt="image" src="https://github.com/user-attachments/assets/f6843fba-8dc5-4ca4-b36a-59be144567cc" />
<img width="1920" height="955" alt="image" src="https://github.com/user-attachments/assets/dfd215c2-f4d6-4022-a40f-78242bbb15ee" />

---

### 19. Kategori Yönetimi (Admin — Category)

**URL:** `Admin/Category/CategoryList`

**Açıklama:** Ürün kategorilerini yönetme sayfasıdır. Catalog Service'e bağlıdır.

**İşlemler:**
- Kategori listesi görüntüleme
- Yeni kategori ekleme
- Kategori düzenleme ve silme

<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/f5863dfc-aff6-4f80-b3e1-ecc7748e0eb3" />
<img width="1920" height="918" alt="image" src="https://github.com/user-attachments/assets/1fa0f631-3972-4049-94cd-d7123cfeb0d7" />
<img width="1920" height="920" alt="image" src="https://github.com/user-attachments/assets/3846b24a-e247-4c6b-8ccc-0576532c936a" />

---

### 20. Sipariş Yönetimi (Admin — Orders)

**URL:** `/Admin/Order/OrderList`

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
<img width="1920" height="949" alt="image" src="https://github.com/user-attachments/assets/78a82687-4d70-41b8-876b-03e433f6fe93" />

---
### 25. Comment Yönetimi (Admin — Comment)

**URL:** `Admin/Comment/CommentList`

**Açıklama:** Tüm kullanıcılara ait Yorumların listelendiği ve yönetildiği sayfadır. Comment Service API'si üzerinden veriler çekilir.

**İşlemler:**
- 👁️ Comment görüntüleme
- ✏️ Comment güncelleme
- 🗑️ Comment silme

<!-- Ekran görüntüsü: Admin Sipariş Listesi -->
<img width="1920" height="953" alt="image" src="https://github.com/user-attachments/assets/2189719c-4cc5-46d1-92a8-55cf4550c7e9" />
<img width="1918" height="949" alt="image" src="https://github.com/user-attachments/assets/01509625-3863-4857-aa10-40aada68eca7" />

### 26. Slider Yönetimi (Admin — Slider)

**URL:** `Admin/FeatureSlider/FeatureSliderList`

**Açıklama:** Siteye ait Sliderların listelendiği ve yönetildiği sayfadır. Catalog Service API'si üzerinden veriler çekilir.

**İşlemler:**
- 👁️ Sliderlar detayı görüntüleme
- ✏️ Sliderlar güncelleme
- 🗑️ Sliderlar silme

<!-- Ekran görüntüsü: Admin Sipariş Listesi -->
<img width="1920" height="915" alt="image" src="https://github.com/user-attachments/assets/8697e66c-1d29-4505-9fe2-49190514182d" />
<img width="1918" height="915" alt="image" src="https://github.com/user-attachments/assets/dfe30a39-5a67-41d2-87e0-e68f1229bfd6" />
<img width="1917" height="920" alt="image" src="https://github.com/user-attachments/assets/3d56e1e4-3ec7-4d97-9e66-cd929e8210c6" />


---
### 27. Öne Çıkan Özellikler Yönetimi (Admin — Öne Çıkan Özellikler)

**URL:** `Admin/Feature/FeatureList`

**Açıklama:**  Siteye ait Öne Çıkan Özellikler listelendiği ve yönetildiği sayfadır. Catalog Service API'si üzerinden veriler çekilir.

**İşlemler:**
- 👁️ Öne Çıkan Özellikler detayı görüntüleme
- ✏️ Öne Çıkan Özellikler güncelleme
- 🗑️ Öne Çıkan Özellikler silme

<!-- Ekran görüntüsü: Admin Sipariş Listesi -->
<img width="1915" height="914" alt="image" src="https://github.com/user-attachments/assets/734eaddb-d7b3-4627-88f3-30b2c40e421e" />
<img width="1920" height="916" alt="image" src="https://github.com/user-attachments/assets/76471a25-e777-4d96-902a-07ff0ff9dd1c" />
<img width="1920" height="918" alt="image" src="https://github.com/user-attachments/assets/b7fd7f73-e75a-413b-9441-232bf0d2d697" />



---
### 27. Özel Teklif  Yönetimi (Admin — Öne Çıkan Özellikler)

**URL:** `/Admin/OfferDiscount/OfferDiscountList`

**Açıklama:** Siteye ait Özel Tekliflerin  listelendiği ve yönetildiği sayfadır. Catalog Service API'si üzerinden veriler çekilir.

**İşlemler:**
- 👁️ Özel Teklifler detayı görüntüleme
- ✏️ Özel Teklifler güncelleme
- 🗑️ Özel Teklifler silme

<!-- Ekran görüntüsü: Admin Sipariş Listesi -->
<img width="1920" height="921" alt="image" src="https://github.com/user-attachments/assets/822c70ee-e362-4498-b03d-be4dbeb814c2" />
<img width="1920" height="918" alt="image" src="https://github.com/user-attachments/assets/04808e0e-73d4-451c-bddb-3dfed393a1e7" />
<img width="1920" height="915" alt="image" src="https://github.com/user-attachments/assets/ff740e6e-9c63-4afb-918a-35a2d945c5bf" />


---
### 21. Özel İndirim Yönetimi (Admin — Discount)

**URL:** `Admin/SpecialOffer/SpecialOfferList`

**Açıklama:** Siteye ait Özel İndirim  listelendiği ve yönetildiği sayfadır. Catalog Service API'si üzerinden veriler çekilir.

**İşlemler:**
- ➕ Özel İndirim oluşturma
- ✏️ Özel İndirim düzenleme
- 🗑️ Özel İndirim silme

<!-- Ekran görüntüsü: Admin Kupon Listesi -->
<img width="1920" height="918" alt="image" src="https://github.com/user-attachments/assets/ecc4247a-430e-4d9b-8384-031ed980eabb" />
<img width="1920" height="870" alt="image" src="https://github.com/user-attachments/assets/4e4b2056-9522-4cfe-9e0e-df8183836c5e" />
<img width="1920" height="926" alt="image" src="https://github.com/user-attachments/assets/ad8e3efa-a801-4aa3-9118-c259275fd7c6" />

### 21. Marka Yönetimi (Admin — Brand)

**URL:** `Admin/Brand/BrandList`

**Açıklama:** Siteye ait Markaların listelendiği ve yönetildiği sayfadır. Catalog Service API'si üzerinden veriler çekilir.

**İşlemler:**
- ➕ Marka oluşturma
- ✏️ Marka düzenleme
- 🗑️ Marka silme


<!-- Ekran görüntüsü: Admin Kupon Listesi -->

<img width="1920" height="954" alt="image" src="https://github.com/user-attachments/assets/fa677d2f-e957-41cc-9fee-5eaf0bfcd762" />
<img width="1919" height="943" alt="image" src="https://github.com/user-attachments/assets/462478c5-7deb-43f2-aa58-f2faeaa7275c" />
<img width="1919" height="948" alt="image" src="https://github.com/user-attachments/assets/b7df59eb-e928-4ac0-b277-c02edc6899ea" />


<img width="1920" height="923" alt="image" src="https://github.com/user-attachments/assets/acd8453f-8a3f-4601-bf6c-1ba93033fe2e" />
<img width="1920" height="917" alt="image" src="https://github.com/user-attachments/assets/71ec72be-8347-4a0e-a93d-61d4c01dac48" />
<img width="1918" height="922" alt="image" src="https://github.com/user-attachments/assets/e09af030-5817-4614-a4ca-b5ec08083cd4" />

### 21. Kargo Firmaları Yönetimi (Admin — Discount)

**URL:** `/Admin/Cargo/CargoCompanyList`

**Açıklama:** Siteye ait Cargo Firmaların listelendiği ve yönetildiği sayfadır. Cargo Service API'si üzerinden veriler çekilir.

**İşlemler:**
- ➕ Cargo Firma oluşturma
- ✏️ Cargo Firma düzenleme
- 🗑️ Cargo Firma silme


<!-- Ekran görüntüsü: Admin Kupon Listesi -->
<img width="1920" height="921" alt="image" src="https://github.com/user-attachments/assets/a55216e5-4357-424b-81b3-a3eaca1be838" />
<img width="1915" height="918" alt="image" src="https://github.com/user-attachments/assets/f34de96f-0226-41aa-a094-62682505354c" />
<img width="1920" height="917" alt="image" src="https://github.com/user-attachments/assets/ade8fea8-eb54-4023-aaa7-cfb38de049b3" />


---

### 21. Hakkımda-Bilgi Yönetimi (Admin — About)

**URL:** `Admin/About/AboutList`

**Açıklama:** Siteye ait Bilgi-Hakkımda kısmının listelendiği ve yönetildiği sayfadır. Catalog Service API'si üzerinden veriler çekilir.

**İşlemler:**
- ➕ Hakkımda oluşturma
- ✏️ Hakkımda düzenleme
- 🗑️ Hakkımda silme


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
<img width="1920" height="920" alt="image" src="https://github.com/user-attachments/assets/f98be026-ef81-41e4-b45e-af3b3d2caa42" />


<!-- Ekran görüntüsü: Admin Kullanıcı Rol Atama -->
![Admin Kullanıcı Rol](ekran-goruntuleri/admin-kullanici-rol.png)

<img width="1920" height="918" alt="image" src="https://github.com/user-attachments/assets/21f1cd02-af4a-4986-93c5-b8e22e6dd185" />

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
 <img width="595" height="548" alt="image" src="https://github.com/user-attachments/assets/742caf97-a38b-4deb-8e26-238921a5a87a" />
</p>>
