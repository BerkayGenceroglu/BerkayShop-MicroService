using AutoMapper;
using BerkayShop.Cargo.BusinessLayer.Abstract;
using BerkayShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using BerkayShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService _CargoCustomerService;
        private readonly IMapper _mapper;

        public CargoCustomersController(ICargoCustomerService CargoCustomerService, IMapper mapper)
        {
            _CargoCustomerService = CargoCustomerService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCargoCustomer()
        {
            var values = _CargoCustomerService.TGetAll();
            return Ok(_mapper.Map<List<ResultCargoCustomerDto>>(values));
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            _CargoCustomerService.TDelete(id);
            return Ok("Silme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDto dto)
        {
            _CargoCustomerService.TInsert(_mapper.Map<CargoCustomer>(dto));
            return Ok("Ekleme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDto dto)
        {
            _CargoCustomerService.TUpdate(_mapper.Map<CargoCustomer>(dto));
            return Ok("Güncelleme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = _CargoCustomerService.TGetById(id);
            return Ok(_mapper.Map<GetByIdCargoCustomerDto>(value));
        }
        [HttpGet("GetCargoCustomerByUserId/{userId}")]
        public async Task<IActionResult> GetCargoCustomerByUserId(string userId)
        {
            var value = await _CargoCustomerService.TGetCargoCustomerByUserId(userId);
            return Ok(_mapper.Map<ResultCargoCustomerDto>(value));
        }
    }
}
