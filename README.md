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

## 🔌 API Gateway — Ocelot

### 9. Gateway Route Yapısı

**URL:** `http://localhost:5010`

**Açıklama:** Tüm mikroservislerin önünde duran tek giriş noktasıdır. Frontend ve dış istemciler yalnızca bu adrese istek yapar; Gateway doğru servise yönlendirir.

**Görevleri:**
- 🔀 İstekleri ilgili servise yönlendirme
- 🛡️ JWT token doğrulama
- ⚡ Rate Limiting
- ⚖️ Load Balancing

**Tüm Route Haritası:**

| Gateway URL | Yönlendiği Servis | Method |
|-------------|-------------------|--------|
| `/services/catalog/api/products` | Catalog :5011 | GET, POST, PUT, DELETE |
| `/services/catalog/api/products/{id}` | Catalog :5011 | GET |
| `/services/catalog/api/categories` | Catalog :5011 | GET |
| `/services/basket/api/basket/{username}` | Basket :5013 | GET, POST, DELETE |
| `/services/basket/api/basket/checkout` | Basket :5013 | POST |
| `/services/discount/api/discount/{name}` | Discount :5014 | GET, POST, PUT, DELETE |
| `/services/order/api/v1/order/{username}` | Order :5015 | GET |
| `/services/order/api/v1/order` | Order :5015 | POST, PUT, DELETE |

<!-- Ekran görüntüsü: Postman ile Gateway testi -->
![Gateway Postman](ekran-goruntuleri/gateway-postman.png)

---

## 🏷️ Catalog Service

### 10. Ürün API (Swagger)

**URL:** `http://localhost:5011/swagger`

**Açıklama:** MongoDB tabanlı ürün ve kategori yönetim servisidir. Okuma ağırlıklı yapısıyla hızlı yanıt süresi sunar.

**Endpoint'ler:**

| Method | Endpoint | Açıklama | Auth |
|--------|----------|----------|------|
| `GET` | `/api/products` | Tüm ürünler | ❌ |
| `GET` | `/api/products/{id}` | Ürün detayı | ❌ |
| `GET` | `/api/products/getproductbycategory/{category}` | Kategoriye göre | ❌ |
| `POST` | `/api/products` | Ürün ekle | ✅ |
| `PUT` | `/api/products` | Ürün güncelle | ✅ |
| `DELETE` | `/api/products/{id}` | Ürün sil | ✅ |
| `GET` | `/api/categories` | Kategoriler | ❌ |

**Veri Modeli:**
```json
{
  "id": "64f1b2c3d4e5f6a7b8c9d0e1",
  "name": "Samsung Galaxy S24",
  "description": "Amiral gemisi akıllı telefon",
  "price": 45999.99,
  "imageFile": "samsung-s24.jpg",
  "category": {
    "id": "64f1b2c3d4e5f6a7b8c9d0e2",
    "name": "Elektronik"
  }
}
```

<!-- Ekran görüntüsü: Catalog Service Swagger -->
![Catalog Swagger](ekran-goruntuleri/catalog-swagger.png)

---

## 🛒 Basket Service

### 11. Sepet API (Swagger)

**URL:** `http://localhost:5013/swagger`

**Açıklama:** Redis tabanlı sepet yönetim servisidir. Her kullanıcının sepeti Redis'te key-value olarak saklanır.

**Endpoint'ler:**

| Method | Endpoint | Açıklama | Auth |
|--------|----------|----------|------|
| `GET` | `/api/basket/{username}` | Sepeti getir | ✅ |
| `POST` | `/api/basket` | Sepet güncelle | ✅ |
| `DELETE` | `/api/basket/{username}` | Sepeti sil | ✅ |
| `POST` | `/api/basket/checkout` | Sipariş ver | ✅ |

**Veri Modeli:**
```json
{
  "username": "berkay",
  "items": [
    {
      "productId": "64f1b2c3d4e5f6a7b8c9d0e1",
      "productName": "Samsung Galaxy S24",
      "quantity": 2,
      "price": 45999.99,
      "imageFile": "samsung-s24.jpg"
    }
  ]
}
```

<!-- Ekran görüntüsü: Basket Service Swagger -->
![Basket Swagger](ekran-goruntuleri/basket-swagger.png)

---

## 💸 Discount Service

### 12. İndirim API (Swagger)

**URL:** `http://localhost:5014/swagger`

**Açıklama:** PostgreSQL + Dapper ile geliştirilmiş kupon yönetim servisidir. REST API'ye ek olarak gRPC sunucu olarak da çalışır.

**REST Endpoint'ler:**

