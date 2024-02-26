using AutoMapper;
using MediatR;
using WWDemo.Application.DTOs;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.GetProductBySerialNumber
{
    public class GetProductsBySerialNumberHandler : IRequestHandler<GetProductBySerialNumberQuery, ProductRepresentation>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public GetProductsBySerialNumberHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductRepresentation> Handle(GetProductBySerialNumberQuery query, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductBySerialNumber(query.SerialNumber!);
            var result = _mapper.Map<ProductRepresentation>(product);
            return result;
        }
    }
}
