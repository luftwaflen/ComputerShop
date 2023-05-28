using AutoMapper;
using ComputerShopData.Entities;
using ComputerShopData.Repositories.Interfases;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;

namespace ComputerShopLogic.Services.Implementation;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public IEnumerable<UserDto> GetAll()
    {
        var userEntities = _userRepository.GetAll();
        var userDtos = new List<UserDto>();
        foreach (var userEntity in userEntities)
        {
            var userDto = _mapper.Map<UserDto>(userEntity);
            userDtos.Add(userDto);
        }

        return userDtos;
    }

    public UserDto GetById(int id)
    {
        var userEntity = _userRepository.GetById(id);
        var userDto = _mapper.Map<UserDto>(userEntity);

        return userDto;
    }

    public void Create(UserDto obj)
    {
        var userEntity = _mapper.Map<UserEntity>(obj);
        _userRepository.Create(userEntity);
    }

    public void Update(UserDto obj)
    {
        var userEntity = _mapper.Map<UserEntity>(obj);
        _userRepository.Update(userEntity);
    }

    public void Delete(int id)
    {
        _userRepository.Delete(id);
    }
}