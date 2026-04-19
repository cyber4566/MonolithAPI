using AutoMapper;
using MonolithAPI.DTO;
using MonolithAPI.Models;
using MonolithAPI.Repository.Interface;
using MonolithAPI.Services.Interface;

namespace MonolithAPI.Services.Implementation
{
    public class CalenderService : ICalenderService
    {

        private ISecurityRepository securityRepository;
        private ICalenderRepository calenderRepository;
        private IMapper mapper;
        public CalenderService(ISecurityRepository securityRepository, ICalenderRepository calenderRepository, IMapper mapper) {
        
           this.securityRepository = securityRepository;
           this.calenderRepository = calenderRepository;
            this.mapper = mapper;
        }

        public async Task addCalenderEvent(AddCalenderEventDTO addCalenderEventDTO)
        {
            var user = await securityRepository.FindUserAsync(addCalenderEventDTO.username);

            if (user != null) { 
            
                    var calenderEvent = mapper.Map<CalenderEvent>(addCalenderEventDTO);
                calenderEvent.User = user;
            
            
            }
        }
    }
}