| Method | Endpoint | Açıklama |
|--------|----------|----------|
| `GET` | `/api/discount/{productName}` | Kuponu getir |
| `POST` | `/api/discount` | Kupon oluştur |
| `PUT` | `/api/discount` | Kupon güncelle |
| `DELETE` | `/api/discount/{productName}` | Kupon sil |

**gRPC Servisi:**
```protobuf
service DiscountProtoService {
  rpc GetDiscount(GetDiscountRequest) returns (CouponModel);
  rpc CreateDiscount(CreateDiscountRequest) returns (CouponModel);
  rpc UpdateDiscount(UpdateDiscountRequest) returns (CouponModel);
  rpc DeleteDiscount(DeleteDiscountRequest) returns (DeleteDiscountResponse);
}
```

**Veri Modeli:**
```json
{
  "id": 1,
  "productName": "Samsung Galaxy S24",
  "description": "Teknoloji fuarı kampanyası",
  "amount": 2000
}
```

<!-- Ekran görüntüsü: Discount Service Swagger -->
![Discount Swagger](ekran-goruntuleri/discount-swagger.png)

---

## 📦 Order Service

### 13. Sipariş API (Swagger)

**URL:** `http://localhost:5015/swagger`

**Açıklama:** Clean Architecture, DDD ve CQRS deseniyle geliştirilmiş sipariş yönetim servisidir. RabbitMQ üzerinden `BasketCheckoutEvent`'i tüketir.

**Endpoint'ler:**

| Method | Endpoint | Açıklama | Auth |
|--------|----------|----------|------|
| `GET` | `/api/v1/order/{username}` | Kullanıcı siparişleri | ✅ |
| `POST` | `/api/v1/order` | Sipariş oluştur | ✅ |
| `PUT` | `/api/v1/order` | Sipariş güncelle | ✅ |
| `DELETE` | `/api/v1/order/{id}` | Sipariş sil | ✅ |

**CQRS Akışı:**
```
HTTP İsteği
    ↓
OrderController
    ↓
MediatR.Send(Command/Query)
    ↓
ValidationBehaviour → LoggingBehaviour
    ↓
CommandHandler / QueryHandler
    ↓
IOrderRepository → SQL Server
```

**Veri Modeli:**
```json
{
  "id": 1,
  "userName": "berkay",
  "totalPrice": 89999.98,
  "firstName": "Berkay",
  "lastName": "Gençeroğlu",
  "emailAddress": "berkay@example.com",
  "addressLine": "Örnek Caddesi No:1",
  "country": "Türkiye",
  "state": "İstanbul",
  "zipCode": "34000",
  "cardName": "BERKAY GENCEROĞLU",
  "cardNumber": "4111111111111111",
  "expiration": "12/26",
  "cvv": "123",
  "paymentMethod": 1
}
```

<!-- Ekran görüntüsü: Order Service Swagger -->
![Order Swagger](ekran-goruntuleri/order-swagger.png)

---

## 🔑 Identity Server Yapılandırması

### 14. Token Alma — Postman

**URL:** `http://localhost:5001/connect/token`

**Açıklama:** API testleri için Postman üzerinden token alınabilir. Token tüm servislerdeki korumalı endpoint'lere erişimde kullanılır.

**İstek:**
```
POST http://localhost:5001/connect/token
Content-Type: application/x-www-form-urlencoded

client_id     = BerkayShopClientCredentials
client_secret = secret
grant_type    = client_credentials
scope         = gateway_fullpermission
```

**Yanıt:**
```json
{
  "access_token": "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9...",
  "expires_in": 3600,
  "token_type": "Bearer",
  "scope": "gateway_fullpermission"
}
```

**Kullanım:**
```
Authorization: Bearer eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9...
```

**Tanımlı Scope'lar:**

| Scope | Açıklama |
|-------|----------|
| `catalog_fullpermission` | Catalog API'ye tam erişim |
| `basket_fullpermission` | Basket API'ye tam erişim |
| `discount_fullpermission` | Discount API'ye tam erişim |
| `order_fullpermission` | Order API'ye tam erişim |
| `gateway_fullpermission` | Gateway üzerinden tüm erişim |

<!-- Ekran görüntüsü: Postman Token Alma -->
![Postman Token](ekran-goruntuleri/postman-token.png)

---

## 🔄 Servisler Arası İletişim Diyagramı

### 15. gRPC — Basket → Discount

```
┌──────────────────────────────────────────────┐
│             Basket Service                    │
│  POST /api/basket/checkout çağrıldığında...  │
└─────────────────────┬────────────────────────┘
                      │
                      │  gRPC (Protobuf)
                      │  GetDiscount(productName)
                      ↓
┌──────────────────────────────────────────────┐
│            Discount Service                   │
│   PostgreSQL'den kuponu sorgular             │
│   CouponModel { Amount: 2000 } döner         │
└─────────────────────┬────────────────────────┘
                      │
                      ↓
             Toplam fiyat hesaplanır
             İndirim uygulanır
```

