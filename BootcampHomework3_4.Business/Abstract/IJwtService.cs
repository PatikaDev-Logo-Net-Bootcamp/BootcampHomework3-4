using BootcampHomework3_4.Business.DTOs;

namespace BootcampHomework3_4.Business.Abstract
{
    public interface IJwtService
    {
        TokenDTO Authenticate(JwtUserDTO user);
    }
}
