using AutoMapper;
using Booking.BLL.Mapping;
using Booking.BLL.Models;
using Booking.BLL.Tests.AutoData;
using Booking.DAL;
using Booking.DAL.Abstractions;
using Booking.DAL.Entities;
using Booking.DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Booking.BLL.Tests.Services;

public class BookingServiceTest
{
    private readonly IBookingRepository _bookingRepository;
    private readonly BookingDbContext _dbContext;
    private readonly IGenericRepository<BookingEntity> _genericRepository;
    private readonly IMapper _mapper;
    private readonly DbContextOptions<BookingDbContext> _dbContextOptions;

    public BookingServiceTest()
    {
        var myProfile = new BookingModelMapping();
        var configuration = new MapperConfiguration(cfg => cfg.AddProfile(myProfile));
        _mapper = new Mapper(configuration);

        _dbContextOptions = new DbContextOptionsBuilder<BookingDbContext>()
            .UseInMemoryDatabase("BookingInMemoryForService")
            .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;
        _dbContext = new BookingDbContext(_dbContextOptions);

        _genericRepository = new GenericRepository<BookingEntity>(_dbContext);

        _bookingRepository = new BookingRepository(_dbContext);

        _dbContext.Database.EnsureCreated();
        _dbContext.Database.EnsureDeleted();

        _dbContext.AddRange(BookingData.CreateBookingsList());

        _dbContext.SaveChanges();
    }

    [Fact]
    public async Task GetAll_Return_ListOfBookingModels_Async()
    {
        // Act
        var entities = await _genericRepository.GetAllAsync();

        // Arrange
        var models = _mapper.Map<List<BookingModel>>(entities);

        // Assert
        Assert.NotNull(models);
    }

    [Theory]
    [InlineData("35edf9c3-7bb7-40b7-9ead-41ec4efec537")]
    [InlineData("489e445b-e68b-4324-8b1e-4e2b01f03cdc")]
    public async Task GetById_Return_Null_Async(string id)
    {
        // Act
        var guidId = new Guid(id);

        // Arrange
        var entity = await _bookingRepository.GetByIdAsync(guidId);
        var model = _mapper.Map<BookingModel>(entity);

        // Assert
        Assert.Null(model);
    }

    [Theory]
    [InlineData("f6face9c-42d4-4b3f-a95e-78504197ca62")]
    [InlineData("4f6f84cb-ed8f-45f6-ae40-7c2e7f525f3d")]
    public async Task GetById_Return_NotNull_Async(string id)
    {
        // Act
        var guidId = new Guid(id);
        var entity = await _bookingRepository.GetByIdAsync(guidId);

        // Arrange
        var model = _mapper.Map<BookingModel>(entity);

        // Act
        Assert.NotNull(model);
    }
}