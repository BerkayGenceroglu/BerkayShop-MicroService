using AutoMapper;
using BerkayShop.Cargo.BusinessLayer.Abstract;
using BerkayShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using BerkayShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService _cargoCompanyService;
        private readonly IMapper _mapper;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService, IMapper mapper)
        {
            _cargoCompanyService = cargoCompanyService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCargoCompany()
        {
             var values = _cargoCompanyService.TGetAll();
            return Ok(_mapper.Map<List<ResultCargoCompanyDto>>(values));
        }
        [HttpDelete("{id}")]
        public IActionResult RemoveCargoCompany(int id)
        {
            _cargoCompanyService.TDelete(id);
            return Ok("Silme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDto dto)
        {
            _cargoCompanyService.TInsert(_mapper.Map<CargoCompany>(dto));
            return Ok("Ekleme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto dto)
        {
            _cargoCompanyService.TUpdate(_mapper.Map<CargoCompany>(dto));
            return Ok("Güncelleme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = _cargoCompanyService.TGetById(id);
            return Ok(_mapper.Map<GetByIdCargoCompanyDto>(value));
        }
        [HttpGet("GetTotalOrderCompanyCount")]
        public async Task<IActionResult> GetTotalOrderCompanyCount()
        {
            return Ok( await _cargoCompanyService.TGetTotalCargoCompanyCount());
        }
    }
}
