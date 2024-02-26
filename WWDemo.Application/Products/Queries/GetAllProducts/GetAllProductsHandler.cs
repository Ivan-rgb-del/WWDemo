using AutoMapper;
using MediatR;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.GetAllProducts
{
    public class GetAllProductsHandler : IRequestHandler<GetAllProductsQuery, List<DTOs.ProductRepresentation>>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetAllProductsHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
         
        public async Task<List<DTOs.ProductRepresentation>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var products = await _productRepository.GetAllProducts();

            var result = _mapper.Map<List<Models.Product>, List<DTOs.ProductRepresentation>>(products!);

            return result;
        }
    }
}