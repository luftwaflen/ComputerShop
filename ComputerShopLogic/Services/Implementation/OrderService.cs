using AutoMapper;
using ComputerShopData.Entities;
using ComputerShopData.Repositories.Interfases;
using ComputerShopLogic.Dto;
using ComputerShopLogic.Services.Interfaces;

namespace ComputerShopLogic.Services.Implementation;

public class OrderService : IOrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public IEnumerable<OrderDto> GetAll()
    {
        var orderEntities = _orderRepository.GetAll();
        var orderDtos = new List<OrderDto>();
        foreach (var orderEntity in orderEntities)
        {
            var orderDto = _mapper.Map<OrderDto>(orderEntity);
            orderDtos.Add(orderDto);
        }

        return orderDtos;
    }

    public OrderDto GetById(int id)
    {
        var orderEntity = _orderRepository.GetById(id);
        var orderDto = _mapper.Map<OrderDto>(orderEntity);

        return orderDto;
    }

    public void Create(OrderDto obj)
    {
        var orderEntity = _mapper.Map<OrderEntity>(obj);
        _orderRepository.Create(orderEntity);
    }

    public void Update(OrderDto obj)
    {
        var orderEntity = _mapper.Map<OrderEntity>(obj);
        _orderRepository.Update(orderEntity);
    }

    public void Delete(int id)
    {
        _orderRepository.Delete(id);
    }
}