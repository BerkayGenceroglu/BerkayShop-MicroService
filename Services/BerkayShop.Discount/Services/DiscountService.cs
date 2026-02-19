
using BerkayShop.Discount.Context;
using BerkayShop.Discount.Dtos;
using Dapper;

namespace BerkayShop.Discount.Services
{
    public class DiscountService : IDiscountService
    {
        private readonly DapperContext _context;

        public DiscountService(DapperContext context)
        {
            _context = context;
        }

        public async Task CreateDiscountAsync(CreateDiscountDto createDiscountDto)
        {
            string query = "insert into Coupons (Code,Rate,IsActive,ValidDate) values (@code,@rate,@isactive,@validdate)";
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, createDiscountDto);
            }
        }

        public async Task DeleteDiscountAsync(int id)
        {
            string query = "Delete From Coupons Where CouponId=@id";
            var parameters = new DynamicParameters();
            using (var connection = _context.CreateConnection())
            {
                await connection.ExecuteAsync(query, new {id});
            }
        }

        public async Task<List<ResultDiscountDto>> GetAllDiscountAsync()
        {
            string query = "Select * from Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<ResultDiscountDto>(query);
                return values.ToList();

            }
        }

        public async Task<GetByIdDiscountDto> GetByIdDiscountAsync(int idd)
        {
            string query = "Select * from Coupons where CouponId=@id";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryFirstOrDefaultAsync<GetByIdDiscountDto>(query, new { id =idd});
                return values!;
            }
            //👉 Connection string’i(adres) alır, veritabanına bağlanır; using bitince de bağlantıyı otomatik kapatır.
        }

        public async Task<ResultDiscountDto> GetCodeDetailByCodeAsync(string code)
        {
            string query = "SELECT * FROM Coupons WHERE Code = @code";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection
                    .QueryFirstOrDefaultAsync<ResultDiscountDto>(query, new { code });

                return values; // ! KULLANMA
            }
        }

        public async Task<int> GetDiscountCouponCountAsync()
        {
            string query = "Select Count(*) from Coupons";
            using (var connection = _context.CreateConnection())
            {
                var values = await connection.QueryAsync<int>(query);
                return values.FirstOrDefault();

            }
        }

        public async Task UpdateDiscountAsync(UpdateDiscountDto updateDiscountDto)
        {
            string query = "Update Coupons Set Code=@code,Rate=@rate,IsActive=@isactive,ValidDate=@validdate Where CouponId=@CouponId";
            var parameters = new DynamicParameters();
            using (var connection = _context.CreateConnection()) 
            {
                await connection.ExecuteAsync(query, updateDiscountDto);
            }
        }
    }
}
