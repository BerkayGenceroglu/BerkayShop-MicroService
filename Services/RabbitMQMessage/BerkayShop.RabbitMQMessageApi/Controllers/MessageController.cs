using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace BerkayShop.RabbitMQMessageApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        [HttpPost]
        public IActionResult CreateMessage()
        {
            //ConnectionFactory → RabbitMQ sunucusuna bağlanmak için kullanılan sınıftır.
            //HostName = "localhost" → RabbitMQ’nun bu bilgisayarda çalıştığını söyler.
            //.CreateConnection() → Gerçek bağlantıyı oluşturur.
            var connection = new ConnectionFactory() { HostName = "localhost" }.CreateConnection();

            //connection üzerinden bir channel(kanal) oluşturulur.
            //RabbitMQ’da mesaj gönderme ve alma işlemleri doğrudan connection üzerinden değil, channel üzerinden yapılır.
            //👉 Yani burada:Mesaj gönderip almak için bir iletişim kanalı açılıyor.
            var channel = connection.CreateModel();

            channel.QueueDeclare("Kuyruk2", false, false, false, arguments: null);
            var MessageContent = "Farklı Bir Kuyruğa Mesaj Eklemiş Bulunmaktayım";
            var byteMessageContent = Encoding.UTF8.GetBytes(MessageContent);

            channel.BasicPublish(exchange:"", routingKey:"Kuyruk2", basicProperties :null, body:byteMessageContent);

            return Ok("Mesaj Kuyruya Alındı");
        }
        private static string message;
        [HttpGet]
        public IActionResult ReadMessage()
        {
            var connection2 = new ConnectionFactory();
            connection2.HostName = "localhost";
            var channnel = connection2.CreateConnection().CreateModel();
            //Connection = Ana bağlantı
            //Channel = O bağlantı içindeki iletişim hattı

            var consumer = new EventingBasicConsumer(channnel);
            //EventingBasicConsumer → Kuyruğu dinleyen tüketici.
            consumer.Received += (model, x) =>
            {
                var byteMessage = x.Body.ToArray();
                message = Encoding.UTF8.GetString(byteMessage);
            };
            //+= operatörü: Olaya(event) bir metod bağlar. Yani "Received olayı gerçekleştiğinde bu kodu çalıştır" demek.
            //Received olayı: Kuyruktan yeni bir mesaj geldiğinde otomatik olarak tetiklenir.
            //(model, x) => { ... }: Lambda expression(anonim fonksiyon)
            //model: Mesajı gönderen model(genellikle kullanılmaz)
            //x: Gelen mesajın tüm bilgilerini içeren nesne
            channnel.BasicConsume(queue: "Kuyruk1", autoAck: true, consumer: consumer);

            if (string.IsNullOrEmpty(message))
            {
                return NoContent();
            }
            else
            {
                return Ok(message);
            }
        }
    }
}
