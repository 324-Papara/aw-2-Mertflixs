using Microsoft.AspNetCore.Mvc;
using Para.Data.Domain;
using Para.Data.UnitOfWork;
using Microsoft.EntityFrameworkCore;


namespace Para.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Customers2Controller : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public Customers2Controller(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public async Task<List<Customer>> Get() {
            var entityList = await unitOfWork.CustomerRepository.GetAll();
            return entityList;
        }

        [HttpGet("{customerId}")]
        public async Task<Customer> Get(long customerId) {
            var entity = await unitOfWork.CustomerRepository.GetById(customerId);
            return entity;
        }

        [HttpPost]
        public async Task Post([FromBody] Customer value)
        {
            await unitOfWork.CustomerRepository.Insert(value);
            await unitOfWork.CustomerRepository.Insert(value);
            await unitOfWork.CustomerRepository.Insert(value);
            await unitOfWork.Complete();
        }

        [HttpPut("{customerId}")]
        public async Task Put(long customerId, [FromBody] Customer value)
        {
            await unitOfWork.CustomerRepository.Update(value);
            await unitOfWork.Complete();
        }

        [HttpDelete("{customerId}")]
        public async Task Delete(long customerId)
        {
            await unitOfWork.CustomerRepository.Delete(customerId);
            await unitOfWork.Complete();
        }

        [HttpGet("byLastname/{lastName}")]
        public async Task<List<Customer>> GetByLastName(string lastName) {
            var customerLastName = await unitOfWork.CustomerRepository.Where(c => c.LastName == lastName);
            return customerLastName;
        }

        [HttpGet("GetCustomerByFirstName/{name}")]
        public async Task<List<Customer>> GetCustomerByFirstName(string name)
        {
            var customers = await unitOfWork.CustomerRepository.Where(x => x.FirstName == name);
            return customers;
        }

        [HttpGet("GetCustomerWithCustomerDetails")]
        public async Task<List<Customer>> GetCustomerWithCustomerDetails()
        {
            var customers = await unitOfWork.CustomerRepository.Include(x => x.CustomerDetail).ToListAsync();
            return customers;
        }
    }
}