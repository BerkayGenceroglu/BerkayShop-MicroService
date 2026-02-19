using StackExchange.Redis;
using System.Diagnostics.Metrics;

namespace BerkayShop.Basket.Setttings
{
    public class RedisService
    {
        public string _host { get; set; }
        public int _port { get; set; }

        private ConnectionMultiplexer _connectionMultiplexer;
        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }
        public void Connect() => _connectionMultiplexer = ConnectionMultiplexer.Connect($"{_host}:{_port}");
        
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(db);
        //Connect() çağrıldığında iş yapılır ama değer dönmez,
        //GetDb() çağrıldığında bir değer döner,
        //=> return’ü gizli yazar.
    }
}