### 16. RabbitMQ — Basket → Order

```
┌──────────────────────────────────────────────┐
│             Basket Service                    │
│   BasketCheckoutEvent yayınlar               │
└─────────────────────┬────────────────────────┘
                      │
                      │  AMQP (RabbitMQ)
                      │  Exchange: basket-checkout
                      ↓
                 ┌──────────┐
                 │ RabbitMQ │
                 │  Queue   │
                 └────┬─────┘
                      │
                      ↓
┌──────────────────────────────────────────────┐
│              Order Service                    │
│   BasketCheckoutConsumer event'i alır        │
│   CheckoutOrderCommand → MediatR             │
│   SQL Server'a sipariş kaydedilir            │
└──────────────────────────────────────────────┘
```

<!-- Ekran görüntüsü: RabbitMQ Yönetim Paneli -->
![RabbitMQ Panel](ekran-goruntuleri/rabbitmq-panel.png)

---

## 🚀 Kurulum ve Çalıştırma

### Ön Gereksinimler

| Araç | Versiyon |
|------|----------|
| .NET SDK | 8.0+ |
| Docker Desktop | Son sürüm |
| Visual Studio | 2022+ |
| Postman | Herhangi |

---

### Adım 1 — Repoyu Klonlayın

```bash
git clone https://github.com/BerkayGenceroglu/BerkayShop-MicroService.git
cd BerkayShop-MicroService
```

---

### Adım 2 — Docker ile Altyapıyı Başlatın

```bash
# MongoDB — Catalog Service için
docker run -d --name berkayshop-mongo -p 27017:27017 mongo

# Redis — Basket Service için
docker run -d --name berkayshop-redis -p 6379:6379 redis

# PostgreSQL — Discount Service için
docker run -d --name berkayshop-postgres \
  -e POSTGRES_USER=admin \
  -e POSTGRES_PASSWORD=admin1234 \
  -e POSTGRES_DB=DiscountDb \
  -p 5432:5432 postgres

# SQL Server — Order & Identity için
docker run -d --name berkayshop-mssql \
  -e "ACCEPT_EULA=Y" \
  -e "SA_PASSWORD=Admin1234!" \
  -p 1433:1433 \
  mcr.microsoft.com/mssql/server:2019-latest

# RabbitMQ — Mesaj kuyruğu için
docker run -d --name berkayshop-rabbitmq \
  -p 5672:5672 -p 15672:15672 \
  rabbitmq:3-management
```

---

### Adım 3 — Servisleri Başlatın

Her servisi ayrı bir terminalde çalıştırın ya da Visual Studio'da **Multiple Startup Projects** yapılandırması kullanın.

```bash
# 1. Identity Server (önce bu başlamalı)
cd IdentityServer/BerkayShop.IdentityServer
dotnet run

# 2. Catalog Service
cd Services/Catalog/BerkayShop.Services.Catalog
dotnet run

# 3. Basket Service
cd Services/Basket/BerkayShop.Services.Basket
dotnet run

# 4. Discount Service
cd Services/Discount/BerkayShop.Services.Discount
dotnet run

# 5. Order Service
cd Services/Order/BerkayShop.Services.Order.API
dotnet run

# 6. API Gateway (servisler ayaktayken başlat)
cd BerkayShop.OcelotGateway
dotnet run

# 7. Frontend
cd Frontends/BerkayShop.Web
dotnet run
```

---

### Adım 4 — Uygulamaya Erişin

| Servis | URL |
|--------|-----|
| 🌐 Frontend | http://localhost:5000 |
| 🔐 Identity Server | http://localhost:5001 |
| 🌐 API Gateway | http://localhost:5010 |
| 📦 Catalog Swagger | http://localhost:5011/swagger |
| 🛒 Basket Swagger | http://localhost:5013/swagger |
| 💸 Discount Swagger | http://localhost:5014/swagger |
| 📋 Order Swagger | http://localhost:5015/swagger |
| 🐇 RabbitMQ Panel | http://localhost:15672 (guest/guest) |

---



## 📚 Kaynaklar

Bu proje geliştirilirken yararlanılan makaleler ve kaynaklar `Articles.txt` dosyasında listelenmiştir.

- [Microsoft Microservices Architecture Guide](https://dotnet.microsoft.com/learn/aspnet/microservices-architecture)
- [Ocelot Dokümantasyonu](https://ocelot.readthedocs.io/)
- [IdentityServer4 Dokümantasyonu](https://identityserver4.readthedocs.io/)
- [MassTransit Dokümantasyonu](https://masstransit.io/)
- [gRPC for .NET](https://docs.microsoft.com/aspnet/core/grpc/)

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
