using AutoMapper;
using InventoryDataAccessLayer.Models;
using Models;
using OrderDataAccessLayer.Models;

namespace BusinessLayer
{
    /// <summary>
    /// AutoMapper profile for all mapping cases.
    /// </summary>
	public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Data to Model
            CreateMap<Order, OrderModel>();
            CreateMap<OrderProduct, OrderProductModel>();
            CreateMap<Product, ProductModel>();
            CreateMap<NewProduct, NewProductModel>();
            CreateMap<UsedProduct, UsedProductModel>();

            CreateMap<NewProduct, IProductModel>().As<NewProductModel>();
            CreateMap<UsedProduct, IProductModel>().As<UsedProductModel>();

            // Model to Data
            CreateMap<OrderModel, Order>();
            CreateMap<OrderProductModel, OrderProduct>();
            CreateMap<ProductModel, Product>();
            CreateMap<UsedProductModel, UsedProduct>();
            CreateMap<NewProductModel, NewProduct>();

        }
    }
}
