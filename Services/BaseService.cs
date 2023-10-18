using AutoMapper;
using ExampleWebApiCRUD.Data;

namespace ExampleWebApiCRUD.Services
{
    public abstract class BaseService
    {
        protected readonly DataContext _context;
        protected readonly IMapper _mapper;

        public BaseService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
    }
}
