using AutoMapper;
using BerkayShop.Cargo.DtoLayer.Dtos.CargoCompanyDtos;
using BerkayShop.Cargo.DtoLayer.Dtos.CargoCustomerDtos;
using BerkayShop.Cargo.DtoLayer.Dtos.CargoDetailDtos;
using BerkayShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using BerkayShop.Cargo.EntityLayer.Concrete;

namespace BerkayShop.Cargo.WebApi.Mapping
{
    public class GeneralMapping:Profile
    {
        public GeneralMapping()
        {
            //CargoCompany
            CreateMap<CargoCompany, ResultCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, GetByIdCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, UpdateCargoCompanyDto>().ReverseMap();
            CreateMap<CargoCompany, CreateCargoCompanyDto>().ReverseMap();

            //CargoCustomer
            CreateMap<CargoCustomer, CreateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, UpdateCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, ResultCargoCustomerDto>().ReverseMap();
            CreateMap<CargoCustomer, GetByIdCargoCustomerDto>().ReverseMap();

            //CargoDetail
            CreateMap<CargoDetail, CreateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, UpdateCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, ResultCargoDetailDto>().ReverseMap();
            CreateMap<CargoDetail, GetByIdCargoDetailDto>().ReverseMap();


            //CargoOperation
            CreateMap<CargoOperation, CreateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, UpdateCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, ResultCargoOperationDto>().ReverseMap();
            CreateMap<CargoOperation, GetByIdCargoOperationDto>().ReverseMap();
        }
    }
}
