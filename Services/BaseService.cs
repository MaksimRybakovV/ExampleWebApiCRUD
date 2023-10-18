using AutoMapper;
using ExampleWebApiCRUD.Data;
using ExampleWebApiCRUD.Entities.Models;

namespace ExampleWebApiCRUD.Services
{
    public abstract class BaseService<T>
    {
        protected readonly DataContext _context;
        protected readonly IMapper _mapper;
        protected readonly ILogger<T> _logger;

        public BaseService(DataContext context, IMapper mapper, ILogger<T> logger)
        {
            _context = context;
            _mapper = mapper;
            _logger = logger;
        }
    }
}
