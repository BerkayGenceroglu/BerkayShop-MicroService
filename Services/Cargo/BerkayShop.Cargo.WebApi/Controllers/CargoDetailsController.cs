using AutoMapper;
using BerkayShop.Cargo.BusinessLayer.Abstract;
using BerkayShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using BerkayShop.Cargo.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BerkayShop.Cargo.WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService _CargoDetailService;
        private readonly IMapper _mapper;

        public CargoDetailsController(ICargoDetailService CargoDetailService, IMapper mapper)
        {
            _CargoDetailService = CargoDetailService;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult GetAllCargoDetail()
        {
            var values = _CargoDetailService.TGetAll();
            return Ok(_mapper.Map<List<ResultCargoDetailDto>>(values));
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            _CargoDetailService.TDelete(id);
            return Ok("Silme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDto dto)
        {
            _CargoDetailService.TInsert(_mapper.Map<CargoDetail>(dto));
            return Ok("Ekleme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDto dto)
        {
            _CargoDetailService.TUpdate(_mapper.Map<CargoDetail>(dto));
            return Ok("Güncelleme İşlemi Başarılı bir Şekilde Gerçekleşti");
        }
        [HttpGet("{id}")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = _CargoDetailService.TGetById(id);
            return Ok(_mapper.Map<GetByIdCargoDetailDto>(value));
        }
    }
}
