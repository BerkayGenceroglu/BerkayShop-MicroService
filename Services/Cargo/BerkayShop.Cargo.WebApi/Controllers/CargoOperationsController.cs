using AutoMapper;
using BerkayShop.Cargo.BusinessLayer.Abstract;
using BerkayShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using BerkayShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Cargo.WebApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _CargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(ICargoOperationService CargoOperationService, IMapper mapper)
        {
            _CargoOperationService = CargoOperationService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCargoOperation()
        {
            var values = _CargoOperationService.TGetAll();
            return Ok(_mapper.Map<List<ResultCargoOperationDto>>(values));
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _CargoOperationService.TDelete(id);
            return Ok("Silme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto dto)
        {
            _CargoOperationService.TInsert(_mapper.Map<CargoOperation>(dto));
            return Ok("Ekleme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto dto)
        {
            _CargoOperationService.TUpdate(_mapper.Map<CargoOperation>(dto));
            return Ok("Güncelleme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _CargoOperationService.TGetById(id);
            return Ok(_mapper.Map<GetByIdCargoOperationDto>(value));
        }
    }
}
